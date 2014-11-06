using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TABit
{
    public partial class Main : Form
    {
        int strings;
        int height;

        public int currentLength;

        Tuning TuningO = null;
        Settings SettingsO = null;
        SaveFileDialog savetodialog;
        OpenFileDialog opendialog;
        PrintDialog printdialog;

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
            KeyActionDict.Add(8, new Actions.DeleteAction(8));     //Backslash
            KeyActionDict.Add(508, new Actions.DeleteAction(508));   //Shift + Backslash
            KeyActionDict.Add(81, new Actions.ChooseStringAction(81));    //q       
            KeyActionDict.Add(87, new Actions.ChooseStringAction(87));    //w 
            KeyActionDict.Add(69, new Actions.ChooseStringAction(69));    //e 
            KeyActionDict.Add(82, new Actions.ChooseStringAction(82));    //r
            KeyActionDict.Add(84, new Actions.ChooseStringAction(84));    //t  
            KeyActionDict.Add(90, new Actions.ChooseStringAction(90));    //z
            KeyActionDict.Add(89, new Actions.ChooseStringAction(89));    //y
            KeyActionDict.Add(88, new Actions.WriteNoteAction(88));    //x
            KeyActionDict.Add(33, new Actions.ChooseLineAction(33));    //bild auf
            KeyActionDict.Add(34, new Actions.ChooseLineAction(34));    //bild runter
            KeyActionDict.Add(38, null);    //Pfeil rauf
            KeyActionDict.Add(40, null);    //Pfeil runter
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
            KeyActionDict.Add(109, new Actions.ChooseSpeedAction("-",this));   //Minus Num
            KeyActionDict.Add(107, new Actions.ChooseSpeedAction("+",this));   //Plus Num

            #endregion


            currentLength = 1;
            showpicture();

            tbWorkspace.KeyDown += new KeyEventHandler(tbWorkspace_KeyDown);

            //SaveFileDialog
            savetodialog = new SaveFileDialog();
            savetodialog.InitialDirectory = @"C:\";
            savetodialog.Title = "Save to ...";
            savetodialog.DefaultExt = "txt";
            savetodialog.Filter = "Text files (*.txt)|*.txt";
            ///////////////////////////////////////////////
            
            //OpenDialog
            opendialog = new OpenFileDialog();
            opendialog.InitialDirectory = @"C:\";
            opendialog.Title = "Open ...";
            opendialog.DefaultExt = "txt";
            opendialog.Filter = "Text files (*.txt)|*.txt";
            ///////////////////////////////////////////////

            //PrintDialog
            printdialog = new PrintDialog();
            //printdialog.AllowSelection = true;
            printdialog.AllowSomePages = true;
            ///////////////////////////////////////////////
  
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
            Bar Testbar = new Bar(Convert.ToInt16(cbTimingUpside.Text), Convert.ToInt16(cbTimingDownside.Text), this);
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

        public void showpicture()
        {
            try
            {
                string filename = "_" + currentLength;
                pbNote.Image = new Bitmap((Image)Properties.Resources.ResourceManager.GetObject(filename));
                pbNote.Refresh();
            }
            catch
            {

            }
        }

        private void bSaveTo_Click(object sender, EventArgs e)
        {
            if (savetodialog.ShowDialog() == DialogResult.OK)
            {
                savetodialog.FileName = "";
                tbWorkspace.Text += "Saved";
            }
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            if (opendialog.ShowDialog() == DialogResult.OK)
            {
                //opendialog.FileName = "";
                tbWorkspace.Text += "Opened";

                using (StreamReader sr = new StreamReader(opendialog.FileName))
                {
                    while (sr.Peek() >= 0)
                    {
                        tbWorkspace.Text = "";
                        tbWorkspace.Text = sr.ReadToEnd();
                    }
                }
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            printdialog.ShowDialog();
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
