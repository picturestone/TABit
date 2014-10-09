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

            //2-8
            //3-8

            //Tooltips
            toolTip1.SetToolTip(bNew, "New");
            toolTip1.SetToolTip(bSave, "Save");
            toolTip1.SetToolTip(bSaveTo, "Save To");
            toolTip1.SetToolTip(bOpen, "Open");
            toolTip1.SetToolTip(bPrint, "Print");
            toolTip1.SetToolTip(bSettings, "Settings");
            ////////////////////////////////////////////////

            cbStrings.SelectedIndex = 2;
            cbTimingUpside.SelectedIndex = 2;
            cbTimingDownside.SelectedIndex = 1;
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bTuning_Click(object sender, EventArgs e)
        {
            strings = Convert.ToInt16(cbStrings.Text);

            Tuning TuningO = new Tuning(strings);

            height = (strings * 30) + 80;
            TuningO.Height = height;
            TuningO.Width = 180;

            TuningO.Show();
            
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Bar Testbar = new Bar(4, 4);
            tbWorkspace.Lines = Testbar.test_output();
        }
    }
}
