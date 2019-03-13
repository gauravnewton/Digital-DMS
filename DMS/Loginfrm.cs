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

namespace DMS
{
    public partial class Loginfrm : MetroForm
    {
        public Loginfrm()
        {
            InitializeComponent();
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

       
        private void Loginfrm_Load(object sender, EventArgs e)
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
        void reset()
        {
            metroComboBox1.SelectedIndex = -1;

            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
        }

        private void Loginfrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            reset();
        }

        int checkFormStatus()
        {
            if(metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroComboBox1.SelectedIndex == -1)
            {
                return 1;
            }

            return 0;
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {


            Properties.Settings.Default.id = metroTextBox1.Text;
                


            int verifyStatus = checkFormStatus();
            if(verifyStatus == 0)
            {
                string logintype = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Value;

                // admin login................
                if(logintype == "Admin")
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
                            this.Dispose();
                            this.Hide();

                            Program.isadmin = true;
                            //Program.id = metroTextBox1.Text;

                            PopupNotifier popup = new PopupNotifier();
                            popup.Image = Properties.Resources.administrator_48;
                            popup.TitleText = "Admin Login";
                            popup.ImagePadding = new Padding(20, 20, 20, 20);
                            popup.ContentText = "\nLogged-In As " + admin_name + " (Admin)";
                            popup.Popup();

                            new MDI().Show();



                       
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
                        this.Dispose(); 
                        this.Hide();

                        Program.isuser = true;
                        //Properties.Settings.Default.id = metroTextBox1.Text;

                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.gender_neutral_user_48;
                        popup.TitleText = "User Login";
                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                        popup.ContentText = "\nLogged-In As " + user_name + " (User)";
                        popup.Popup();
                        new MDI().Show();
                    
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
