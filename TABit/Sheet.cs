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
        public int string_count { get; set; }
        public int chars_per_string { get; set; }
        public int lines_between_blocks { get; set; }
        public Main mainWindow;

        public Sheet(int string_count, int chars_per_string, int lines_between_blocks, Main mainWindow)
        {
            this.bars = new List<Bar>();
            this.string_count = string_count;
            this.chars_per_string = chars_per_string;
            this.lines_between_blocks = lines_between_blocks;
            this.mainWindow = mainWindow;
        }

        public string[] get_block_text()
        {
            string[] output = new string[string_count];
            for (int i = 0; i < string_count; i++)
            {
                output[i] = "";
            }
            foreach (Bar bar in bars)
            {
                if (bar.is_drawn == false) //bar is not drawn yet
                {
                    List<int> note_lengths = bar.get_note_lengths();
                    int bar_length = bar.get_bar_length(note_lengths);
                    Dictionary<int, int> written_lengths = bar.get_written_length_of_each_note(bar_length, note_lengths);
                    string[] output_of_bar = bar.string_output(written_lengths, this.string_count, bar_length);

                    if (output[0].Length + output_of_bar[0].Length + 1 <= this.chars_per_string)
                    {
                        for (int i = 0; i < string_count; i++)
                        {
                            output[i] += "|";
                            output[i] += output_of_bar[i];
                            bar.is_drawn = true;
                        }
                    }
                }
            }

            return output;
        }

        public string[] get_sheet_text()
        {
            //Draw all the blocks. a block, then lines_between_blocks space, then the next block

            List<string> output = new List<string>();
            while (are_bars_drawn() == false)
            {
                foreach (string instrument_string in get_block_text())
                {
                    output.Add(instrument_string + "|");
                }
                if (are_bars_drawn() == false)
                {
                    for (int i = 0; i < lines_between_blocks; i++)
                    {
                        output.Add("");
                    }
                }
            }

            return output.ToArray();
        }

        public bool are_bars_drawn()
        {
            foreach (Bar bar in bars)
            {
                if (bar.is_drawn == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void add_bar(int time_signature_upside, int time_signature_downside)
        {
            bars.Add(new Bar(time_signature_upside, time_signature_downside, this.mainWindow, false));
        }
    }
}