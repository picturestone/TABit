using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    public class Sheet
    {
        public List<Bar> bars;
        public List<Block> blocks;
        public int stringCount { get; set; }
        public int charsPerString { get; set; }
        public int linesBetweenBlocks { get; set; }
        public Main mainWindow;

        public Sheet(int stringCount, int charsPerString, int linesBetweenBlocks, Main mainWindow)
        {
            this.bars = new List<Bar>();
            this.stringCount = stringCount;
            this.charsPerString = charsPerString;
            this.linesBetweenBlocks = linesBetweenBlocks;
            this.mainWindow = mainWindow;
        }

        public string[] getBlockText()
        {
            string[] output = new string[stringCount];
            for (int i = 0; i < stringCount; i++)
            {
                output[i] = "";
            }
            foreach (Bar bar in bars)
            {
                if (bar.isDrawn == false) //bar is not drawn yet
                {
                    List<int> noteLengths = bar.getNoteLengths();
                    int barLength = bar.getBarLength(noteLengths);
                    Dictionary<int, int> writtenLengths = bar.getWrittenLengthOfEachNote(barLength, noteLengths);
                    string[] outputOfBar = bar.stringOutput(writtenLengths, this.stringCount, barLength);

                    if (output[0].Length + outputOfBar[0].Length + 1 <= this.charsPerString)
                    {
                        for (int i = 0; i < stringCount; i++)
                        {
                            output[i] += "|";
                            output[i] += outputOfBar[i];
                            bar.isDrawn = true;
                        }
                    }
                }
            }

            return output;
        }

        public string[] getSheetText()
        {
            //Draw all the blocks. a block, then lines_between_blocks space, then the next block

            List<string> output = new List<string>();
            while (areBarsDrawn() == false)
            {
                foreach (string instrumentString in getBlockText())
                {
                    output.Add(instrumentString + "|");
                }
                if (areBarsDrawn() == false)
                {
                    for (int i = 0; i < linesBetweenBlocks; i++)
                    {
                        output.Add("");
                    }
                }
            }

            return output.ToArray();
        }

        public bool areBarsDrawn()
        {
            foreach (Bar bar in bars)
            {
                if (bar.isDrawn == false)
                {
                    return false;
                }
            }
            return true;
        }

        public void addBar(int timeSignatureUpside, int timeSignatureDownside)
        {
            bars.Add(new Bar(timeSignatureUpside, timeSignatureDownside, this.mainWindow, false));
        }
    }
}