using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class DeleteAction :KeyAction
    {
        int ToWrite;
        int BarLength;
        int strings;
        List<int[]>Positions;
        int ToBarRight;
        int ToBarLeft;

        public DeleteAction(int ToWrite, int strings) 
        {
            this.ToWrite = ToWrite;
            this.strings = strings;
            Positions = new List<int[]>();
        }


        public void doKeyAction(TextBox box)
        {
            int cursorPosition = box.SelectionStart;
            ////BarLength = Config.getBarLenght();
            //int currentBar = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(cursorPosition / BarLength)));
            //int CurrentPositionInBar = Convert.ToInt32(cursorPosition - (Math.Floor(Convert.ToDecimal(cursorPosition/BarLength)) *BarLength));

            if (ToWrite == 8)
            {

               if (cursorPosition > 0)
                {
                    box.Text = box.Text.Substring(0, cursorPosition - 1) + box.Text.Substring(cursorPosition);
                    box.SelectionStart = cursorPosition - 1;
                }

            }
            else
            {
            //    for (int i = 0; i != strings; i++)
            //    {
            //        //ToBarRight = BarLength - CurrentPositionInBar;
            //        //ToBarLeft = CurrentPositionInBar;
            //        int[]thePosition = new int[2];
            //        thePosition[0] = ToBarLeft;
            //        thePosition[1] = ToBarRight;

            //        Positions.Add(thePosition);

                    
            //        //box.Select(cursorPosition-ToBarLeft,CurrentPositionInBar+ToBarRight);
            //        //box.SelectedText = "";

            //        doDown(box);
            //        cursorPosition = box.SelectionStart;
                    //currentBar = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(cursorPosition / BarLength)));
                    //int CurrentPositionInBar = Convert.ToInt32(cursorPosition - (Math.Floor(Convert.ToDecimal(cursorPosition/BarLength)) *BarLength));
                //}
                box.Text = "Chord is deleted ;)";
            }
        }
        public void doDown(TextBox box)
        {
            SendKeys.Send("{DOWN}");
        }
    }
}
