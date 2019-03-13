namespace DMS
{
    partial class MDI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.addMoreCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMoreDepartmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.documentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupCurrentDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restoreDatabaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.documentToolStripMenuItem,
            this.backupRestoreToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.activateToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1223, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem5,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fileToolStripMenuItem.Image")));
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(64, 24);
            this.fileToolStripMenuItem.Text = "File";
            this.fileToolStripMenuItem.Click += new System.EventHandler(this.ledgerToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem1.Image")));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 26);
            this.toolStripMenuItem1.Text = "Clear Cache";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem5.Image")));
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.toolStripMenuItem5.Size = new System.Drawing.Size(186, 26);
            this.toolStripMenuItem5.Text = "Log-out";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeyDisplayString = "Ctrl+X";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(186, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripMenuItem4,
            this.addMoreCategoryToolStripMenuItem,
            this.addMoreDepartmentToolStripMenuItem});
            this.adminToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("adminToolStripMenuItem.Image")));
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem6.Image")));
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.toolStripMenuItem6.Size = new System.Drawing.Size(288, 26);
            this.toolStripMenuItem6.Text = "Add User";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem4.Image")));
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.toolStripMenuItem4.Size = new System.Drawing.Size(288, 26);
            this.toolStripMenuItem4.Text = "View/Edit User Details";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // addMoreCategoryToolStripMenuItem
            // 
            this.addMoreCategoryToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addMoreCategoryToolStripMenuItem.Image")));
            this.addMoreCategoryToolStripMenuItem.Name = "addMoreCategoryToolStripMenuItem";
            this.addMoreCategoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.addMoreCategoryToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.addMoreCategoryToolStripMenuItem.Text = "Add More Category";
            this.addMoreCategoryToolStripMenuItem.Click += new System.EventHandler(this.addMoreCategoryToolStripMenuItem_Click);
            // 
            // addMoreDepartmentToolStripMenuItem
            // 
            this.addMoreDepartmentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addMoreDepartmentToolStripMenuItem.Image")));
            this.addMoreDepartmentToolStripMenuItem.Name = "addMoreDepartmentToolStripMenuItem";
            this.addMoreDepartmentToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.addMoreDepartmentToolStripMenuItem.Size = new System.Drawing.Size(288, 26);
            this.addMoreDepartmentToolStripMenuItem.Text = "Add More Department";
            this.addMoreDepartmentToolStripMenuItem.Click += new System.EventHandler(this.addMoreDepartmentToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("reportToolStripMenuItem.Image")));
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // documentToolStripMenuItem
            // 
            this.documentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quickUploadToolStripMenuItem,
            this.scanUploadToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.documentToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("documentToolStripMenuItem.Image")));
            this.documentToolStripMenuItem.Name = "documentToolStripMenuItem";
            this.documentToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.documentToolStripMenuItem.Text = "Documents";
            // 
            // quickUploadToolStripMenuItem
            // 
            this.quickUploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("quickUploadToolStripMenuItem.Image")));
            this.quickUploadToolStripMenuItem.Name = "quickUploadToolStripMenuItem";
            this.quickUploadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.quickUploadToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.quickUploadToolStripMenuItem.Text = "Quick Upload";
            this.quickUploadToolStripMenuItem.Click += new System.EventHandler(this.quickUploadToolStripMenuItem_Click);
            // 
            // scanUploadToolStripMenuItem
            // 
            this.scanUploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("scanUploadToolStripMenuItem.Image")));
            this.scanUploadToolStripMenuItem.Name = "scanUploadToolStripMenuItem";
            this.scanUploadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.scanUploadToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.scanUploadToolStripMenuItem.Text = "Scan && Upload";
            this.scanUploadToolStripMenuItem.Click += new System.EventHandler(this.scanUploadToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("searchToolStripMenuItem.Image")));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // backupRestoreToolStripMenuItem
            // 
            this.backupRestoreToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backupCurrentDatabaseToolStripMenuItem,
            this.restoreDatabaseToolStripMenuItem});
            this.backupRestoreToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backupRestoreToolStripMenuItem.Image")));
            this.backupRestoreToolStripMenuItem.Name = "backupRestoreToolStripMenuItem";
            this.backupRestoreToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.backupRestoreToolStripMenuItem.Text = "Backup and Restore";
            // 
            // backupCurrentDatabaseToolStripMenuItem
            // 
            this.backupCurrentDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backupCurrentDatabaseToolStripMenuItem.Image")));
            this.backupCurrentDatabaseToolStripMenuItem.Name = "backupCurrentDatabaseToolStripMenuItem";
            this.backupCurrentDatabaseToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.backupCurrentDatabaseToolStripMenuItem.Text = "Backup Current Database";
            this.backupCurrentDatabaseToolStripMenuItem.Click += new System.EventHandler(this.backupCurrentDatabaseToolStripMenuItem_Click);
            // 
            // restoreDatabaseToolStripMenuItem
            // 
            this.restoreDatabaseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("restoreDatabaseToolStripMenuItem.Image")));
            this.restoreDatabaseToolStripMenuItem.Name = "restoreDatabaseToolStripMenuItem";
            this.restoreDatabaseToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.restoreDatabaseToolStripMenuItem.Text = "Restore Database";
            this.restoreDatabaseToolStripMenuItem.Click += new System.EventHandler(this.restoreDatabaseToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("settingToolStripMenuItem.Image")));
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.settingToolStripMenuItem.Text = "Settings";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("activateToolStripMenuItem.Image")));
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(150, 24);
            this.activateToolStripMenuItem.Text = "Activate Product";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripMenuItem.Image")));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(73, 24);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("logoutToolStripMenuItem.Image")));
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(88, 24);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroLabel1.Location = new System.Drawing.Point(20, 708);
            this.metroLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(1223, 23);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Powered By : Mehta Techno Private Limited";
            this.metroLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MDI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1263, 751);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDI";
            this.Resizable = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "DMS";
            this.TransparencyKey = System.Drawing.Color.Empty;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDI_FormClosing);
            this.Load += new System.EventHandler(this.MDI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupRestoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupCurrentDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restoreDatabaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem documentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanUploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addMoreCategoryToolStripMenuItem;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ToolStripMenuItem addMoreDepartmentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}