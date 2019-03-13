namespace DMS
{
    partial class QuickUpload
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.metroComboBox2 = new MetroFramework.Controls.MetroComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.metroComboBox1 = new MetroFramework.Controls.MetroComboBox();
            this.metroButton2 = new MetroFramework.Controls.MetroButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.metroComboBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.metroComboBox1);
            this.groupBox1.Location = new System.Drawing.Point(10, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 114);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File\'s Details";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 41);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Departmment";
            // 
            // metroComboBox2
            // 
            this.metroComboBox2.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.metroComboBox2.FormattingEnabled = true;
            this.metroComboBox2.ItemHeight = 21;
            this.metroComboBox2.Location = new System.Drawing.Point(9, 62);
            this.metroComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.metroComboBox2.Name = "metroComboBox2";
            this.metroComboBox2.PromptText = "Select A Department";
            this.metroComboBox2.Size = new System.Drawing.Size(236, 27);
            this.metroComboBox2.TabIndex = 1;
            this.metroComboBox2.UseSelectable = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 41);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "File Category";
            // 
            // metroComboBox1
            // 
            this.metroComboBox1.FontSize = MetroFramework.MetroComboBoxSize.Small;
            this.metroComboBox1.FormattingEnabled = true;
            this.metroComboBox1.ItemHeight = 21;
            this.metroComboBox1.Location = new System.Drawing.Point(282, 62);
            this.metroComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.metroComboBox1.Name = "metroComboBox1";
            this.metroComboBox1.PromptText = "Select A File Category";
            this.metroComboBox1.Size = new System.Drawing.Size(236, 27);
            this.metroComboBox1.TabIndex = 2;
            this.metroComboBox1.UseSelectable = true;
            // 
            // metroButton2
            // 
            this.metroButton2.Location = new System.Drawing.Point(427, 215);
            this.metroButton2.Margin = new System.Windows.Forms.Padding(4);
            this.metroButton2.Name = "metroButton2";
            this.metroButton2.Size = new System.Drawing.Size(133, 30);
            this.metroButton2.TabIndex = 3;
            this.metroButton2.Text = "Browse For File";
            this.metroButton2.UseSelectable = true;
            this.metroButton2.Click += new System.EventHandler(this.metroButton2_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // QuickUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 269);
            this.Controls.Add(this.metroButton2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickUpload";
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Text = "Quick Upload";
            this.Load += new System.EventHandler(this.QuickUpload_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private MetroFramework.Controls.MetroComboBox metroComboBox2;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroComboBox metroComboBox1;
        private MetroFramework.Controls.MetroButton metroButton2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

    }
}