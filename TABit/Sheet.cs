using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    class Sheet
    {
        public List<Bar> bars;
        public int string_count;
        public int chars_per_string;
        public int lines_between_blocks;

        public Sheet(int string_count, int chars_per_string, int lines_between_blocks)
        {
            this.bars = new List<Bar>();
            this.string_count = string_count;
            this.chars_per_string = chars_per_string;
            this.lines_between_blocks = lines_between_blocks;
        }

        public string[] get_block()
        {
            string[] output = new string[string_count];
            foreach (Bar bar in bars)
            {
                List<int> note_lengths = bar.get_note_lengths();
                int bar_length = bar.get_bar_length(note_lengths);
                Dictionary<int, int> written_lengths = bar.get_written_length_of_each_note(bar_length, note_lengths);
                string[] output_of_bar = bar.string_output(written_lengths, this.string_count, bar_length);

                if (output[0].Length + output_of_bar[0].Length + 2 <= this.chars_per_string)
                {
                    for (int i = 0; i < string_count; i++)
                    {
                        output[i] += "|";
                        output[i] += output_of_bar[i];
                    }
                }
            }

            for (int i = 0; i < string_count; i++)
            {
                output[i] += "|";
            }

            //TODO: What if a bar is to long for this line? How does one transfer it to the next block?
            return output;
        }


        //TODO: Draw all the blocks. a block, then lines_between_blocks space, then the next block
    }
}