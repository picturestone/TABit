using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class WriteNoteAction : KeyAction
    {
        private int ToWrite;
        int length;

        public WriteNoteAction(int ToWrite, int length) 
        {
            this.ToWrite = ToWrite;
            this.length = length;
        }


        public void doKeyAction(TextBox box)
        {
            
            
            KeysConverter kc = new KeysConverter();

            int CurrentPosition = box.SelectionStart;

            string Writting = kc.ConvertToString(ToWrite);
                
            box.Text = box.Text.Insert(box.SelectionStart, Writting);



            box.Select(CurrentPosition+Writting.Length , 0);
        }
    }
}
