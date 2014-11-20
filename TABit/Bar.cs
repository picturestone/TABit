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
        public bool is_drawn;

        public Bar(int time_signatur_upside, int time_signature_downside, Main main_window, bool is_drawn)
        {
            this.time_signature[0] = time_signatur_upside;
            this.time_signature[1] = time_signature_downside;
            this.notes = new List<Note>();
            notes.Add(new Note(0, 8, 2, 2));
            notes.Add(new Note(5, 12, 1, 2));
            this.main_window = main_window;
            this.is_drawn = is_drawn;
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

        public String[] string_output(Dictionary<int, int> written_lengths, int number_of_strings, int bar_length)
        {
            String[] output = new string[number_of_strings];


            //checks if bar is to long
            if (is_written_bar_ok(bar_length) == false)
            {
                throw new Exception("Bar is to long or consisting of notes not allowed");
            }
            //TODO: use the are_notes_in_bar_ok function too


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

        public bool is_written_bar_ok(int bar_length)
        {
            bool bar_is_ok = true;

            foreach (Note note in notes)
            {
                if ((note.fret <= 9 && note.fret >= 0 && note.startpoint > bar_length - 1) || (note.fret > 9 && note.startpoint >= bar_length - 1))
                {
                    bar_is_ok = false;
                }
            }

            return bar_is_ok;
        }

        public bool are_notes_in_bar_ok(Dictionary<int, int> written_lengths, int number_of_strings)
        {
            /*
             * TODO:
             * Make a function which checks if the startpoint of a note colides with the length of the note before
             * 
             * 
             * 
             */
            bool bar_is_ok = true;
            int[] length_on_string = new int[number_of_strings];

            foreach (Note note in notes)
            {
            //    length_on_string[note.stringnumber] = written_lengths[note.length]
            }

            return bar_is_ok;
        }

        public void addNote(int fret, int length, int stringnumber, int startpoint)
        {
            notes.Add(new Note(fret, length, stringnumber, startpoint));
        }
    }
}