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

        public WriteNoteAction(int ToWrite) 
        {
            this.ToWrite = ToWrite;
        }


        public void doKeyAction(TextBox box)
        {
            
            string Writting = ToWrite.ToString();

            
            KeysConverter kc = new KeysConverter();


                
            box.Text = box.Text.Insert(box.SelectionStart, kc.ConvertToString(ToWrite));
        }
    }
}
