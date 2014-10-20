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
            //                              0    1    2   3    4   5   6    7   8    9   10   11
            int i = 0;

            Dictionary<int, int[]> stringNames = new Dictionary<int, int[]> () 
            {
                { 4, new int[] {7, 2, 9, 4}},
                { 5, new int[] {4, 11, 7, 2, 9}},
                { 6, new int[] {4, 11, 7, 2, 9, 4}},
                { 7, new int[] {4, 11, 7, 2, 9, 4, 11}},
                { 8, new int[] {4, 11, 7, 2, 9, 4, 11, 6}}
            };

            for (i = 1; i <= rows; i++)
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
                Label.Font = new Font("Century Gothic", 12);


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
                Combobox.Font = new Font("Century Gothic", 12);

                Combobox.SelectedIndex = stringNames[rows][i-1];

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
            bCancel.Font = new Font("Century Gothic", 12);
            bCancel.BackColor = SystemColors.Control;

            tlp.Controls.Add(bCancel, 1, rows + 1);


            Button bSave = new Button();
            bSave.Dock = DockStyle.Fill;
            bSave.Text = "Save";
            bSave.Click += bSave_Click;
            bSave.FlatStyle = FlatStyle.Flat;
            bSave.FlatAppearance.BorderColor = Color.DarkGray;
            bSave.Font = new Font("Century Gothic", 12);
            bSave.BackColor = SystemColors.Control;

            tlp.Controls.Add(bSave, 0, rows + 1);


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
