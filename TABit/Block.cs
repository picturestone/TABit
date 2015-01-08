using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    public class Block
    {
        public List<Bar> bars;
        public Block nextBlock;
        public List<Bar> barsInBlock;

        public Block()
        {
            barsInBlock = new List<Bar>();

            
            //Testing of bars
            //barsInBlock.Add("zero");
            //barsInBlock.Add("one");
            //barsInBlock.Add("two");
            //barsInBlock.Add("three");
            //barsInBlock.Add("four");
            //barsInBlock.Add("five");
            //barsInBlock[3] = null;
        }

        public void addBar(Bar bar, int addAt)
        {
            makeSpaceInBarsInBlock(addAt, addAt);
            barsInBlock[addAt] = bar;
        }

        public String[] stringOutput(int charsPerString, int numberOfStrings)
        {
            //TODO: At the beginning a | sign must be added. how does this affect the rest of the algorithm?
            String[] output = new string[numberOfStrings];

            for (int i = 0; i < numberOfStrings; i++)
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
                    string[] outputOfBar = bar.stringOutput(writtenLengths, numberOfStrings, barLength);

                    if (output[0].Length + outputOfBar[0].Length + 1 <= charsPerString)
                    {
                        for (int i = 0; i < numberOfStrings; i++)
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

        public void makeSpaceInBarsInBlock(int makeSpaceAtNumberRecursive, int makeSpaceAtNumber)
        {
            if (barsInBlock[makeSpaceAtNumber] == null)
            {
                return;
            }
            else if (makeSpaceAtNumberRecursive == barsInBlock.Count()-1)
            {
                barsInBlock.Add(barsInBlock[makeSpaceAtNumberRecursive]);
                barsInBlock[makeSpaceAtNumberRecursive] = null;
                makeSpaceInBarsInBlock(makeSpaceAtNumberRecursive, makeSpaceAtNumber);
            }
            else if (barsInBlock[makeSpaceAtNumberRecursive] == null)
            {
                barsInBlock[makeSpaceAtNumberRecursive] = barsInBlock[makeSpaceAtNumberRecursive - 1];
                barsInBlock[makeSpaceAtNumberRecursive - 1] = null;
                makeSpaceInBarsInBlock(makeSpaceAtNumberRecursive - 1, makeSpaceAtNumber);
            }
            else
            {
                makeSpaceInBarsInBlock(makeSpaceAtNumberRecursive + 1, makeSpaceAtNumber);
            }
        }
    }
}