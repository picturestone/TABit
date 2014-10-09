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
    public partial class Tuning : Form
    {
        int rows;

        public Tuning(int strings)
        {
            
            InitializeComponent();


            rows = strings;

            TableLayoutPanel tlp = new TableLayoutPanel();
            tlp.RowCount = rows + 2;
            tlp.Dock = DockStyle.Fill;
            //tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlp.Margin = new System.Windows.Forms.Padding(0);

            tlp.ColumnCount = 2;
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));

            string LabelName;
            string CBName;
            string[] CBText = new string[] {"C","C#","D","D#","E","F","F#","G","G#","A","A#","B"};
            
            for (int i = 1; i <= rows; i++)
            {
                LabelName = "lRow" + i;
                CBName = "cbRow" + i;

                tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));

                //Label generieren
                Label Label = new Label();
                Label.Name = LabelName;
                Label.Anchor = AnchorStyles.Right;
                Label.TextAlign = ContentAlignment.MiddleRight;
                Label.Text = Convert.ToString(i+". String");

                tlp.Controls.Add(Label,0,i-1);
                /////////////////////////////////////

                //Comboboxes generieren
                ComboBox Combobox = new ComboBox();
                Combobox.Name = CBName;
                Combobox.Anchor = AnchorStyles.Left;
                Combobox.DropDownStyle = ComboBoxStyle.DropDownList;
                Combobox.Items.AddRange(CBText);
                Combobox.SelectedIndex = 0;
                Combobox.FlatStyle = FlatStyle.Flat;

                tlp.Controls.Add(Combobox, 1, i - 1);
                /////////////////////////////////////
            }

            //Abstand
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 10));

            //OK & Abbrechen
            tlp.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
            
            Button bCancel = new Button();
            bCancel.Dock = DockStyle.Fill;
            bCancel.Text = "Cancel";
            bCancel.Click += bCancel_Click;
            bCancel.FlatStyle = FlatStyle.Flat;
            bCancel.FlatAppearance.BorderColor = Color.DarkGray;

            tlp.Controls.Add(bCancel, 0, rows + 1);


            Button bSave = new Button();
            bSave.Dock = DockStyle.Fill;
            bSave.Text = "Save";
            bSave.Click += bSave_Click;
            bSave.FlatStyle = FlatStyle.Flat;
            bSave.FlatAppearance.BorderColor = Color.DarkGray;

            tlp.Controls.Add(bSave, 1, rows + 1);


            this.Controls.Add(tlp);

        }

        void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void bSave_Click(object sender, EventArgs e)
        {
            
        }
    }
}
