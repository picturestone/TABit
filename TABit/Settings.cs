using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace TABit
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();

            if(TABit.Properties.Settings.Default.SCharsUser == "")
            {
                tbChars.Text = TABit.Properties.Settings.Default.SCharsDefault;
            }
            else
            {
                tbChars.Text = TABit.Properties.Settings.Default.SCharsUser;
            }

            if(TABit.Properties.Settings.Default.SLinesUser == "")
            {
                tbLinesSpace.Text = TABit.Properties.Settings.Default.SLinesDefault;
            }
            else
            {
                tbLinesSpace.Text = TABit.Properties.Settings.Default.SLinesUser;
            }
        }

        private void tbChars_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbChars_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void bSave_Click(object sender, EventArgs e)
        {
            try
            {
                TABit.Properties.Settings.Default.SCharsUser = tbChars.Text;
                TABit.Properties.Settings.Default.SLinesUser = tbLinesSpace.Text;

                this.Close();
            }
            catch
            {
                
            }
        }

        private void bCancelSettings_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bCharsDefault_Click(object sender, EventArgs e)
        {
            tbChars.Text = TABit.Properties.Settings.Default.SCharsDefault;
            TABit.Properties.Settings.Default.SCharsUser = "";
        }

        private void bLinesDefault_Click(object sender, EventArgs e)
        {
            tbLinesSpace.Text = TABit.Properties.Settings.Default.SLinesDefault;
            TABit.Properties.Settings.Default.SLinesUser = "";
        }
    }
}
