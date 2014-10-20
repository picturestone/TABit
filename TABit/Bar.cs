﻿using System;
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


            //if (bar_lengthcheck(6))
            //{
            //    List<int> notelenghts = get_notelengths();
            //    Dictionary<int, int> notelength_writtenlength = get_writtenlength(notelenghts);

            string[] output = string_output(written_lengths, Convert.ToInt16(main_window.cbStrings.Text), bar_length);
            return output;
            //}
            //else
            //{
            //    return new string[1]{"i can not draw this, your notes are to long."};
            //}
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
            String[] string_output = new string[number_of_strings];
            string_output[0] = "Sis das not wörk jät. Plies weit antill ai häf finischt seh fanktschen";
            return string_output;
        }


        //public String[] string_output(Dictionary<int, int> notelength_writtenlength, int stringnumber_input, int bar_length)
        //{
        //    String[] output_array = new String[stringnumber_input];
        //    String output = "";
        //    int bar_writtenlength = bar_length;

        //    for (int stringnumber = 1; stringnumber <= stringnumber_input; stringnumber++)
        //    {
        //        output = "|";
        //        List<Note> notes_on_string = new List<Note>();

        //        foreach (Note note in notes)
        //        {
        //            if (note.stringnumber == stringnumber)
        //            {
        //                notes_on_string.Add(note);
        //            }
        //        }

        //        int startpoint = 0;
        //        int i;
        //        int notecount = notes_on_string.Count();
        //        if (notecount == 0)
        //        {
        //            i = 0;
        //            while (i < bar_writtenlength)
        //            {
        //                output = output + "-";
        //                i++;
        //            }
        //        }
        //        else
        //        {
        //            while (notecount > 0)
        //            {
        //                foreach (Note note in notes_on_string)
        //                {
        //                    if (note.startpoint == startpoint)
        //                    {
        //                        if (note.fret >= 0 && note.fret <= 9)
        //                        {
        //                            output = output + note.fret;
        //                            i = 1;
        //                            while (i < notelength_writtenlength[note.length])
        //                            {
        //                                output = output + "-";
        //                                i++;
        //                            }
        //                        }
        //                        else if (note.fret >= 10)
        //                        {
        //                            output = output + note.fret;
        //                            i = 1;
        //                            while (i < notelength_writtenlength[note.length] - 1)
        //                            {
        //                                output = output + "-";
        //                                i++;
        //                            }
        //                        }
        //                        else if (note.fret == -1)
        //                        {
        //                            output = output + "x";
        //                            i = 1;
        //                            while (i < notelength_writtenlength[note.length])
        //                            {
        //                                output = output + "-";
        //                                i++;
        //                            }
        //                        }
        //                        else if (note.fret == -2)
        //                        {
        //                            output = output + "-";
        //                            i = 1;
        //                            while (i < notelength_writtenlength[note.length])
        //                            {
        //                                output = output + "-";
        //                                i++;
        //                            }
        //                        }
        //                        notecount--;
        //                    }
        //                }
        //                startpoint++;
        //            }
        //        }

        //        if (output.Count() < bar_writtenlength)
        //        {
        //            for (i = 0; i <= bar_writtenlength - (output.Count() - 1); i++)
        //            {
        //                output = output + "-";
        //            }
        //        }

        //        output_array[stringnumber - 1] = output;
        //    }
        //    return output_array;
        //}

        //public Dictionary<int, int> get_writtenlength(List<int> notelengths)
        //{
        //    /*bool compress = true;
        //    if (notelengths.Contains(1) || notelengths.Contains(2))
        //    {
        //        compress = false;
        //    }*/

        //    int gcd_of_notes = GCD(notelengths);
        //    int[] quaterlength_array = new int[notelengths.Count()];

        //    int i = 0;
        //    foreach (int notelength in notelengths)
        //    {
        //        quaterlength_array[i] = notelength / gcd_of_notes;
        //        i++;
        //    }

        //    int quaterlength = 1;
        //    foreach (int quaterlength_factor in quaterlength_array)
        //    {
        //        quaterlength = quaterlength * quaterlength_factor;
        //    }

        //    i = 0;
        //    double[] quaterlength_divisor = new double[notelengths.Count()];
        //    foreach (int notelength in notelengths)
        //    {
        //        quaterlength_divisor[i] = (double)notelength / time_signature[1];
        //        i++;
        //    }

        //    double longest_note = 0;
        //    foreach (double notelength in quaterlength_divisor)
        //    {
        //        if (notelength > longest_note)
        //        {
        //            longest_note = notelength;
        //        }
        //    }
        //    if (longest_note > quaterlength)
        //    {
        //        quaterlength = Convert.ToInt16(((2 * longest_note) / quaterlength) * quaterlength);
        //        /*compress = false;*/
        //    }

        //    i = 0;
        //    int[] writtenlengths = new int[notelengths.Count()];
        //    foreach (double divisor in quaterlength_divisor)
        //    {
        //        writtenlengths[i] = Convert.ToInt16(quaterlength / divisor);
        //        i++;
        //    }

        //    i = 0;
        //    int compress_factor = GCD(writtenlengths);
        //    if (/*compress == true && */compress_factor > 1)
        //    {
        //        foreach (int writtenlength in writtenlengths)
        //        {
        //            writtenlengths[i] = writtenlength / compress_factor;
        //            i++;
        //        }
        //    }

        //    i = 0;
        //    Dictionary<int, int> notelengths_writtenlengths = new Dictionary<int, int>();
        //    foreach (int notelength in notelengths)
        //    {
        //        notelengths_writtenlengths.Add(notelength, (int)writtenlengths[i]);
        //        i++;
        //    }

        //    if (notelengths_writtenlengths[1] < 8 || notelengths_writtenlengths[2] < 4)
        //    {
        //        i = 0;

        //        int factor = 8 / notelengths_writtenlengths[1];

        //        foreach (int notelength in notelengths)
        //        {
        //            notelengths_writtenlengths[notelength] = notelengths_writtenlengths[notelength] * factor;
        //        }
        //    }


        //    return notelengths_writtenlengths;
        //}

        //static int GCD(List<int> numbers)
        //{
        //    return numbers.Aggregate(GCD);
        //}
        //static int GCD(int[] numbers)
        //{
        //    return numbers.Aggregate(GCD);
        //}
        //static int GCD(int a, int b)
        //{
        //    return b == 0 ? a : GCD(b, a % b);
        //}

        //public bool bar_lengthcheck(int stringnumber)
        //{
        //    for (int i = 1; i <= stringnumber; i++)
        //    {
        //        int summed_notelength = 0;
        //        List<int> notes_on_string = new List<int>();

        //        foreach (Note note in notes)
        //        {
        //            if (note.stringnumber == i)
        //            {
        //                notes_on_string.Add(note.length);
        //            }
        //        }

        //        if (notes_on_string.Count() == 0)
        //        {
        //            continue;
        //        }
        //        int gcd = GCD(notes_on_string);

        //        foreach (int note in notes_on_string)
        //        {
        //            int summ = gcd / note;
        //            summed_notelength += summ;
        //        }

        //        int bar_timing_length = gcd / this.time_signature[1];
        //        int max_summed_notelength = this.time_signature[0] * bar_timing_length;

        //        if (max_summed_notelength < summed_notelength)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
