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
    public partial class Main : Form
    {
        int strings;
        int height;

        public Main()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bTuning_Click(object sender, EventArgs e)
        {
            Tuning TuningO = new Tuning();

            //strings = Convert.ToInt16(cbStrings.Text);
            //height = (strings * 30) + 35;
            //TuningO.Height = height;
            //TuningO.Width = 300;

            TuningO.Show();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Bar Testbar = new Bar(4, 4);
            tbWorkspace.Lines = Testbar.test_output();
        }
    }
}
