using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class ChooseLineAction : KeyAction
    {
        public int ToWrite;
        public int Times = 0;

        public ChooseLineAction(int ToWrite) 
        {
            this.ToWrite = ToWrite;
        }


        public void doKeyAction(TextBox box)
        {
            var currentLine = box.GetLineFromCharIndex(box.SelectionStart);

            //int Blocklength = lines_between_blocks + string_count;


            //int currentBlock = Math.Ceiling(currentLine/Blocklength);

            //int CurrentPositionInBlock = Convert.ToInt32(currentLine - (Math.Floor(Convert.ToDecimal(currentLine/Blocklength)) *Blocklength));

         

            if (ToWrite == 33)  //Line Up
            {
                //Times = Blocklength;                 
            }
            else if(ToWrite == 34)   //Line Down
            {
                //Times = -Blocklength;
            }
     


            //if (CurrentPositionInBlock >= Linenumber)
            //{
            //    int DifLines = CurrentPositionInBlock - string_count;
            //    if (Times > 0)
            //    {
            //        Times = Times + DifLines;
            //    }
            //    else
            //    {
            //        Times = Times - DifLines;
            //    }
            //}
            //else
            //{
                if (Times > 0)
                {
                    for (int i = 0; i != Times; i++)
                    {
                        doUp(box);
                    }
                }
                else
                {
                    for (int i = 0; i != Times; i--)
                    {
                        doDown(box);
                    }
                }
            //}

        }

        public void doUp(TextBox box)
        {
            SendKeys.Send("{UP}");
        }
        public void doDown(TextBox box)
        {
            SendKeys.Send("{DOWN}");
        
        }
    }
}
