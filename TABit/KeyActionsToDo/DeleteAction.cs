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

        public DeleteAction(int ToWrite) 
        {
            this.ToWrite = ToWrite;
        }


        public void doKeyAction(TextBox box)
        {


            if (ToWrite == 8)
            {

                int cursorPosition = box.SelectionStart;

                if (cursorPosition > 0)
                {
                    box.Text = box.Text.Substring(0, cursorPosition - 1) + box.Text.Substring(cursorPosition);
                    box.SelectionStart = cursorPosition - 1;
                }

            }
            else
            {
                box.Text = "Chord is deleted ;)";
            }
        }
    }
}
