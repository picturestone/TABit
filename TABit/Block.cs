using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TABit
{
    class Block
    {
        public Block nextBlock;
        public List<string> barsInBlock;

        public Block()
        {
            barsInBlock = new List<string>();
            barsInBlock.Add("zero");
            barsInBlock.Add("one");
            barsInBlock.Add("two");
            barsInBlock.Add("three");
            barsInBlock.Add("four");
            barsInBlock.Add("five");
        }

        public void addBar(Bar bar, int addAt)
        {
            
        }

        public void makeSpaceInBarsInBlock(int makeSpaceAtNumber)
        {
            if (makeSpaceAtNumber == barsInBlock.Count())
            {
                barsInBlock.Add(barsInBlock[makeSpaceAtNumber - 1]);
                barsInBlock[makeSpaceAtNumber - 1] = null;
            }
            else if (barsInBlock[makeSpaceAtNumber] == null)
            {
                barsInBlock[makeSpaceAtNumber] = barsInBlock[makeSpaceAtNumber - 1];
            }
            else
            {
                makeSpaceInBarsInBlock(makeSpaceAtNumber + 1);
            }
        }
    }
}
