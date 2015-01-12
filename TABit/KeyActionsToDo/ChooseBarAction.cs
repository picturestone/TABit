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
        //eigentlich den Takt wählen
        public int ToWrite;
        int Times;
        int maxChars;
        int BarLength;
        int Hit;
        int LastBar;
        Main main;

        public ChooseBarAction(int ToWrite, Main main) 
        {
            this.ToWrite = ToWrite;
            this.main = main;
        }


        public void doKeyAction(TextBox box)
        {

            //TODO Write Code for Barchoosing; Example for Choosing is in ChooseStringAction

            int CurrentPosition = box.SelectionStart;

            maxChars = Config.getCharsPerString();


            //BarLength = Config.getBarLenght();      from Bar (look up in Config)
            //Hit = BarLength/4;
            //LastBar


            int currentBar = Config.getBarWhereCursorIsIn(main);


            
            //int currentHit = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(CurrentPosition / Hit)));
            //int CurrentPositionInBar = Convert.ToInt32(CurrentPosition - (Math.Floor(Convert.ToDecimal(CurrentPosition/BarLength)) *BarLength));
            //int CurrentPositionInHit = Convert.ToInt32(CurrentPosition - (Math.Floor(Convert.ToDecimal(CurrentPosition / Hit)) * Hit));

            if (ToWrite == 112)    //First Bar
            {
                if (currentBar == 0)
                {
                    Times = 0;
                }
                else
                {
                    //Times = ;
                }
            }
            else if (ToWrite == 113)     //Previous Bar
            {
                if (currentBar == 0)
                {
                    Times = 0;
                }
                else
                {
                    //Times = ;
                }
            }
            else if (ToWrite == 114)    //Next Bar
            {
                //Times = ;
            }
            else if (ToWrite == 115)     //Last Bar
            {
                //Times = ;
            }

            if (Times >= 0)
            {
                for (int i =0; i!=Times;i++)
                {
                    doRight(box);
                }
            }
            else
            {
                for (int i = 0; i != Times; i--)
                {
                    doLeft(box);
                }
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
