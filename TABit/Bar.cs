using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    public class Bar
    {
        public List<Note> notes;
        public int[] timeSignature = new int[2];
        public Main mainWindow;
        public bool isDrawn;

        public Bar(int timeSignaturUpside, int timeSignatureDownside, Main mainWindow, bool isDrawn)
        {
            this.timeSignature[0] = timeSignaturUpside;
            this.timeSignature[1] = timeSignatureDownside;
            this.notes = new List<Note>();
            notes.Add(new Note(0, 8, 2, 2));
            notes.Add(new Note(5, 12, 1, 2));
            this.mainWindow = mainWindow;
            this.isDrawn = isDrawn;
        }

        public string[] testOutput()
        {
            /* Notelength:                  Requiered to complete bar
             * 1/1 -> 1 = Full              1
             * 1/2 -> 2 = Half              2
             * 1/3 -> 3 = Half-Triol        3
             * 1/4 -> 4 = Quater            4
             * 1/5 -> 5 = Half-Quintol      5
             * 1/6 -> 6 = Quater-Triol      6
             * 1/8 -> 8 = Eight             8
             * 1/10 -> 10 = Quater-Quintol  10
             * 1/12 -> 12 = Eight-Triol     12
             * 1/16 -> 16 = Sixteenth       16
             * 1/20 -> 20 = Eight-Quintol   20
             * 1/24 -> 24 = Sixteenth-Triol 24
             * 1/32 -> 32 =                 32
             */
            

            List<int> noteLengths = getNoteLengths();
            int barLength = getBarLength(noteLengths);
            Dictionary<int, int> writtenLengths = getWrittenLengthOfEachNote(barLength, noteLengths);

            string[] output = stringOutput(writtenLengths, Convert.ToInt16(mainWindow.cbStrings.Text), barLength);
            return output;
        }

        public List<int> getNoteLengths()
                {
                    List<int> notelengths = new List<int>();
                    foreach (Note note in notes)
                    {
                        if (notelengths.Contains(note.length) == false)
                        {
                            notelengths.Add(note.length);
                        }
                    }
                    return notelengths;
                }

        public int getBarLength(List<int> noteLengths)
        {
            int b = 1;

            foreach (int a in noteLengths)
            {
                b = lcm(a, b);
            }            

            return b;
        }

        static int gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        static int lcm(int a, int b)
        {
            return (a / gcf(a, b)) * b;
        }

        public Dictionary<int, int> getWrittenLengthOfEachNote(int barLength, List<int> notelengths)
        {
            Dictionary<int, int> writtenlengths = new Dictionary<int, int>();
            foreach (int notelength in notelengths)
            {
                writtenlengths[notelength] = barLength / notelength;
            }

            return writtenlengths;
        }

        public String[] stringOutput(Dictionary<int, int> writtenLengths, int numberOfStrings, int barLength)
        {
            String[] output = new string[numberOfStrings];


            //checks if bar is to long
            if (isWrittenBarOk(barLength) == false)
            {
                throw new Exception("Bar is to long or consisting of notes not allowed");
            }
            //TODO: use the are_notes_in_bar_ok function too


            for (int stringNumber = 1; stringNumber <= numberOfStrings; stringNumber++)
            {
                //Get all notes on string_number
                List<Note> notesOnString = new List<Note>();
                foreach (Note note in notes)
                {
                    if (note.stringnumber == stringNumber)
                    {
                        notesOnString.Add(note);
                    }
                }

                 
                if (notesOnString.Count() > 0)
                {
                    for (int characterNumber = 0; characterNumber <= barLength - 1; characterNumber++)
                    {
                        foreach (Note note in notesOnString)
                        {
                            if (note.startpoint == characterNumber)
                            {
                                int noteFret = note.fret;

                                if (noteFret >= 0 && noteFret <= 9)
                                {
                                    //Fret has one character --> pass one character at end of the foreach
                                    output[stringNumber - 1] += Convert.ToString(noteFret);
                                }
                                else if (noteFret >= 10)
                                {
                                    //Fret has two characters --> pass one character here and one at end of the foreach
                                    output[stringNumber - 1] += Convert.ToString(noteFret);
                                    characterNumber ++;
                                }
                                else if (noteFret == -1)
                                {
                                    //The note is a ghost-note --> pass one character at end of the foreach
                                    output[stringNumber - 1] += "x";
                                }
                            }
                            else
                            {
                                output[stringNumber - 1] += "-";
                            }
                        }
                    }
                }
                else
                {
                    for (int characterNumber = 0; characterNumber <= barLength - 1; characterNumber++)
                    {
                        output[stringNumber - 1] += "-";
                    }
                }
            }

            //output[0] = "Sis das not wörk jät. Plies weit antill ai häf finischt seh fanktschen";
            return output;
        }

        public bool isWrittenBarOk(int barLength)
        {
            bool barIsOk = true;

            foreach (Note note in notes)
            {
                if ((note.fret <= 9 && note.fret >= 0 && note.startpoint > barLength - 1) || (note.fret > 9 && note.startpoint >= barLength - 1))
                {
                    barIsOk = false;
                }
            }

            return barIsOk;
        }

        public bool areNotesInBarOk(Dictionary<int, int> writtenLengths, int numberOfStrings)
        {
            /*
             * TODO:
             * Make a function which checks if the startpoint of a note colides with the length of the note before
             * 
             * 
             * 
             */
            bool barIsOk = true;
            int[] lengthOnString = new int[numberOfStrings];

            foreach (Note note in notes)
            {
            //    length_on_string[note.stringnumber] = written_lengths[note.length]
            }

            return barIsOk;
        }

        public void addNote(int fret, int length, int stringnumber, int startpoint)
        {
            notes.Add(new Note(fret, length, stringnumber, startpoint));
        }
    }
}