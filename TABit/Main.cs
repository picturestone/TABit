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

       

        Tuning TuningO = null;
        Settings SettingsO = null;

        public Dictionary<int, TABit.Actions.KeyAction> KeyActionDict;
       

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
            toolTip1.SetToolTip(bPM, "Palm Muting");
            ////////////////////////////////////////////////

            cbStrings.SelectedIndex = 2;
            cbTimingUpside.SelectedIndex = 2;
            cbTimingDownside.SelectedIndex = 1;

            KeyActionDict = new Dictionary<int, Actions.KeyAction>();

            #region KeyActionDic
            KeyActionDict.Add(27,new Actions.OpenMenueAction());     //Escape
            KeyActionDict.Add(112, new Actions.ChooseBarAction());   //F1 
            KeyActionDict.Add(113, new Actions.ChooseBarAction());   //F2
            KeyActionDict.Add(114, new Actions.ChooseBarAction());   //F3
            KeyActionDict.Add(115, new Actions.ChooseBarAction());   //F4
            KeyActionDict.Add(49, new Actions.WriteNoteAction(49));    //1 oben
            KeyActionDict.Add(50, new Actions.WriteNoteAction(50));    //2 oben       
            KeyActionDict.Add(51, new Actions.WriteNoteAction(51));    //3 oben   
            KeyActionDict.Add(52, new Actions.WriteNoteAction(52));    //4 oben   
            KeyActionDict.Add(53, new Actions.WriteNoteAction(53));    //5 oben
            KeyActionDict.Add(54, new Actions.WriteNoteAction(54));    //6 oben   
            KeyActionDict.Add(55, new Actions.WriteNoteAction(55));    //7 oben
            KeyActionDict.Add(56, new Actions.WriteNoteAction(56));    //8 oben
            KeyActionDict.Add(57, new Actions.WriteNoteAction(57));    //9 oben
            KeyActionDict.Add(48, new Actions.WriteNoteAction(48));    //0 oben
            KeyActionDict.Add(8, new Actions.DeleteAction());     //Backslash
            KeyActionDict.Add(508, new Actions.DeleteAction());   //Shift + Backslash
            KeyActionDict.Add(81, new Actions.ChooseStringAction());    //q       
            KeyActionDict.Add(87, new Actions.ChooseStringAction());    //w 
            KeyActionDict.Add(69, new Actions.ChooseStringAction());    //e 
            KeyActionDict.Add(82, new Actions.ChooseStringAction());    //r
            KeyActionDict.Add(84, new Actions.ChooseStringAction());    //t  
            KeyActionDict.Add(90, new Actions.ChooseStringAction());    //z
            KeyActionDict.Add(89, new Actions.ChooseStringAction());    //y
            KeyActionDict.Add(88, new Actions.WriteNoteAction(88));    //x
            KeyActionDict.Add(33, new Actions.ChooseLineAction());    //bild auf
            KeyActionDict.Add(34, new Actions.ChooseLineAction());    //bild runter
            KeyActionDict.Add(38, new Actions.ChooseStringAction());    //Pfeil rauf
            KeyActionDict.Add(40, new Actions.ChooseStringAction());    //Pfeil runter
            KeyActionDict.Add(37, new Actions.ChooseNoteAction(37));    //Pfeil links
            KeyActionDict.Add(39, new Actions.ChooseNoteAction(39));    //Pfeil rechts
            KeyActionDict.Add(32, new Actions.ChooseNoteAction(32));    //Space
            KeyActionDict.Add(97, new Actions.WriteNoteAction(97));    //1 Num       
            KeyActionDict.Add(98, new Actions.WriteNoteAction(98));    //2 Num 
            KeyActionDict.Add(99, new Actions.WriteNoteAction(99));    //3 Num
            KeyActionDict.Add(100, new Actions.WriteNoteAction(100));   //4 Num
            KeyActionDict.Add(101, new Actions.WriteNoteAction(101));   //5 Num  
            KeyActionDict.Add(102, new Actions.WriteNoteAction(102));   //6 Num
            KeyActionDict.Add(103, new Actions.WriteNoteAction(103));   //7 Num
            KeyActionDict.Add(104, new Actions.WriteNoteAction(104));   //8 Num
            KeyActionDict.Add(105, new Actions.WriteNoteAction(105));   //9 Num
            KeyActionDict.Add(96, new Actions.WriteNoteAction(96));    //0 Num
            KeyActionDict.Add(109, new Actions.ChooseSpeedAction(16,"-"));   //Minus Num
            KeyActionDict.Add(107, new Actions.ChooseSpeedAction(16,"+"));   //Plus Num

            #endregion

            

            tbWorkspace.KeyDown += new KeyEventHandler(tbWorkspace_KeyDown);
  
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbWorkspace_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int KeyNumberGot = KeyDetection.Detection(sender, e);
                Actions.KeyAction action;
                this.KeyActionDict.TryGetValue(KeyNumberGot,out action);
                action.doKeyAction(tbWorkspace);

            }
            catch
            {

            }

        }
       

        private void bTuning_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Tuning"] as Tuning == null)
            {
                strings = Convert.ToInt16(cbStrings.Text);

                TuningO = new Tuning(strings);

                height = (strings * 30) + 80;
                TuningO.Height = height;
                TuningO.Width = 180;

                TuningO.Show();
            }
            else
            {
                TuningO.TopMost = true;
            }
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Bar Testbar = new Bar(4, 4);
            tbWorkspace.Lines = Testbar.test_output();
        }

        private void bSettings_Click(object sender, EventArgs e)
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
