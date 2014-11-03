using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class ChooseNoteAction :KeyAction 
    {
        private int Pressed;

        public ChooseNoteAction(int Pressed) 
        {
            this.Pressed = Pressed;
        }


        public void doKeyAction(TextBox box)
        {
            int CurrentPosition = box.SelectionStart;

            KeysConverter kc = new KeysConverter();

            string PressedKey = kc.ConvertToString(Pressed);

            if (PressedKey == "Right" || PressedKey== "Space")
            {
                box.Select(CurrentPosition, 0);
            }
            else if (PressedKey == "Left")
            {
                box.Select(CurrentPosition, 0);
            }
            
        }
    }
}
