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
using System.Drawing.Printing;
using System.Configuration;

namespace TABit
{
    public partial class Main : Form
    {  
        int strings;
        int height;
        string savetopath;

        public int currentLength;

        Tuning TuningO = null;
        Settings SettingsO = null;
        SaveFileDialog savetodialog;
        OpenFileDialog opendialog;
        PrintDialog printdialog;
        public Sheet notesheet;

        public Dictionary<int, TABit.Actions.KeyAction> KeyActionDict;
       

        public Main()
        {
            

            InitializeComponent();


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
            KeyActionDict.Add(112, new Actions.ChooseBarAction(112));   //F1 
            KeyActionDict.Add(113, new Actions.ChooseBarAction(113));   //F2
            KeyActionDict.Add(114, new Actions.ChooseBarAction(114));   //F3
            KeyActionDict.Add(115, new Actions.ChooseBarAction(115));   //F4
            KeyActionDict.Add(49, new Actions.WriteNoteAction(49, currentLength, Convert.ToInt16(cbStrings.Text)));    //1 oben
            KeyActionDict.Add(50, new Actions.WriteNoteAction(50, currentLength, Convert.ToInt16(cbStrings.Text)));    //2 oben       
            KeyActionDict.Add(51, new Actions.WriteNoteAction(51, currentLength, Convert.ToInt16(cbStrings.Text)));    //3 oben   
            KeyActionDict.Add(52, new Actions.WriteNoteAction(52, currentLength, Convert.ToInt16(cbStrings.Text)));    //4 oben   
            KeyActionDict.Add(53, new Actions.WriteNoteAction(53, currentLength, Convert.ToInt16(cbStrings.Text)));    //5 oben
            KeyActionDict.Add(54, new Actions.WriteNoteAction(54, currentLength, Convert.ToInt16(cbStrings.Text)));    //6 oben   
            KeyActionDict.Add(55, new Actions.WriteNoteAction(55, currentLength, Convert.ToInt16(cbStrings.Text)));    //7 oben
            KeyActionDict.Add(56, new Actions.WriteNoteAction(56, currentLength, Convert.ToInt16(cbStrings.Text)));    //8 oben
            KeyActionDict.Add(57, new Actions.WriteNoteAction(57, currentLength, Convert.ToInt16(cbStrings.Text)));    //9 oben
            KeyActionDict.Add(48, new Actions.WriteNoteAction(48, currentLength, Convert.ToInt16(cbStrings.Text)));    //0 oben
            KeyActionDict.Add(8, new Actions.DeleteAction(8, Convert.ToInt16(cbStrings.Text)));     //Backslash
            KeyActionDict.Add(508, new Actions.DeleteAction(508, Convert.ToInt16(cbStrings.Text)));   //Shift + Backslash
            KeyActionDict.Add(81, new Actions.ChooseStringAction(81,Convert.ToInt16(cbStrings.Text)));    //q       
            KeyActionDict.Add(87, new Actions.ChooseStringAction(87,Convert.ToInt16(cbStrings.Text)));    //w 
            KeyActionDict.Add(69, new Actions.ChooseStringAction(69,Convert.ToInt16(cbStrings.Text)));    //e 
            KeyActionDict.Add(82, new Actions.ChooseStringAction(82,Convert.ToInt16(cbStrings.Text)));    //r
            KeyActionDict.Add(84, new Actions.ChooseStringAction(84,Convert.ToInt16(cbStrings.Text)));    //t  
            KeyActionDict.Add(90, new Actions.ChooseStringAction(90,Convert.ToInt16(cbStrings.Text)));    //z
            KeyActionDict.Add(89, new Actions.ChooseStringAction(89,Convert.ToInt16(cbStrings.Text)));    //y
            KeyActionDict.Add(88, new Actions.WriteNoteAction(88, currentLength, Convert.ToInt16(cbStrings.Text)));    //x
            KeyActionDict.Add(33, new Actions.ChooseLineAction(33, Convert.ToInt16(cbStrings.Text)));    //bild auf
            KeyActionDict.Add(34, new Actions.ChooseLineAction(34, Convert.ToInt16(cbStrings.Text)));    //bild runter
            KeyActionDict.Add(38, null);    //Pfeil rauf
            KeyActionDict.Add(40, null);    //Pfeil runter
            KeyActionDict.Add(37, new Actions.ChooseNoteAction(37));    //Pfeil links
            KeyActionDict.Add(39, new Actions.ChooseNoteAction(39));    //Pfeil rechts
            KeyActionDict.Add(32, new Actions.ChooseNoteAction(32));    //Space
            KeyActionDict.Add(97, new Actions.WriteNoteAction(97, currentLength, Convert.ToInt16(cbStrings.Text)));    //1 Num       
            KeyActionDict.Add(98, new Actions.WriteNoteAction(98, currentLength, Convert.ToInt16(cbStrings.Text)));    //2 Num 
            KeyActionDict.Add(99, new Actions.WriteNoteAction(99, currentLength, Convert.ToInt16(cbStrings.Text)));    //3 Num
            KeyActionDict.Add(100, new Actions.WriteNoteAction(100, currentLength, Convert.ToInt16(cbStrings.Text)));   //4 Num
            KeyActionDict.Add(101, new Actions.WriteNoteAction(101, currentLength, Convert.ToInt16(cbStrings.Text)));   //5 Num  
            KeyActionDict.Add(102, new Actions.WriteNoteAction(102, currentLength, Convert.ToInt16(cbStrings.Text)));   //6 Num
            KeyActionDict.Add(103, new Actions.WriteNoteAction(103, currentLength, Convert.ToInt16(cbStrings.Text)));   //7 Num
            KeyActionDict.Add(104, new Actions.WriteNoteAction(104, currentLength, Convert.ToInt16(cbStrings.Text)));   //8 Num
            KeyActionDict.Add(105, new Actions.WriteNoteAction(105, currentLength, Convert.ToInt16(cbStrings.Text)));   //9 Num
            KeyActionDict.Add(96, new Actions.WriteNoteAction(96, currentLength, Convert.ToInt16(cbStrings.Text)));    //0 Num
            KeyActionDict.Add(109, new Actions.ChooseSpeedAction("-",this));   //Minus Num
            KeyActionDict.Add(107, new Actions.ChooseSpeedAction("+",this));   //Plus Num

            #endregion


            currentLength = 1;
            showpicture();

            tbWorkspace.KeyDown += new KeyEventHandler(tbWorkspace_KeyDown);

            //SaveFileDialog
            savetodialog = new SaveFileDialog();
            savetodialog.Title = "Save to ...";
            savetodialog.DefaultExt = "txt";
            savetodialog.Filter = "Text files (*.txt)|*.txt";
            savetodialog.RestoreDirectory = true;
            ///////////////////////////////////////////////
            
            //OpenDialog
            opendialog = new OpenFileDialog();
            opendialog.Title = "Open ...";
            opendialog.DefaultExt = "txt";
            opendialog.Filter = "Text files (*.txt)|*.txt";
            opendialog.RestoreDirectory = true;
            ///////////////////////////////////////////////

            //PrintDialog
            printdialog = new PrintDialog();
            printdialog.AllowSelection = true;
            printdialog.AllowSomePages = true;
            ///////////////////////////////////////////////

            Block asdf = new Block();
            asdf.makeSpaceInBarsInBlock(3, 3);

            //Make a new Sheet
            notesheet = new Sheet(Convert.ToInt16(cbStrings.Text), Config.getCharsPerString(), Config.getLinesBetweenBlocks(), this);
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
            //notesheet.add_bar(    todo: use this function
            notesheet.addBar(Config.getTimingUpside(this), Config.getTimingDownside(this));
            notesheet.addBar(Config.getTimingUpside(this), Config.getTimingDownside(this));
            notesheet.addBar(Config.getTimingUpside(this), Config.getTimingDownside(this));
            tbWorkspace.Lines = notesheet.getSheetText();
            //Bar Testbar = new Bar(Convert.ToInt16(cbTimingUpside.Text), Convert.ToInt16(cbTimingDownside.Text), this, false);
            //tbWorkspace.Lines = Testbar.test_output();

            //dia Region isch uskommentiert. widr iha tua, wenn ihr den Button nöma zum test bruchan
            #region Save
            /*if (savetopath == null)
            {
             * //Verweis auf SaveTo-Methode von Save-To Button, da gleiche Funktion
                bSaveTo_Click(null,null);
            }
            else
            {
                try
                {
                    StreamWriter sw = new StreamWriter(savetopath);
                    sw.Write(tbWorkspace.Text);
                    sw.Close();

                    MessageBox.Show("Document saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {
                    MessageBox.Show("Error! Document not saved!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }*/
            #endregion
        }

