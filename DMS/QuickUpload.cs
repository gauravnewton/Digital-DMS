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
using MySql.Data.MySqlClient;
using System.IO;
using MetroFramework;

namespace DMS
{
    public partial class QuickUpload : MetroForm
    {
        public QuickUpload()
        {
            InitializeComponent();
        }
        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Silver;;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;

                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

        private void QuickUpload_Load(object sender, EventArgs e)
        {
            readingSettings();
            fillingAllCategory();
            fillingAllDepartment();
        }

        private void fillingAllDepartment()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd;
            metroComboBox2.Items.Clear();
            Dictionary<string, string> category = new Dictionary<string, string>();
            try
            {
                string CmdString = "select department from department;";
                cmd = new MySqlCommand(CmdString, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable("myTable");
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //supplier_id.Add(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                        category.Add(row.ItemArray[0].ToString(), row.ItemArray[0].ToString());
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
            //metroComboBox1.DataSource = new BindingSource(supplier_id, null);
            metroComboBox2.DataSource = new BindingSource(category, null);
            metroComboBox2.DisplayMember = "Value";
            metroComboBox2.ValueMember = "Key";
            metroComboBox2.SelectedIndex = -1;
        }

        void fillingAllCategory()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd;
            metroComboBox1.Items.Clear();
            Dictionary<string, string> category = new Dictionary<string, string>();
            try
            {
                string CmdString = "select categoryname from file_categories;";
                cmd = new MySqlCommand(CmdString, con);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable table = new DataTable("myTable");
                da.Fill(table);
                foreach (DataRow row in table.Rows)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //supplier_id.Add(row.ItemArray[1].ToString(), row.ItemArray[0].ToString());
                        category.Add(row.ItemArray[0].ToString(), row.ItemArray[0].ToString());
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
            //metroComboBox1.DataSource = new BindingSource(supplier_id, null);
            metroComboBox1.DataSource = new BindingSource(category, null);
            metroComboBox1.DisplayMember = "Value";
            metroComboBox1.ValueMember = "Key";
            metroComboBox1.SelectedIndex = -1;
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            if(isValidated())
            {
                //OpenFileDialog openFileDialog1 = new OpenFileDialog();
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;
                    string extension = System.IO.Path.GetExtension(file);
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(file);

                    try
                    {
                        setFileLimit();
                        byte[] bytes = File.ReadAllBytes(file);
                        DateTime dateTime = DateTime.UtcNow.Date;
                        string createdOn = dateTime.ToString("yyyy-MM-dd");
                        string department = ((KeyValuePair<string, string>)metroComboBox2.SelectedItem).Key; ;
                        string fileCategory = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key; ;



                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                        MySqlCommand cmd2;
                        string CmdString = "insert into files(filename,fileextension,filedepartment,filecategory,createdby,createdon,file) values(@filename,@fileextension,@filedepartment,@filecategory,@createdby,@createdon,@file);";
                        cmd2 = new MySqlCommand(CmdString, con);
                        cmd2.Parameters.Add("@filename", MySqlDbType.VarChar, 500);
                        cmd2.Parameters.Add("@fileextension", MySqlDbType.VarChar, 10);
                        cmd2.Parameters.Add("@filedepartment", MySqlDbType.VarChar, 100);
                        cmd2.Parameters.Add("@filecategory", MySqlDbType.VarChar, 100);
                        cmd2.Parameters.Add("@createdby", MySqlDbType.VarChar, 100);
                        cmd2.Parameters.Add("@createdon", MySqlDbType.DateTime);
                        cmd2.Parameters.Add("@file", MySqlDbType.LongBlob);

                        cmd2.Parameters["@filename"].Value = fileName;
                        cmd2.Parameters["@fileextension"].Value = extension;
                        cmd2.Parameters["@filedepartment"].Value = department;
                        cmd2.Parameters["@filecategory"].Value = fileCategory;
                        cmd2.Parameters["@createdby"].Value = Properties.Settings.Default.id;
                        cmd2.Parameters["@createdon"].Value = createdOn;
                        cmd2.Parameters["@file"].Value = bytes;

                        con.Open();
                        int RowsAffected = cmd2.ExecuteNonQuery();
                        if (RowsAffected > 0)
                        {
                            MetroMessageBox.Show(this.MdiParent, "\nFile Stored Successfully !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            this.Dispose();
                        }
                        else
                        {
                            // not registered successfully
                            MetroMessageBox.Show(this, "\nSomething going to be wrong contact application vendor !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    catch (Exception ex)
                    {
                        MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            
        }

        private bool isValidated()
        {
            if(metroComboBox1.SelectedIndex == -1 || metroComboBox2.SelectedIndex == -1)
            {
                if(metroComboBox1.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A Category First !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (metroComboBox2.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A Department First !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        private void setFileLimit()
        {
            using (MySqlConnection conn = new MySqlConnection(Properties.Settings.Default.ConnectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    conn.Open();

                    cmd.CommandText = "SET GLOBAL max_allowed_packet=32*1024*1024;";
                    cmd.ExecuteNonQuery();

                    // Close and Reopen the Connection
                    conn.Close();
                    conn.Open();

                    // Start to take effect here...
                    // Do something....

                    conn.Close();
                }
            }
        }
    }
}
