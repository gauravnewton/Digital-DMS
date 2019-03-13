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
    public partial class EditUser : MetroForm
    {
        public EditUser()
        {
            InitializeComponent();
        }

        private void EditUser_Load(object sender, EventArgs e)
        {
            readingSettings();
            loadDepartment();
            loadUsers();
           
        }

        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox3.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

        private void loadDepartment()
        {
            if (departmentcount() > 0)
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd;
                metroComboBox2.Items.Clear();
                Dictionary<string, string> user = new Dictionary<string, string>();

                try
                {
                    string CmdString = " SELECT department from department ;";
                    cmd = new MySqlCommand(CmdString, con);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable("myTable");
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            user.Add(row.ItemArray[0].ToString(), row.ItemArray[0].ToString() );

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
                metroComboBox2.DataSource = new BindingSource(user, null);
                metroComboBox2.DisplayMember = "Value";
                metroComboBox2.ValueMember = "Key";
                metroComboBox2.SelectedIndex = -1;
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

        private int departmentcount()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd;
            int flag = 0;
            try
            {
                string CmdString = " SELECT DISTINCT department from department  ;";
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

        private void loadUsers()
        {
            if(userCount() > 0)
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd;
                metroComboBox1.Items.Clear();
                Dictionary<string, string> user = new Dictionary<string, string>();
                
                try
                {
                    string CmdString = " SELECT userid,u_name from user ;";
                    cmd = new MySqlCommand(CmdString, con);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable table = new DataTable("myTable");
                    da.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        for (int i = 0; i < 1; i++)
                        {
                            user.Add(row.ItemArray[0].ToString(), row.ItemArray[1].ToString() + " having Id ( " + row.ItemArray[0].ToString() + ")");
                            
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
                metroComboBox1.DataSource = new BindingSource(user, null);
                metroComboBox1.DisplayMember = "Value";
                metroComboBox1.ValueMember = "Key";
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.error_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";
                metroComboBox1.Items.Clear();
                popup.ContentText = "\nNo any user found in data base ! Add them first.";
                popup.Popup();
            }
        }

        private int userCount()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd;
            int flag = 0;
            try
            {
                string CmdString = " SELECT DISTINCT userid from user  ;";
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

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex != -1)
            {
                string userId = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key;

                string password,u_contact, permission_create_user, permission_edit_user, permission_database, permssion_add_file_category, permission_view_file, permission_download_file, department;

                try
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd;
                    string sql = "select * from user where userid='" + userId + "' ;";
                    cmd = new MySqlCommand(sql, con);
                    con.Open();
                    MySqlDataReader reader2 = cmd.ExecuteReader();
                    if (reader2.Read())
                    {
                        password = reader2.GetString("password");
                        u_contact = reader2.GetString("u_contact");
                        permission_create_user = reader2.GetString("permission_create_user");
                        permission_edit_user = reader2.GetString("permission_edit_user");
                        permission_database = reader2.GetString("permission_database");
                        permssion_add_file_category = reader2.GetString("permssion_add_file_category");
                        permission_view_file = reader2.GetString("permission_view_file");
                        permission_download_file = reader2.GetString("permission_download_file");
                        department = reader2.GetString("department");


                        metroTextBox3.Text = password;
                        metroTextBox4.Text = password;
                        metroTextBox5.Text = u_contact;
                        metroTextBox1.Text = department;


                        if (permission_download_file == "0")
                            checkBox5.Checked = false;
                        else
                            checkBox5.Checked = true;


                        if (permission_view_file == "0")
                            checkBox4.Checked = false;
                        else
                            checkBox4.Checked = true;


                        if (permssion_add_file_category == "0")
                            checkBox2.Checked = false;
                        else
                            checkBox2.Checked = true;


                        if (permission_database == "0")
                            checkBox3.Checked = false;
                        else
                            checkBox3.Checked = true;


                        if (permission_create_user == "0")
                            checkBox1.Checked = false;
                        else
                            checkBox1.Checked = true;


                        if (permission_edit_user == "0")
                            checkBox6.Checked = false;
                        else
                            checkBox6.Checked = true;
                    }
                }
                catch (Exception ten)
                {

                }
            }
            
        }

       

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(validate())
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd2;
                    string id = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key;


                    string CmdString = "update user set password = @password,u_contact = @u_contact,permission_create_user = @permission_create_user,permission_edit_user = @permission_edit_user,permission_database = @permission_database,permssion_add_file_category = @permssion_add_file_category,permission_view_file = @permission_view_file,permission_download_file = @permission_download_file,department = @department where userid ='" + id + "';";
                    cmd2 = new MySqlCommand(CmdString, con);


                    cmd2.Parameters.Add("@password", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@u_contact", MySqlDbType.VarChar, 10);
                    cmd2.Parameters.Add("@permission_create_user", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_edit_user", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_database", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permssion_add_file_category", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_view_file", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@permission_download_file", MySqlDbType.VarChar, 1);
                    cmd2.Parameters.Add("@department", MySqlDbType.VarChar, 50);



                    cmd2.Parameters["@password"].Value = metroTextBox3.Text;
                    cmd2.Parameters["@u_contact"].Value = metroTextBox5.Text;


                    if(checkBox1.Checked)
                        cmd2.Parameters["@permission_create_user"].Value = "1";
                    else
                        cmd2.Parameters["@permission_create_user"].Value = "0";


                    if (checkBox6.Checked)
                        cmd2.Parameters["@permission_edit_user"].Value = "1";
                    else
                        cmd2.Parameters["@permission_edit_user"].Value = "0";

                    if (checkBox3.Checked)
                        cmd2.Parameters["@permission_database"].Value = "1";
                    else
                        cmd2.Parameters["@permission_database"].Value = "0";

                    if (checkBox2.Checked)
                        cmd2.Parameters["@permssion_add_file_category"].Value = "1";
                    else
                        cmd2.Parameters["@permssion_add_file_category"].Value = "0";

                    if (checkBox4.Checked)
                        cmd2.Parameters["@permission_view_file"].Value = "1";
                    else
                        cmd2.Parameters["@permission_view_file"].Value = "0";

                    if (checkBox5.Checked)
                        cmd2.Parameters["@permission_download_file"].Value = "1";
                    else
                        cmd2.Parameters["@permission_download_file"].Value = "0";



                    cmd2.Parameters["@department"].Value = metroTextBox1.Text;

                    con.Open();
                    int RowsAffected = cmd2.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.error_48;
                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                        popup.TitleText = "Alert";

                        popup.ContentText = "\nDetails updated Successfully.";
                        popup.Popup();
                        
                        con.Close();
                        this.Close();
                    }
                    else
                    {
                        PopupNotifier popup = new PopupNotifier();
                        popup.Image = Properties.Resources.error_48;
                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                        popup.TitleText = "Alert";

                        popup.ContentText = "\nSomething Went Wrong Contact App Vedor.";
                        popup.Popup();
                    }
                }
                catch (Exception ex)
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.error_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nSomething Went Wrong Contact App Vedor.";
                    popup.Popup();
                }
            }
        }
        bool validate()
        {
            if (metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroTextBox3.Text != metroTextBox4.Text)
            {
                if (metroTextBox3.Text != metroTextBox4.Text)
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.error_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nBoth Password And Repeat Password Should Be Same.";
                    popup.Popup();
                    return false;
                }
                if (metroTextBox3.Text == "")
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.error_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nEnter Password First.";
                    popup.Popup();
                    return false;
                }
                if (metroTextBox4.Text == "")
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.error_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nEnter Repeat Password First.";
                    popup.Popup();
                    return false;
                }
                if (metroTextBox5.Text == "")
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.error_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nEnter Contact Number First.";
                    popup.Popup();
                    return false;
                }
            }
            return true;
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox2.SelectedIndex != -1)
            {
                string reAssignedDepartment = ((KeyValuePair<string, string>)metroComboBox2.SelectedItem).Key;

                metroTextBox1.Text = reAssignedDepartment;

            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

      
    }
}
