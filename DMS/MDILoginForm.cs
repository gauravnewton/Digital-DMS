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
using System.Net;
using System.Net.Mail;

namespace DMS
{
    public partial class MDILoginForm : MetroForm
    {
        public MDILoginForm()
        {
            InitializeComponent();
        }

        private int havePermissionToBackup()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from user where userid='" + metroTextBox1.Text + "';";
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
            string sql = "select * from user where userid='" + metroTextBox1.Text + "';";
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
            string sql = "select * from user where userid='" + metroTextBox1.Text + "';";
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
            string sql = "select * from user where userid='" + metroTextBox1.Text + "';";
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

        int checkFormStatus()
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroComboBox1.SelectedIndex == -1)
            {
                return 1;
            }

            return 0;
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

         void reset()
            {
                metroComboBox1.SelectedIndex = -1;

                metroTextBox1.Text = "";
                metroTextBox2.Text = "";
            }


        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            reset();
        }
        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;

                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

        private void MDILoginForm_Load(object sender, EventArgs e)
        {
            readingSettings();
            Dictionary<string, string> logintype = new Dictionary<string, string>();

            logintype.Add("User", "User");
            logintype.Add("Admin", "Admin");

            metroComboBox1.DataSource = new BindingSource(logintype, null);
            metroComboBox1.DisplayMember = "Value";
            metroComboBox1.ValueMember = "Key";
            metroComboBox1.SelectedIndex = 0;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int verifyStatus = checkFormStatus();

            if (verifyStatus == 0)
            {
                string logintype = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Value;

                // admin login................
                if (logintype == "Admin")
                {
                    
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd;
                    string sql = "select * from admin where admin_id='" + metroTextBox1.Text + "'  and password='" + metroTextBox2.Text + "';";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        //login successfully....

                        string admin_name = reader2.GetString("admin_name");
                        //MetroMessageBox.Show(this, "\nLogged-In As " + admin_name + " (Admin)", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.Hide();

                        Program.isadmin = true;

                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.administrator_48;
                        popup.TitleText = "Admin Login";
                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                        popup.ContentText = "\nLogged-In As " + admin_name + " (Admin)";
                        popup.Popup();



                        Form frm = (Form)this.MdiParent;
                        MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];

                        int s = isactivated();


                        //admin section
                        ToolStripMenuItem t1 = (ToolStripMenuItem)ms.Items["adminToolStripMenuItem"];
                        t1.Enabled = true;


                        
                        t1.DropDownItems["toolStripMenuItem6"].Enabled = true;
                        t1.DropDownItems["toolStripMenuItem4"].Enabled = true;
                        t1.DropDownItems["addMoreCategoryToolStripMenuItem"].Enabled = true;
                        t1.DropDownItems["addMoreDepartmentToolStripMenuItem"].Enabled = true;
                       



                        ToolStripMenuItem ti1 = (ToolStripMenuItem)ms.Items["fileToolStripMenuItem"];
                        ti1.Enabled = true;

                        ToolStripMenuItem ti2 = (ToolStripMenuItem)ms.Items["reportToolStripMenuItem"];
                        ti2.Enabled = true;

                        ToolStripMenuItem ti3 = (ToolStripMenuItem)ms.Items["documentToolStripMenuItem"];
                        ti3.Enabled = true;

                        ToolStripMenuItem ti4 = (ToolStripMenuItem)ms.Items["backupRestoreToolStripMenuItem"];
                        ti4.Enabled = true;

                        ToolStripMenuItem ti5 = (ToolStripMenuItem)ms.Items["settingToolStripMenuItem"];
                        ti5.Enabled = true;

                        ToolStripMenuItem ti7 = (ToolStripMenuItem)ms.Items["helpToolStripMenuItem"];
                        ti7.Enabled = true;

                        ToolStripMenuItem ti8 = (ToolStripMenuItem)ms.Items["activateToolStripMenuItem"];
                        if (s == 1) // 1 mean not activated
                            ti8.Enabled = true;
                        else
                            ti8.Enabled = false;


                        ToolStripMenuItem ti10 = (ToolStripMenuItem)ms.Items["logoutToolStripMenuItem"];
                        ti10.Text = "Logout (" + admin_name + ")";

                        MDI.isloggedout = false;








                    }
                    else
                    {
                        //invalid login details....
                        label3.Text = "Invalid login id or password.";
                        label3.Visible = true;
                        metroTextBox1.WithError = true;
                        metroTextBox2.WithError = true;
                        reset();
                    }
                }
                //user login...........
                else
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd;
                    string sql = "select * from user where userid='" + metroTextBox1.Text + "'  and password='" + metroTextBox2.Text + "';";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        //login successfully....

                        string user_name = reader2.GetString("u_name");
                        //MetroMessageBox.Show(this, "\nLogged-In As " + user_name + " (User)", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        this.Hide();

                        Program.isuser = true;


                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.gender_neutral_user_48;
                        popup.TitleText = "User Login";
                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                        popup.ContentText = "\nLogged-In As " + user_name + " (User)";
                        popup.Popup();



                        //manageing menu items...
                        int s = isactivated();
                        Form frm = (Form)this.MdiParent;
                        MenuStrip ms = (MenuStrip)frm.Controls["menuStrip1"];




                        //Admin
                        ToolStripMenuItem t1 = (ToolStripMenuItem)ms.Items["adminToolStripMenuItem"];
                        t1.Enabled = true;
                        t1.DropDownItems["addMoreDepartmentToolStripMenuItem"].Enabled = false;
                        //Databasebackup
                        ToolStripMenuItem t2 = (ToolStripMenuItem)ms.Items["backupRestoreToolStripMenuItem"];
                        
                        if (havePermissionToAddUser() == 1)
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

                        ToolStripMenuItem ti1 = (ToolStripMenuItem)ms.Items["fileToolStripMenuItem"];
                        ti1.Enabled = true;

                        ToolStripMenuItem ti2 = (ToolStripMenuItem)ms.Items["reportToolStripMenuItem"];
                        ti2.Enabled = true;

                        ToolStripMenuItem ti3 = (ToolStripMenuItem)ms.Items["documentToolStripMenuItem"];
                        ti3.Enabled = true;

                        

                        ToolStripMenuItem ti5 = (ToolStripMenuItem)ms.Items["settingToolStripMenuItem"];
                        ti5.Enabled = true;



                        ToolStripMenuItem ti7 = (ToolStripMenuItem)ms.Items["helpToolStripMenuItem"];
                        ti7.Enabled = true;

                        ToolStripMenuItem ti8 = (ToolStripMenuItem)ms.Items["activateToolStripMenuItem"];
                        if (s == 1) // 1 mean not activated
                            ti8.Enabled = true;
                        else
                            ti8.Enabled = false;

                        


                        ToolStripMenuItem ti10 = (ToolStripMenuItem)ms.Items["logoutToolStripMenuItem"];
                        ti10.Text = "Logout (" + user_name + ")";

                        MDI.isloggedout = false;
                    }
                    else
                    {
                        //invalid login details....
                        label3.Text = "Invalid login id or password.";
                        label3.Visible = true;
                        metroTextBox1.WithError = true;
                        metroTextBox2.WithError = true;
                        reset();
                    }
                }
            }
            else
            {
                label3.Text = "Fill user-name, password and login type.";
                label3.Visible = true;
                metroTextBox1.WithError = true;
                metroTextBox2.WithError = true;
                reset();
            }
        }
    }
}
