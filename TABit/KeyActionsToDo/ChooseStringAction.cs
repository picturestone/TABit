using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class ChooseStringAction :KeyAction
    {
        public int ToWrite;
        public int Times = 0;
        public int strings;
        int linesBetween;
        int LineLength;

        public ChooseStringAction(int ToWrite, int strings) 
        {
            this.ToWrite = ToWrite;
            this.strings = strings;
        }


        public void doKeyAction(TextBox box)
        {
            //if (TABit.Properties.Settings.Default.SCharsUser =="")
            //{
            //    int LineLength = Convert.ToInt32(TABit.Properties.Settings.Default.SCharsDefault);
            //}
            //else
            //{

            //}

            //var currentLine = box.GetLineFromCharIndex(box.SelectionStart);

            //if (TABit.Properties.Settings.Default.SLinesUser == "")
            //{
            //    linesBetween = Convert.ToInt32(TABit.Properties.Settings.Default.SLinesUser);
            //}
            //else
            //{
            //    linesBetween = Convert.ToInt32(TABit.Properties.Settings.Default.SLinesDefault);
            //}

            //int Blocklength = linesBetween + strings;


            //int currentBlock = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(currentLine/Blocklength)));

            //int CurrentPositionInBlock = Convert.ToInt32(currentLine - (Math.Floor(Convert.ToDecimal(currentLine/Blocklength)) *Blocklength));

         

            //if (ToWrite == 81)
            //{
            //    Times = CurrentPositionInBlock - 1;   //1, weil es q ist (String 1)                        
            //}
            //else if(ToWrite == 87)
            //{
            //    Times = CurrentPositionInBlock - 2;
            //}
            //else if (ToWrite ==69)
            //{
            //    Times = CurrentPositionInBlock - 3;
            //}
            //else if (ToWrite == 82)
            //{
            //    Times = CurrentPositionInBlock - 4;
            //}
            //else if (ToWrite == 64)
            //{
            //    Times = CurrentPositionInBlock - 5;
            //}
            //else if (ToWrite == 89 || ToWrite == 90)
            //{
            //    Times = CurrentPositionInBlock - 6;
            //}


            //if (CurrentPositionInBlock >= strings)
            //{
            //    int DifLines = CurrentPositionInBlock - strings;
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
            //    if (Times > 0)
            //    {
            //        for (int i = 0; i != Times; i++)
            //        {
            //            doUp(box);
            //        }
            //    }
            //    else
            //    {
            //        for (int i = 0; i != Times; i--)
            //        {
            //            doDown(box);
            //        }
            //    }
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