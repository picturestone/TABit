using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit
{
    public static class KeyDetection
    {

        //http://www.java2s.com/Code/CSharp/Event/Altkeypressed.htm
        //http://www.cambiaresearch.com/articles/15/javascript-char-codes-key-codes

        public static int Detection(object sender, KeyEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.KeyCode == Keys.Back && e.Shift)
                {
                    return e.KeyValue+500;
                }
            }
            else
            {

                return e.KeyValue;
               
                
            }
            throw new Exception("not defined");
        }
    }
}
