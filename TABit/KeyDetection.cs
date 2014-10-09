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
        private string ToWrite;

        //http://www.java2s.com/Code/CSharp/Event/Altkeypressed.htm
        //http://www.cambiaresearch.com/articles/15/javascript-char-codes-key-codes

        private string textBox1_KeyDown(object sender, KeyEventArgs e)
        {

            if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
            {
                if (e.KeyCode == Keys.Back && e.Shift)
                {
                    ToWrite = e.KeyCode.ToString();
                    return ToWrite;
                }
            }
            else
            {
                int caseSwitch = e.KeyValue;

                switch (caseSwitch)
                {

                    case (int)Keys.Escape:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;



                    case (int)Keys.F1:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                        
                    case (int)Keys.F2:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.F3:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.F4:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;



                    case (int)Keys.D1:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.D2:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D3:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D4:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D5:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D6:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D7:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D8:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D9:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.D0:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.NumPad1:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.NumPad2:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad3:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad4:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad5:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad6:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad7:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad8:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad9:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.NumPad0:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                          
              
        
                    case (int)Keys.Back:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                         
                 
      
                    case (int)Keys.Q:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.W:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.E:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.R:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.T:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.Z:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.Y:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.Up:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.Down:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                                                
                    case (int)Keys.X:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;


                                                
                    case (int)Keys.Space:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.Right:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                                       
         
                    case (int)Keys.Left:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                                       
         
                    case (int)Keys.PageUp:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                                                
                    case (int)Keys.PageDown:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;



                    case (int)Keys.Add:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;

                    case (int)Keys.Subtract:
                        ToWrite = e.KeyCode.ToString();
                        return ToWrite;
                }
            }
        }
    }
}
