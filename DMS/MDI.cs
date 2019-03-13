using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using Tulpep.NotificationWindow;
using MySql.Data.MySqlClient;
using System.IO;
using MetroFramework;

namespace DMS
{
    public partial class MDI : MetroForm
    {
        public static bool isloggedout = false;

        public MDI()
        {
            InitializeComponent();
        }

        private void MDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void ledgerToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        int isactivated()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from install_detail;";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                string product_status = reader2.GetString("product_status");
                if (product_status == "NOT-ACTIVATED")
                {
                    return 1; //not-activated
                }
                else
                {
                    return 0;

                }
            }
            return 0;
        }

       
        private void MDI_Load(object sender, EventArgs e)
        {
            //load_default_path();

            loadSettings();

            
            if (Program.isadmin == true)
            {
                //setting all menu for admin..........

                fileToolStripMenuItem.Enabled = true;
                adminToolStripMenuItem.Enabled = true;

                Form frm = (Form)this;
                MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];

               ToolStripMenuItem ti1 = (ToolStripMenuItem)ms.Items["adminToolStripMenuItem"];

               ti1.DropDownItems["toolStripMenuItem6"].Enabled = true;
               ti1.DropDownItems["toolStripMenuItem4"].Enabled = true;
               ti1.DropDownItems["addMoreCategoryToolStripMenuItem"].Enabled = true;
               ti1.DropDownItems["addMoreDepartmentToolStripMenuItem"].Enabled = true;
               

                documentToolStripMenuItem.Enabled = true;
                reportToolStripMenuItem.Enabled = true;
                backupRestoreToolStripMenuItem.Enabled = true;
                settingToolStripMenuItem.Enabled = true;

                if (isactivated() == 1)
                    activateToolStripMenuItem.Enabled = true;
                else
                    activateToolStripMenuItem.Enabled = false;

                helpToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Text = "Logout";

            }

            if (Program.isuser == true)
            {

                fileToolStripMenuItem.Enabled = true;
                //adminToolStripMenuItem.Enabled = false;

                Form frm = (Form)this;
                MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];


                //Admin
                ToolStripMenuItem t1 = (ToolStripMenuItem)ms.Items["adminToolStripMenuItem"];
                t1.DropDownItems["addMoreDepartmentToolStripMenuItem"].Enabled = false;
                //Databasebackup
                ToolStripMenuItem t2 = (ToolStripMenuItem)ms.Items["backupRestoreToolStripMenuItem"];
                        
                
                if(havePermissionToAddUser() == 1)
                    t1.DropDownItems["toolStripMenuItem6"].Enabled = true;
                else
                    t1.DropDownItems["toolStripMenuItem6"].Enabled = false;


                if (havePermissionToViewEditUser() == 1)
                    t1.DropDownItems["toolStripMenuItem4"].Enabled = true;
                else
                    t1.DropDownItems["toolStripMenuItem4"].Enabled = false;

                if (havePermissionToAddCategory() == 1)
                    t1.DropDownItems["addMoreCategoryToolStripMenuItem"].Enabled = true;
                else
                    t1.DropDownItems["addMoreCategoryToolStripMenuItem"].Enabled = false;



                if (havePermissionToBackup() == 1)
                    t2.Enabled = true;
                else
                    t2.Enabled = false;
                

                documentToolStripMenuItem.Enabled = true;
                reportToolStripMenuItem.Enabled = true;
                settingToolStripMenuItem.Enabled = true;

                if (isactivated() == 1)
                    activateToolStripMenuItem.Enabled = true;
                else
                    activateToolStripMenuItem.Enabled = false;

                helpToolStripMenuItem.Enabled = true;
                logoutToolStripMenuItem.Text = "Logout";


            }




        }

        private int havePermissionToBackup()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                string permmission = reader2.GetString("permission_database");
                if (permmission == "1")
                {
                    return 1; // eligible
                }
                else
                {
                    return 0;//not eligible

                }
            }
            return 0;
        }

        private int havePermissionToAddCategory()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                string permmission = reader2.GetString("permssion_add_file_category");
                if (permmission == "1")
                {
                    return 1; // eligible
                }
                else
                {
                    return 0;//not eligible

                }
            }
            return 0;
        }

        private int havePermissionToViewEditUser()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                string permmission = reader2.GetString("permission_edit_user");
                if (permmission == "1")
                {
                    return 1; // eligible
                }
                else
                {
                    return 0;//not eligible

                }
            }
            return 0;
        }

        int havePermissionToAddUser()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                string permmission = reader2.GetString("permission_create_user");
                if (permmission == "1")
                {
                    return 1; // eligible
                }
                else
                {
                    return 0;//not eligible

                }
            }
            return 0;
        }


        private void loadSettings()
        {

            this.Height = Properties.Settings.Default.ClientScreenHeight;
            this.Width = Properties.Settings.Default.ClientScreenWidth;

            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0: this.Style = MetroFramework.MetroColorStyle.Default; break;
                case 1: this.Style = MetroFramework.MetroColorStyle.Black; break;
                case 2: this.Style = MetroFramework.MetroColorStyle.White; break;
                case 3: this.Style = MetroFramework.MetroColorStyle.Silver; break;
                case 4: this.Style = MetroFramework.MetroColorStyle.Blue; break;
                case 5: this.Style = MetroFramework.MetroColorStyle.Green; break;
                case 6: this.Style = MetroFramework.MetroColorStyle.Lime; break;
                case 7: this.Style = MetroFramework.MetroColorStyle.Teal; break;
                case 8: this.Style = MetroFramework.MetroColorStyle.Orange; break;
                case 9: this.Style = MetroFramework.MetroColorStyle.Brown; break;
                case 10: this.Style = MetroFramework.MetroColorStyle.Pink; break;
                case 11: this.Style = MetroFramework.MetroColorStyle.Magenta; break;
                case 12: this.Style = MetroFramework.MetroColorStyle.Purple; break;
                case 13: this.Style = MetroFramework.MetroColorStyle.Red; break;
                case 14: this.Style = MetroFramework.MetroColorStyle.Yellow; break;
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isloggedout == true)
            {
                MDILoginForm lf = new MDILoginForm();
                lf.MdiParent = this;
                lf.Show();
            }
            else
            {
                if (!MdiChildren.Any() || MdiChildren.All(c => !c.Visible))
                {
                    // all child forms closed
                    logoutToolStripMenuItem.Text = "Login";
                    fileToolStripMenuItem.Enabled = false;
                    reportToolStripMenuItem.Enabled = false;
                    documentToolStripMenuItem.Enabled = false;
                    backupRestoreToolStripMenuItem.Enabled = false;
                    settingToolStripMenuItem.Enabled = false;
                    activateToolStripMenuItem.Enabled = false;
                    helpToolStripMenuItem.Enabled = false;
                    adminToolStripMenuItem.Enabled = false;

                    isloggedout = true;

                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.checked_checkbox_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nLogout Succesfully !";
                    popup.Popup();
                }
                else
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.delete_sign_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nPlease Close All Opened Form Fist Before Logout !";
                    popup.Popup();
                }
            }
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activation act = new Activation();
            act.ShowDialog();
        }

        private void scanUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanAndUpload dcb = new ScanAndUpload();
            dcb.MdiParent = this;
            dcb.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            set.MdiParent = this;
            set.Show();
        }

        private void addMoreCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory cat = new AddCategory();
            cat.MdiParent = this;
            cat.Show();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            Add_User adus = new Add_User();
            adus.MdiParent = this;
            adus.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            EditUser eu = new EditUser();
            eu.MdiParent = this;
            eu.Show();
        }

        private void addMoreDepartmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddDepartment ad = new AddDepartment();
            ad.MdiParent = this;
            ad.Show();
        }

        private void quickUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickUpload qu = new QuickUpload();
            qu.MdiParent = this;
            qu.Show();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Search s = new Search();
            s.MdiParent = this;
            s.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.IO.DirectoryInfo directory = new System.IO.DirectoryInfo(Path.GetTempPath());
                foreach (System.IO.FileInfo file in directory.GetFiles()) file.Delete();
                foreach (System.IO.DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
            }
            catch(Exception exex)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nSome of the files open in another process restart system and try again later !";
                popup.Popup();
            }
            
        }

        private void backupCurrentDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string defaultpath = Properties.Settings.Default.dbpath;
            if (MessageBox.Show("All the Data associated to Inventory Management System is begin to Backed-up at \n" + defaultpath + "DMS.sql\n Are you sure to continue?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string connectionstring = Properties.Settings.Default.ConnectionString;
                //string path = Application.StartupPath;
                MySqlConnection conn = new MySqlConnection(connectionstring);
                MySqlCommand cmd = new MySqlCommand();
                    
                MySqlBackup mb = new MySqlBackup(cmd);
                        
                cmd.Connection = conn;
                conn.Open();
                mb.ExportToFile(defaultpath + "DMS.sql");
                conn.Close();
                //MessageBox.Show("DataBase Backup Created Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked_checkbox_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nDataBase Backup Created Successfully";
                popup.Popup();
                        
                    
                
            }
            else
            {
                //MessageBox.Show("Database Back-up aborted by user!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.error_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nDatabase Back-up aborted by user!";
                popup.Popup();
            }
        }

        private void restoreDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will over-ride your previous version of Database.\n Are you sure to continue?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                string connectionsstring = Properties.Settings.Default.ConnectionString;
                string path = Properties.Settings.Default.dbpath;
                using (MySqlConnection con = new MySqlConnection(connectionsstring))
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            try
                            {
                                cmd.Connection = con;
                                con.Open();
                                mb.ImportFromFile(path + "DMS.sql");
                                con.Close();
                                //MessageBox.Show("Database Restoring Completed!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PopupNotifier popup = new PopupNotifier();
                                popup.Image = Properties.Resources.checked_checkbox_48;
                                popup.ImagePadding = new Padding(20, 20, 20, 20);
                                popup.TitleText = "Alert";

                                popup.ContentText = "\nDatabase Restoring Completed!!";
                                popup.Popup();
                            }
                            catch(Exception ex)
                            {
                                MetroMessageBox.Show(this, "No Any Backup File Found At "+Properties.Settings.Default.dbpath+"DMS.sql", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            else
            {
                //MessageBox.Show("No any changes occur in previous Database!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.error_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nNo any changes occur in previous Database!";
                popup.Popup();
            }
        }
    }
}
