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
using MetroFramework;
using MySql.Data.MySqlClient;
using Tulpep.NotificationWindow;

namespace DMS
{
    public partial class Add_User : MetroForm
    {
        public Add_User()
        {
            InitializeComponent();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Add_User_Load(object sender, EventArgs e)
        {
            loadDepartment();
            readingSettings();
        }

        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroButton2.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox2.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }


        private void loadDepartment()
        {
            if (departmentCount() > 0)
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd;
                metroComboBox1.Items.Clear();
                Dictionary<string, string> department = new Dictionary<string, string>();

                try
                {
                    string CmdString = " SELECT id,department from department ;";
                    cmd = new MySqlCommand(CmdString, con);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable("myTable");
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            department.Add(row.ItemArray[1].ToString(), row.ItemArray[1].ToString());

                        }
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
                metroComboBox1.DataSource = new BindingSource(department, null);
                metroComboBox1.DisplayMember = "Value";
                metroComboBox1.ValueMember = "Key";
                metroComboBox1.SelectedIndex = -1;
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.error_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";
                metroComboBox1.Items.Clear();
                popup.ContentText = "\nNo any department found in data base ! Add them first.";
                popup.Popup();
            }
        }

        private int departmentCount()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd;
            int flag = 0;
            try
            {
                string CmdString = " SELECT DISTINCT id from department  ;";
                cmd = new MySqlCommand(CmdString, con);
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    flag = 1;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }

            }
            return flag;
        }

        private void metroTextBox2_Click(object sender, EventArgs e)
        {

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(validateResponse() == 0 || passwordMatch() == 0 || contactValidate() == 0 )
            {
                

                if(validateResponse() == 0)
                {

                }else{
                    MetroMessageBox.Show(this.MdiParent, "\nAll Fields Are Mandetory !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
                if (passwordMatch() == 0)
                {

                }
                else{
                    MetroMessageBox.Show(this.MdiParent, "\nBoth Password Should Be Same !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    return;
                }
                if (contactValidate() == 0)
                {

                }
                else
                {
                    MetroMessageBox.Show(this.MdiParent, "\nContact Should Be 10 Digit Long !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }
                if (metroComboBox1.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nChoose A Department First!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                // storing data.


                try
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd2;
                    string CmdString = "insert into user(userid,password,u_name,u_contact,permission_create_user,permission_edit_user,permission_database,permssion_add_file_category,permission_view_file,permission_download_file,department) values(@userid,@password,@u_name,@u_contact,@permission_create_user,@permission_edit_user,@permission_database,@permssion_add_file_category,@permission_view_file,@permission_download_file,@department);";
                    
                    cmd2 = new MySqlCommand(CmdString, con);
                    

                    cmd2.Parameters.Add("@userid", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@password", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@u_name", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@u_contact", MySqlDbType.VarChar, 10);
                    cmd2.Parameters.Add("@permission_create_user", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_edit_user", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_database", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permssion_add_file_category", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_view_file", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_download_file", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@department", MySqlDbType.VarChar, 50);

                    cmd2.Parameters["@userid"].Value = metroTextBox2.Text;
                    cmd2.Parameters["@password"].Value = metroTextBox3.Text;
                    cmd2.Parameters["@u_name"].Value = metroTextBox1.Text;
                    cmd2.Parameters["@u_contact"].Value = metroTextBox5.Text;


                    if(checkBox1.Checked)
                    {
                        cmd2.Parameters["@permission_create_user"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permission_create_user"].Value = "0";
                    }
                    if (checkBox6.Checked)
                    {
                        cmd2.Parameters["@permission_edit_user"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permission_edit_user"].Value = "0";
                    }
                    if (checkBox3.Checked)
                    {
                        cmd2.Parameters["@permission_database"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permission_database"].Value = "0";
                    }
                    if (checkBox2.Checked)
                    {
                        cmd2.Parameters["@permssion_add_file_category"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permssion_add_file_category"].Value = "0";
                    }
                    if (checkBox4.Checked)
                    {
                        cmd2.Parameters["@permission_view_file"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permission_view_file"].Value = "0";
                    }
                    if (checkBox5.Checked)
                    {
                        cmd2.Parameters["@permission_download_file"].Value = "1";
                    }
                    else
                    {
                        cmd2.Parameters["@permission_download_file"].Value = "0";
                    }
                    string department = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key;

                    cmd2.Parameters["@department"].Value = department;

                    

                    con.Open();
                    int RowsAffected = cmd2.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MetroMessageBox.Show(this.MdiParent, "\nUser Added Successfully !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Dispose();
                        con.Close();
                    }
                    else
                    {
                        // not registered successfully
                        MetroMessageBox.Show(this.MdiParent, "\nSomething going to be wrong contact application vendor !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MetroMessageBox.Show(this.MdiParent, "User Id Already Taken! Try Different One.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                   

            }
            
        }

        private int contactValidate()
        {
            if(metroTextBox5.Text.Length == 10)
            {
                return 0; //no issue
            }
            return 1;// issue
        }

        private int passwordMatch()
        {
            if(metroTextBox3.Text == metroTextBox4.Text)
            {
                return 0; //no issue
            }
            return 1; // not matched
        }

        private int validateResponse()
        {
            if(metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "")
            {
                return 1; // having error with user's response
            }
            return 0;//  with no error in user's response
        }

        private void metroTextBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void metroTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }
    }
}
