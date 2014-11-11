using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class ChooseBarAction : KeyAction
    {

        public int ToWrite;
        int Times;

        public ChooseBarAction(int ToWrite) 
        {
            this.ToWrite = ToWrite;
        }


        public void doKeyAction(TextBox box)
        {
            int CurrentPosition = box.SelectionStart;

            //maxChars = Config.get_chars();
            //BarLength = Config.getBarLenght();
            //Hit = BarLength/4;

            //int currentBar = Convert.ToInt32(Math.Ceiling(CurrentPosition/BarLength));
            //int CurrentPositionInBar = Convert.ToInt32(CurrentPosition - (Math.Floor(Convert.ToDecimal(CurrentPosition/BarLength)) *BarLength));

            if (ToWrite == 112)  
            {
                //Times = ;
            }
            else if (ToWrite == 113)   
            {
                //Times = ;
            }
            else if (ToWrite == 114)   
            {
                //Times = ;
            }
            else if (ToWrite == 115)   
            {
                //Times = ;
            }
        }
        public void doLeft(TextBox box)
        {
            SendKeys.Send("{LEFT}");
        }
        public void doRight(TextBox box)
        {
            SendKeys.Send("{RIGHT}");

        }
    }
}