        private void bSettings_Click(object sender, EventArgs e)
        {

            if (System.Windows.Forms.Application.OpenForms["Settings"] as Settings == null)
            {
                SettingsO = new Settings();
                try { SettingsO.Show(); } catch { }
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
                try
                {
                    StreamWriter sw = new StreamWriter(savetodialog.FileName);
                    savetopath = savetodialog.FileName;
                    sw.Write(tbWorkspace.Text);
                    sw.Close();

                    MessageBox.Show("Document saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception eSaveTo)
                {
                    MessageBox.Show("Error! Document not saved! \r\n\n" + eSaveTo, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                savetodialog.FileName = "";
            }
        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            try
            {
                if (opendialog.ShowDialog() == DialogResult.OK)
                {
                    //opendialog.FileName = "";

                    using (StreamReader sr = new StreamReader(opendialog.FileName))
                    {
                        if (sr.ReadToEnd() != "")
                        {
                            tbWorkspace.Text = "";
                            tbWorkspace.Text = sr.ReadToEnd();
                        }
                        else
                        {
                            MessageBox.Show("Document is empty", "Document empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception eOpen)
            {
                MessageBox.Show("Can't open selected document! \r\n\n" + eOpen, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bPrint_Click(object sender, EventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            string stringToPrint = tbWorkspace.Text;
            

            PrintDocument printdocument = new PrintDocument();
            printdocument.DocumentName = "Tabs";
            printdialog.Document = printdocument;
            


            printdocument.PrintPage += delegate(object sender1, PrintPageEventArgs e1)
            {
                e1.PageSettings.PaperSize = new PaperSize("a4", 827, 1169); //Größe A4 in 1/100 Zoll

                e1.Graphics.MeasureString(stringToPrint, this.Font, e1.MarginBounds.Size, StringFormat.GenericTypographic, out charactersOnPage, out linesPerPage);

                e1.Graphics.DrawString(stringToPrint, new Font("Courier New", 10), new SolidBrush(Color.Black), e1.MarginBounds, StringFormat.GenericTypographic);

                stringToPrint = stringToPrint.Substring(charactersOnPage);

                e1.HasMorePages = (stringToPrint.Length > 0);
                return;
            };

            try
            {
                if(printdialog.ShowDialog() == DialogResult.OK)
                {
                    printdocument.Print();
                }
       
            }
            catch (Exception ePrint)
            {
                MessageBox.Show("Could not print the document! \r\n\n" + ePrint, "Printing Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

        }

        private void bNew_Click(object sender, EventArgs e)
        {
            if (tbWorkspace.Text != "")
            {
                try
                {
                    DialogResult result = MessageBox.Show("Save file?", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        bSaveTo_Click(null, null);
                        tbWorkspace.Text = "";
                    }
                    else if (result == DialogResult.No)
                    {
                        tbWorkspace.Text = "";
                    }
                }
                catch (Exception eNew)
                {
                    MessageBox.Show("Could not load a new document! \r\n\n" + eNew, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
