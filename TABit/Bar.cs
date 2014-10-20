using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    class Bar
    {
        public List<Note> notes;
        public int[] time_signature = new int[2];
        public Main main_window;

        public Bar(int time_signatur_upside, int time_signature_downside, Main main_window)
        {
            this.time_signature[0] = time_signatur_upside;
            this.time_signature[1] = time_signature_downside;
            this.notes = new List<Note>();
            this.main_window = main_window;
        }

        public string[] test_output()
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
            notes.Add(new Note(0, 8, 2, 2));
            notes.Add(new Note(5, 12, 1, 2));
            //notes.Add(new Note(5, 4, 1, 3));
            //notes.Add(new Note(5, 2, 6, 1));
            //notes.Add(new Note(10, 2, 3, 2));
            //notes.Add(new Note(5, 2, 3, 3));

            List<int> note_lengths = get_note_lengths();
            int bar_length = get_bar_length(note_lengths);
            Dictionary<int, int> written_lengths = get_written_length_of_each_note(bar_length, note_lengths);

            string[] output = string_output(written_lengths, Convert.ToInt16(main_window.cbStrings.Text), bar_length);
            return output;
        }

        public List<int> get_note_lengths()
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

        public int get_bar_length(List<int> note_lengths)
        {
            int b = 1;

            foreach (int a in note_lengths)
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

        public Dictionary<int, int> get_written_length_of_each_note(int bar_length, List<int> notelengths)
        {
            Dictionary<int, int> writtenlengths = new Dictionary<int, int>();

            foreach (int notelength in notelengths)
            {
                writtenlengths[notelength] = bar_length / notelength;
            }

            return writtenlengths;
        }

        String[] string_output(Dictionary<int, int> written_lengths, int number_of_strings, int bar_length)
        {
            String[] output = new string[number_of_strings];


            //TODO: make the bar-checker as a function. checks if bar is too long and if the startpoints of two notes on the same string are the same
            foreach (Note note in notes)
            {
                if ((note.fret <= 9 && note.fret >= 0 && note.startpoint > bar_length - 1) || (note.fret > 9 && note.startpoint >= bar_length - 1))
                {
                    throw new Exception("Notes in bar are to long");
                }
            }

            for (int string_number = 1; string_number <= number_of_strings; string_number++)
            {
                //Get all notes on string_number
                List<Note> notes_on_string = new List<Note>();
                foreach (Note note in notes)
                {
                    if (note.stringnumber == string_number)
                    {
                        notes_on_string.Add(note);
                    }
                }

                //add "|" at beginning of the bar
                output[string_number - 1] += "|";
                if (notes_on_string.Count() > 0)
                {
                    for (int character_number = 0; character_number <= bar_length - 1; character_number++)
                    {
                        foreach (Note note in notes_on_string)
                        {
                            if (note.startpoint == character_number)
                            {
                                int note_fret = note.fret;

                                if (note_fret >= 0 && note_fret <= 9)
                                {
                                    //Fret has one character --> pass one character at end of the foreach
                                    output[string_number - 1] += Convert.ToString(note_fret);
                                }
                                else if (note_fret >= 10)
                                {
                                    //Fret has two characters --> pass one character here and one at end of the foreach
                                    output[string_number - 1] += Convert.ToString(note_fret);
                                    character_number ++;
                                }
                                else if (note_fret == -1)
                                {
                                    //The note is a ghost-note --> pass one character at end of the foreach
                                    output[string_number - 1] += "x";
                                }
                            }
                            else
                            {
                                output[string_number - 1] += "-";
                            }
                        }
                    }
                }
                else
                {
                    for (int character_number = 0; character_number <= bar_length - 1; character_number++)
                    {
                        output[string_number - 1] += "-";
                    }
                }
            }

            //output[0] = "Sis das not wörk jät. Plies weit antill ai häf finischt seh fanktschen";
            return output;
        }
    }
}
