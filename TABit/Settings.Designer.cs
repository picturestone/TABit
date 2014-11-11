namespace TABit
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.tbChars = new System.Windows.Forms.TextBox();
            this.bSaveSettings = new System.Windows.Forms.Button();
            this.bCancelSettings = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbLinesSpace = new System.Windows.Forms.TextBox();
            this.bCharsDefault = new System.Windows.Forms.Button();
            this.bLinesDefault = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(185, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chars per String:";
            // 
            // tbChars
            // 
            this.tbChars.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbChars.Location = new System.Drawing.Point(328, 137);
            this.tbChars.MaxLength = 3;
            this.tbChars.Name = "tbChars";
            this.tbChars.Size = new System.Drawing.Size(44, 27);
            this.tbChars.TabIndex = 1;
            this.tbChars.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbChars.TextChanged += new System.EventHandler(this.tbChars_TextChanged);
            this.tbChars.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbChars_KeyPress);
            // 
            // bSaveSettings
            // 
            this.bSaveSettings.BackColor = System.Drawing.SystemColors.Control;
            this.bSaveSettings.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.bSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bSaveSettings.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSaveSettings.Location = new System.Drawing.Point(438, 445);
            this.bSaveSettings.Name = "bSaveSettings";
            this.bSaveSettings.Size = new System.Drawing.Size(140, 40);
            this.bSaveSettings.TabIndex = 1;
            this.bSaveSettings.Text = "Save";
            this.bSaveSettings.UseVisualStyleBackColor = false;
            this.bSaveSettings.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancelSettings
            // 
            this.bCancelSettings.BackColor = System.Drawing.SystemColors.Control;
            this.bCancelSettings.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.bCancelSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCancelSettings.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancelSettings.Location = new System.Drawing.Point(584, 445);
            this.bCancelSettings.Name = "bCancelSettings";
            this.bCancelSettings.Size = new System.Drawing.Size(140, 40);
            this.bCancelSettings.TabIndex = 1;
            this.bCancelSettings.Text = "Cancel";
            this.bCancelSettings.UseVisualStyleBackColor = false;
            this.bCancelSettings.Click += new System.EventHandler(this.bCancelSettings_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(140, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lines  between blocks:";
            // 
            // tbLinesSpace
            // 
            this.tbLinesSpace.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLinesSpace.Location = new System.Drawing.Point(328, 196);
            this.tbLinesSpace.MaxLength = 3;
            this.tbLinesSpace.Name = "tbLinesSpace";
            this.tbLinesSpace.Size = new System.Drawing.Size(44, 27);
            this.tbLinesSpace.TabIndex = 5;
            this.tbLinesSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bCharsDefault
            // 
            this.bCharsDefault.BackColor = System.Drawing.SystemColors.Control;
            this.bCharsDefault.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.bCharsDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bCharsDefault.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCharsDefault.Location = new System.Drawing.Point(378, 137);
            this.bCharsDefault.Name = "bCharsDefault";
            this.bCharsDefault.Size = new System.Drawing.Size(80, 27);
            this.bCharsDefault.TabIndex = 6;
            this.bCharsDefault.Text = "Default";
            this.bCharsDefault.UseVisualStyleBackColor = false;
            this.bCharsDefault.Click += new System.EventHandler(this.bCharsDefault_Click);
            // 
            // bLinesDefault
            // 
            this.bLinesDefault.BackColor = System.Drawing.SystemColors.Control;
            this.bLinesDefault.FlatAppearance.BorderColor = System.Drawing.Color.DarkGray;
            this.bLinesDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bLinesDefault.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLinesDefault.Location = new System.Drawing.Point(378, 199);
            this.bLinesDefault.Name = "bLinesDefault";
            this.bLinesDefault.Size = new System.Drawing.Size(80, 27);
            this.bLinesDefault.TabIndex = 7;
            this.bLinesDefault.Text = "Default";
            this.bLinesDefault.UseVisualStyleBackColor = false;
            this.bLinesDefault.Click += new System.EventHandler(this.bLinesDefault_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(736, 497);
            this.Controls.Add(this.bLinesDefault);
            this.Controls.Add(this.bCharsDefault);
            this.Controls.Add(this.tbLinesSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bCancelSettings);
            this.Controls.Add(this.bSaveSettings);
            this.Controls.Add(this.tbChars);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Settings";
            this.Text = "TABit - Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbChars;
        private System.Windows.Forms.Button bSaveSettings;
        private System.Windows.Forms.Button bCancelSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbLinesSpace;
        private System.Windows.Forms.Button bCharsDefault;
        private System.Windows.Forms.Button bLinesDefault;
    }
}