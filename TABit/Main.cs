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
            toolTip1.SetToolTip(bTuning, "Tuning Settings");
            toolTip1.SetToolTip(bSettings, "Settings");

            toolTip1.SetToolTip(bFull, "1/1");
            toolTip1.SetToolTip(bHalf, "1/2");
            toolTip1.SetToolTip(bQuarter, "1/4");
            toolTip1.SetToolTip(bEight, "1/8");
            toolTip1.SetToolTip(bSixteenth, "1/16");
            toolTip1.SetToolTip(b32, "1/32");
            toolTip1.SetToolTip(bTriol, "Triol");
            toolTip1.SetToolTip(bQuintol, "Quintol");

            toolTip1.SetToolTip(bRelease, "Release");
            toolTip1.SetToolTip(bHammerOn, "Hammer On");
            toolTip1.SetToolTip(bPullOff, "Pull Off");
            toolTip1.SetToolTip(bBend, "Bend");
            toolTip1.SetToolTip(bTap, "Tap");
            toolTip1.SetToolTip(bVibrate, "Vibrate");
            toolTip1.SetToolTip(bSlideUp, "Slide Up");
            toolTip1.SetToolTip(bSlideDown, "Slide Down");
            toolTip1.SetToolTip(bPM, "PM");
            ////////////////////////////////////////////////

            cbStrings.SelectedIndex = 2;
            cbTimingUpside.SelectedIndex = 2;
            cbTimingDownside.SelectedIndex = 1;


            tbWorkspace.KeyDown += new KeyEventHandler(tbWorkspace_KeyDown);
  
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbWorkspace_KeyDown(object sender, KeyEventArgs e)
        {
            string ToWrite = KeyDetection.Detection(sender,e);
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
