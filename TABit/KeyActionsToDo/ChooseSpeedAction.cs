using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class ChooseSpeedAction : KeyAction
    {
        private int currentLength;
        private string direction;
        private int[] lengthArray;

        public ChooseSpeedAction(int currentLength,string direction) 
        {
            lengthArray = new int[]{1,2,3,4,5,6,8,10,12,16,20,24,32};
          
            
            this.currentLength = currentLength;
            this.direction = direction;
        }


        public void doKeyAction(TextBox box)
        {
            int currentIndex = Array.IndexOf(lengthArray, currentLength);

            if (direction == "-")
            {
                
                try
                {
                    int newLength = lengthArray.ElementAt(currentIndex - 1);
                }

                catch{}
            }
            else if (direction == "+")
            {
                int newLength = lengthArray.ElementAt(currentIndex + 1);
            }
            else { }
            
        }
    }
}
