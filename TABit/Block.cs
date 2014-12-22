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
            barsInBlock[3] = null;
        }

        public void addBar(Bar bar, int addAt)
        {
            
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