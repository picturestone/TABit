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
        decimal linesBetween;
        int strings;

        public ChooseLineAction(int ToWrite, int strings) 
        {
            this.ToWrite = ToWrite;
            this.strings = strings;
        }


        public void doKeyAction(TextBox box)
        {
            //strings = Config.get_strings();

            var currentLine = box.GetLineFromCharIndex(box.SelectionStart)+1;

            linesBetween = Config.get_lines_between_blocks();     


            decimal Blocklength = linesBetween + strings;


            int CurrentPositionInBlock = Convert.ToInt32(currentLine - (Math.Floor(Convert.ToDecimal(currentLine/Blocklength)) *Blocklength));

         

            if (ToWrite == 33)  //Line Up
            {
                Times = Convert.ToInt32(Blocklength);                 
            }
            else if(ToWrite == 34)   //Line Down
            {
                Times = Convert.ToInt32(-Blocklength);
            }



            if (CurrentPositionInBlock >= strings)
            {
                int DifLines = CurrentPositionInBlock - strings;
                if (Times > 0)
                {
                    Times = Times + DifLines;
                    for (int i = 0; i != Times; i++)
                    {
                        doUp(box);
                    }
                }
                else
                {
                    Times = Times - DifLines;
                    for (int i = 0; i != Times; i--)
                    {
                        doDown(box);
                    }
                }
            }
            else
            {
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
            }

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
