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
using Tulpep.NotificationWindow;
using MetroFramework;

namespace DMS
{
    public partial class Search : MetroForm
    {
        public Search()
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
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Black;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;


                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;

                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Silver; 
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;

                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;

                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;

                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Magenta;
                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox3.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }
        private void Search_Load(object sender, EventArgs e)
        {
            readingSettings();
            loadGridDate();
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
            metroComboBox3.Items.Clear();
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
            metroComboBox3.DataSource = new BindingSource(category, null);
            metroComboBox3.DisplayMember = "Value";
            metroComboBox3.ValueMember = "Key";
            metroComboBox3.SelectedIndex = -1;
        }
        private void loadGridDate()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

            string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files;";
            con.Open();
            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            adpt.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];


            metroGrid1.Columns[0].HeaderText = "  Sr No";
            metroGrid1.Columns[1].HeaderText = "          File Name";
            metroGrid1.Columns[2].HeaderText = "      File Type";
            metroGrid1.Columns[3].HeaderText = "        Department";
            metroGrid1.Columns[4].HeaderText = "       Category";
            metroGrid1.Columns[5].HeaderText = "      Created By";
            metroGrid1.Columns[6].HeaderText = "        Created On";


            //setting width of cells
            metroGrid1.Columns[0].Width = 100;
            metroGrid1.Columns[1].Width = 200;
            metroGrid1.Columns[2].Width = 100;
            metroGrid1.Columns[3].Width = 150;
            metroGrid1.Columns[4].Width = 200;
            metroGrid1.Columns[5].Width = 150;
            metroGrid1.Columns[6].Width = 150;

            metroGrid1.Columns[0].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[4].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //setting centre alignment of cell
            metroGrid1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            metroGrid1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex != -1)
            {
                metroButton3.Enabled = true;

                if(metroComboBox1.SelectedItem == "By Name")
                {
                    metroTextBox1.PromptText = "Enter File Name Here";
                }
                else if(metroComboBox1.SelectedItem == "By File Type")
                {
                    metroTextBox1.PromptText = "Enter File Type Here";
                }
                else if (metroComboBox1.SelectedItem == "By Creator")
                {
                    metroTextBox1.PromptText = "Enter File Creator Here(e.g. '.pdf')";
                }
                else if (metroComboBox1.SelectedItem == "By Date")
                {
                    metroTextBox1.PromptText = "Enter Date (YYYY-MM-DD)";
                }
                /*
                 * By Name
By Department
By Category
By File Type
By Creator
By Date
                 * */
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int rowindex = metroGrid1.CurrentCell.RowIndex;
            //int columnindex = metroGrid1.CurrentCell.ColumnIndex;
            string fileId = metroGrid1.Rows[rowindex].Cells[0].Value.ToString();
            string fileName = metroGrid1.Rows[rowindex].Cells[1].Value.ToString();
            string fileType = metroGrid1.Rows[rowindex].Cells[2].Value.ToString();

            if(viewPermissionStatus())
            {
                
                if (fileType == ".jpg" || fileType == ".png" || fileType == ".jpeg" || fileType == ".titf" || fileType == ".bmp")
                {
                    ViewFilesAsPhotos view = new ViewFilesAsPhotos(fileName, fileType, fileId);
                    view.Show();
                }
                else if (fileType == ".doc" || fileType == ".docx" || fileType == ".pdf")
                {
                    ViewPdfOrDoc view = new ViewPdfOrDoc(fileName, fileType, fileId);
                    view.Show();
                }
                else if (fileType == ".xls" || fileType == ".xlsx")
                {
                    View view = new View(fileName, fileType, fileId);
                    view.Show();
                }
                else
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.delete_sign_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nCan't Open this file, Instead  Download it !";
                    popup.Popup();
                }
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.TitleText = "Alert";
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.ContentText = "\nYou Have Not Permission To View This File ! ";
                popup.Popup();
            }
            //MessageBox.Show(viewPermission.ToString());
            //MessageBox.Show(fileId+fileType);
        }

        private bool downloadPermission()
        {
            if (Program.isadmin)
            {
                return true;
            }
            else
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd2;
                string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
                cmd2 = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {

                    string permmission = reader2.GetString("permission_download_file");
                    if (permmission == "1")
                    {
                        return true; // eligible
                    }
                    else
                    {
                        return false;//not eligible

                    }
                }
                return false;
            }
        }

        private bool viewPermissionStatus()
        {
            if(Program.isadmin)
            {
                return true;
            }
            else
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd2;
                string sql = "select * from user where userid='" + Properties.Settings.Default.id + "';";
                cmd2 = new MySqlCommand(sql, con);
                con.Open();
                MySqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {

                    string permmission = reader2.GetString("permission_view_file");
                    if (permmission == "1")
                    {
                        return true; // eligible
                    }
                    else
                    {
                        return false;//not eligible

                    }
                }
                return false;
            }
            
        }

        private void dataread()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd;
                int rowindex = metroGrid1.CurrentCell.RowIndex;
                string fileId = metroGrid1.Rows[rowindex].Cells[0].Value.ToString();
                string fileName = metroGrid1.Rows[rowindex].Cells[1].Value.ToString();
                string fileType = metroGrid1.Rows[rowindex].Cells[2].Value.ToString();
                string sPathToSaveFileTo = String.Empty;

                DialogResult result = folderBrowserDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    sPathToSaveFileTo = folderBrowserDialog1.SelectedPath.ToString() + "\\" + fileName + fileType;
                }
                string contenttype = String.Empty;
                con.Open();



                string sql = "select file from files where id='" + fileId + "';";
                cmd = new MySqlCommand(sql, con);
                //con.Open();
                MySqlDataReader reader2 = cmd.ExecuteReader();
                if (reader2.Read())
                {


                    byte[] imageBytes = (byte[])reader2[0];
                    // write bytes to disk as file
                    using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                    {
                        // use a binary writer to write the bytes to disk
                        using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                        {
                            bw.Write(imageBytes);
                            bw.Close();
                            //MessageBox.Show("Downloaded");

                            PopupNotifier popup = new PopupNotifier();
                            popup.Image = Properties.Resources.checked_checkbox_48;
                            popup.TitleText = "Alert";
                            popup.ImagePadding = new Padding(20, 20, 20, 20);
                            popup.ContentText = "\nRequested File Saved At " + sPathToSaveFileTo;
                            popup.Popup();
                        }
                    }
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            int rowindex = metroGrid1.CurrentCell.RowIndex;
            string fileId = metroGrid1.Rows[rowindex].Cells[0].Value.ToString();

            string fileType = metroGrid1.Rows[rowindex].Cells[2].Value.ToString();

            if (viewPermissionStatus())
            {
                dataread();
            }
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.TitleText = "Alert";
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.ContentText = "\nYou Have Not Permission To Download This File ! ";
                popup.Popup();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(metroGrid1.RowCount > 0)
            {
                metroButton1.Enabled = true;
                metroButton2.Enabled = true;
            }
        }

        void dataGrab(string SearchParam,string department,string category,string filename,string filecreatpr,string filedate,string filetype)
        {
            if (SearchParam == "By Name")
            {
                if(metroTextBox1.Text == "")
                {
                    MetroMessageBox.Show(this.MdiParent, "\nEnter A File Name First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else
                {
                    if (metroComboBox2.SelectedIndex != -1 && metroComboBox3.SelectedIndex != -1)
                    {
                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                        string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%' and filedepartment ='" + department + "' and filecategory='"+category+"';";
                        con.Open();
                        MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        metroGrid1.DataSource = ds.Tables[0];
                    }
                    else if( metroComboBox2.SelectedIndex != -1 || metroComboBox3.SelectedIndex != -1)
                    {
                        if(metroComboBox2.SelectedIndex != -1)
                        {
                            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                            string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%' and filedepartment ='"+department+"';";
                            con.Open();
                            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                            DataSet ds = new DataSet();
                            adpt.Fill(ds);
                            metroGrid1.DataSource = ds.Tables[0];
                        }
                        else if (metroComboBox3.SelectedIndex != -1)
                        {
                            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                            string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%' and filecategory ='" + category + "';";
                            con.Open();
                            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                            DataSet ds = new DataSet();
                            adpt.Fill(ds);
                            metroGrid1.DataSource = ds.Tables[0];
                        }
                    }
                    else
                    {
                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                        string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%"+metroTextBox1.Text+"%';";
                        con.Open();
                        MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        metroGrid1.DataSource = ds.Tables[0];

                    }
                }
            }
            else if(SearchParam == "By Department")
            {
                if(metroComboBox2.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A Department First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else 
                {
                    if ( metroComboBox3.SelectedIndex != -1 && metroTextBox1.Text != "")
                    {
                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                        string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%' and filedepartment ='" + department + "' and filecategory='" + category + "';";
                        con.Open();
                        MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        metroGrid1.DataSource = ds.Tables[0];
                    }
                    else if (metroComboBox3.SelectedIndex != -1 || metroTextBox1.Text != "")
                    {
                        if (metroComboBox3.SelectedIndex != -1)
                        {
                            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                            string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filedepartment ='" + department + "' and filecategory='" + category + "';";
                            con.Open();
                            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                            DataSet ds = new DataSet();
                            adpt.Fill(ds);
                            metroGrid1.DataSource = ds.Tables[0];
                        }
                        else if (metroTextBox1.Text != "")
                        {
                            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                            string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filedepartment ='" + department + "' and filename='" + metroTextBox1.Text + "';";
                            con.Open();
                            MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                            DataSet ds = new DataSet();
                            adpt.Fill(ds);
                            metroGrid1.DataSource = ds.Tables[0];
                        }                       
                        
                    }
                    else
                    {
                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                        string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filedepartment ='" + department + "';";
                        con.Open();
                        MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                        DataSet ds = new DataSet();
                        adpt.Fill(ds);
                        metroGrid1.DataSource = ds.Tables[0];
                    }
                }
            }
            else if (SearchParam == "By Category")
            {
                if (metroComboBox3.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A Category First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if (metroComboBox2.SelectedIndex != -1 && metroTextBox1.Text != "")
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%' and filedepartment ='" + department + "' and filecategory='" + category + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if (metroComboBox2.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  filedepartment ='" + department + "' and filecategory='" + category + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if(metroTextBox1.Text != "")
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filename like '%" + metroTextBox1.Text + "%'  and filecategory='" + category + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
            }
            else if (SearchParam == "By File Type")
            {
                if(metroTextBox1.Text == "" )
                {
                    MetroMessageBox.Show(this.MdiParent, "\nEnter A File Type First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if (metroComboBox2.SelectedIndex != -1 && metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "' and fileextension='" + metroTextBox1.Text + "' and filedepartment='"+department+"';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if(metroComboBox2.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  fileextension='" + metroTextBox1.Text + "' and filedepartment='"+department+"';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if(metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "' and fileextension='" + metroTextBox1.Text + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else{
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  fileextension='" + metroTextBox1.Text + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];

                }





            }
            else if (SearchParam == "By Creator")
            {
                if(metroTextBox1.Text == "" )
                {
                    MetroMessageBox.Show(this.MdiParent, "\nEnter File Creator First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if (metroComboBox2.SelectedIndex != -1 && metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "' and createdby='" + metroTextBox1.Text + "' and filedepartment='" + department + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if (metroComboBox2.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  createdby='" + metroTextBox1.Text + "' and filedepartment='" + department + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if (metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "' and createdby='" + metroTextBox1.Text + "' ;";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where createdby='" + metroTextBox1.Text + "' ;";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
            }






            else if (SearchParam == "By Date")
            {
                if(metroTextBox1.Text == "" )
                {
                    MetroMessageBox.Show(this.MdiParent, "\nEnter A Date First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                else if(metroComboBox2.SelectedIndex != -1 && metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where filecategory='" + category + "' and createdon='" + metroTextBox1.Text + "' and filedepartment='" + department + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if(metroComboBox2.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  createdon='" + metroTextBox1.Text + "' and filedepartment='" + department + "';";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else if (metroComboBox3.SelectedIndex != -1)
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  createdon='" + metroTextBox1.Text + "' ;";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
                else{
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);

                    string query = "SELECT id,filename,fileextension,filedepartment,filecategory,createdby,createdon from files where  createdon='" + metroTextBox1.Text + "' ;";
                    con.Open();
                    MySqlDataAdapter adpt = new MySqlDataAdapter(query, con);
                    DataSet ds = new DataSet();
                    adpt.Fill(ds);
                    metroGrid1.DataSource = ds.Tables[0];
                }
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            do
            {
                foreach (DataGridViewRow row in metroGrid1.Rows)
                {
                    try
                    {
                        metroGrid1.Rows.Remove(row);
                    }
                    catch (Exception) { }
                }
            } while (metroGrid1.Rows.Count >= 1);


            string department = "";
            string category = "";
            string filename = "";
            string fileCreator = "";
            string fileDate = "";
            string fileType = "";

            try
            {
                if (metroComboBox2.SelectedIndex != -1)
                {
                    department = metroComboBox2.SelectedValue.ToString();
                    //MessageBox.Show(department);
                }
                if (metroComboBox3.SelectedIndex != -1)
                {
                    category = metroComboBox3.SelectedValue.ToString();
                   // MessageBox.Show(department);
                }




                if (metroComboBox1.SelectedItem.ToString() == "By Name")
                {
                    filename = metroTextBox1.Text;
                }
                else if (metroComboBox1.SelectedItem.ToString() == "By File Type")
                {
                    fileType = metroTextBox1.Text;
                }
                else if (metroComboBox1.SelectedItem.ToString() == "By Creator")
                {
                    fileCreator = metroTextBox1.Text;
                }
                else if (metroComboBox1.SelectedItem.ToString() == "By Date")
                {
                    fileDate = metroTextBox1.Text;
                }

                dataGrab(metroComboBox1.SelectedItem.ToString(), department, category, filename, fileCreator, fileDate, fileType);


                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.error_48;
                popup.TitleText = "Alert";
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.ContentText = "\n"+metroGrid1.Rows.Count+" Records Found!";
                popup.Popup();

                if (metroGrid1.Rows.Count==0)
                {
                    metroButton1.Enabled = false;
                    metroButton2.Enabled = false;
                }
                else
                {
                    metroButton1.Enabled = true;
                    metroButton2.Enabled = true;
                }

            }
            catch(Exception excp)
            {
                MessageBox.Show(excp.Message);
            }
            
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
