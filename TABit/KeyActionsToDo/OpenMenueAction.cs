using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TABit.Actions
{
    public class OpenMenueAction : KeyAction
    {
        Settings SettingsO;   
        public OpenMenueAction() 
        {

        }


        public void doKeyAction(TextBox box)
        {
            if (System.Windows.Forms.Application.OpenForms["Settings"] as Settings == null)
            {
                SettingsO = new Settings();
                SettingsO.Show();
            }
            else
            {
                SettingsO.TopMost = true;
            }
        }
    }
}
