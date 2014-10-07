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

        public Bar(int time_signatur_upside, int time_signature_downside)
        {
            time_signature[0] = time_signatur_upside;
            time_signature[1] = time_signature_downside;
            notes = new List<Note>();
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
            notes.Add(new Note(0, 2, 1, 1));
            notes.Add(new Note(5, 4, 1, 2));
            notes.Add(new Note(5, 4, 1, 3));
            notes.Add(new Note(5, 1, 2, 1));
            notes.Add(new Note(10, 2, 3, 1));
            notes.Add(new Note(5, 2, 3, 2));

            List<int> notelenghts = get_notelengths();
            Dictionary<int, int> notelength_writtenlength = get_writtenlength(notelenghts);

            string[] output = string_output(notelength_writtenlength, 6);
            return output;
        }

        public String[] string_output(Dictionary<int, int> notelength_writtenlength, int stringnumber_input)
        {
            String[] output_array = new String[stringnumber_input];
            String output = "";
            int bar_writtenlength = notelength_writtenlength.Keys.First() * notelength_writtenlength[notelength_writtenlength.Keys.First()] * time_signature[0] / time_signature[1];

            for (int stringnumber = 1; stringnumber <= stringnumber_input; stringnumber++)
            {
                output = "|";
                List<Note> notes_on_string = new List<Note>();

                foreach (Note note in notes)
                {
                    if (note.stringnumber == stringnumber)
                    {
                        notes_on_string.Add(note);
                    }
                }

                int startpoint = 0;
                int i;
                int notecount = notes_on_string.Count();
                if (notecount == 0)
                {
                    i = 0;
                    while (i < bar_writtenlength)
                    {
                        output = output + "-";
                        i++;
                    }
                }
                else
                {
                    while (notecount > 0)
                    {
                        foreach (Note note in notes_on_string)
                        {
                            if (note.startpoint == startpoint)
                            {
                                if (note.fret >= 0 && note.fret <= 9)
                                {
                                    output = output + note.fret;
                                    i = 1;
                                    while (i < notelength_writtenlength[note.length])
                                    {
                                        output = output + "-";
                                        i++;
                                    }
                                }
                                else if (note.fret >= 10)
                                {
                                    output = output + note.fret;
                                    i = 1;
                                    while (i < notelength_writtenlength[note.length] - 1)
                                    {
                                        output = output + "-";
                                        i++;
                                    }
                                }
                                else if (note.fret == -1)
                                {
                                    output = output + "x";
                                    i = 1;
                                    while (i < notelength_writtenlength[note.length])
                                    {
                                        output = output + "-";
                                        i++;
                                    }
                                }
                                else if (note.fret == -2)
                                {
                                    output = output + "-";
                                    i = 1;
                                    while (i < notelength_writtenlength[note.length])
                                    {
                                        output = output + "-";
                                        i++;
                                    }
                                }
                                notecount--;
                            }
                        }
                        startpoint++;
                    }
                }
                output_array[stringnumber - 1] = output;
            }
            return output_array;
        }

        public List<int> get_notelengths()
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

        public Dictionary<int, int> get_writtenlength(List<int> notelengths)
        {
            bool compress = true;
            if (notelengths.Contains(1) || notelengths.Contains(2))
            {
                compress = false;
            }

            int gcd_of_notes = GCD(notelengths);
            int[] quaterlength_array = new int[notelengths.Count()];

            int i = 0;
            foreach (int notelength in notelengths)
            {
                quaterlength_array[i] = notelength / gcd_of_notes;
                i++;
            }

            int quaterlength = 1;
            foreach (int quaterlength_factor in quaterlength_array)
            {
                quaterlength = quaterlength * quaterlength_factor;
            }

            i = 0;
            double[] quaterlength_divisor = new double[notelengths.Count()];
            foreach (int notelength in notelengths)
            {
                quaterlength_divisor[i] = (double)notelength / time_signature[1];
                i++;
            }

            double longest_note = 0;
            foreach (double notelength in quaterlength_divisor)
            {
                if (notelength > longest_note)
                {
                    longest_note = notelength;
                }
            }
            if (longest_note > quaterlength)
            {
                quaterlength = Convert.ToInt16(((2 * longest_note) / quaterlength) * quaterlength);
                compress = false;
            }

            i = 0;
            int[] writtenlengths = new int[notelengths.Count()];
            foreach (double divisor in quaterlength_divisor)
            {
                writtenlengths[i] = Convert.ToInt16(quaterlength / divisor);
                i++;
            }

            i = 0;
            int compress_factor = GCD(writtenlengths);
            if (compress == true && compress_factor > 1)
            {
                foreach (int writtenlength in writtenlengths)
                {
                    writtenlengths[i] = writtenlength / compress_factor;
                    i++;
                }
            }

            i = 0;
            Dictionary<int, int> notelengths_writtenlengths = new Dictionary<int, int>();
            foreach (int notelength in notelengths)
            {
                notelengths_writtenlengths.Add(notelength, (int)writtenlengths[i]);
                i++;
            }

            return notelengths_writtenlengths;
        }

        static int GCD(List<int> numbers)
        {
            return numbers.Aggregate(GCD);
        }
        static int GCD(int[] numbers)
        {
            return numbers.Aggregate(GCD);
        }
        static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }
}
