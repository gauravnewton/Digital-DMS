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
using System.IO;
using WIA;
using MySql.Data.MySqlClient;
using MetroFramework;
using System.Data.SqlClient;

namespace DMS
{
    public partial class ScanAndUpload : MetroForm
    {
        public ScanAndUpload()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            DialogResult result = folderDlg.ShowDialog();

            if (result == DialogResult.OK)
            {
                textBox1.Text = folderDlg.SelectedPath;
            }
        }

        private void dataread()
        {
            MySqlConnection con = new MySqlConnection("Server=localhost;Database=dms;Uid=root;Pwd=;");
            MySqlCommand cmd;

            string sPathToSaveFileTo = Path.GetTempPath()+"/fuck.jpeg";
            string contenttype = String.Empty;
            con.Open();



            string sql = "select file from files where id='1';";
            cmd = new MySqlCommand(sql, con);
            //con.Open();
            MySqlDataReader reader2 = cmd.ExecuteReader();
            if (reader2.Read())
            {
                //login successfully....

                byte[] imageBytes = (byte[])reader2[0];
                // write bytes to disk as file
                using (System.IO.FileStream fs = new System.IO.FileStream(sPathToSaveFileTo, System.IO.FileMode.Create, System.IO.FileAccess.ReadWrite))
                {
                    // use a binary writer to write the bytes to disk
                    using (System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs))
                    {
                        bw.Write(imageBytes);
                        bw.Close();
                        MessageBox.Show("Downloaded");
                    }
                }
            }


            
       
           
        }

        private void TriggerScan()
        {
            Console.WriteLine("Image succesfully scanned");
        }

        public void StartScanning()
        {
            Scanner device = null;

            this.Invoke(new MethodInvoker(delegate()
            {
                device = listBox1.SelectedItem as Scanner;
            }));

            if (device == null)
            {
                MessageBox.Show("You need to select first an scanner device from the list",
                                "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (String.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Provide a filename",
                                "Warning",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ImageFile image = new ImageFile();
            string imageExtension = "";

            this.Invoke(new MethodInvoker(delegate()
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        image = device.ScanPNG();
                        imageExtension = ".png";
                        break;
                    case 1:
                        image = device.ScanJPEG();
                        imageExtension = ".jpeg";
                        break;
                    case 2:
                        image = device.ScanTIFF();
                        imageExtension = ".tiff";
                        break;

                }
            }));


            // Save the image
            var path = Path.Combine(textBox1.Text, textBox2.Text + imageExtension);

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            image.SaveFile(path);

            pictureBox1.Image = new Bitmap(path);
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(StartScanning).ContinueWith(result => TriggerScan());
            updateScan();
            
        }

        private void updateScan()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string CmdString = "insert into quickscan(uid) values(@uid);";
            cmd2 = new MySqlCommand(CmdString, con);

            cmd2.Parameters.Add("@uid", MySqlDbType.VarChar, 100);

            cmd2.Parameters["@uid"].Value = Properties.Settings.Default.id;

            con.Open();
            cmd2.ExecuteNonQuery();
        }

        private int validateForm()
        {
            if(metroComboBox1.SelectedIndex == -1 || metroComboBox2.SelectedIndex == -1 || comboBox1.SelectedIndex == -1)
            {
                if(metroComboBox1.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A File Category First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                     return 1;//have issue
                }
                if (metroComboBox2.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A Department First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 1;//have issue
                }
                if (comboBox1.SelectedIndex == -1)
                {
                    MetroMessageBox.Show(this.MdiParent, "\nSelect A File Format First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return 1;//have issue
                }
                
            }
            return 0;//no issue
        }


        private void ListScanners()
        {
            // Clear the ListBox.
            listBox1.Items.Clear();

            // Create a DeviceManager instance
            var deviceManager = new DeviceManager();

            // Loop through the list of devices and add the name to the listbox
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                // Add the device only if it's a scanner
                if (deviceManager.DeviceInfos[i].Type != WiaDeviceType.ScannerDeviceType)
                {
                    continue;
                }

                // Add the Scanner device to the listbox (the entire DeviceInfos object)
                // Important: we store an object of type scanner (which ToString method returns the name of the scanner)
                listBox1.Items.Add(
                    new Scanner(deviceManager.DeviceInfos[i])
                );
            }
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

                    metroComboBox2.Style = MetroFramework.MetroColorStyle.Silver; 
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
        private void ScanAndUpload_Load(object sender, EventArgs e)
        {
            //dataread();
            readingSettings();
            ListScanners();
            fillingAllCategory();
            fillingAllDepartment();
            fillFileName();
            // Set start output folder TMP
            textBox1.Text = Path.GetTempPath();
            // Set JPEG as default
            comboBox1.SelectedIndex = 1;
        }

        private void fillFileName()
        {
            MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd2;
            string sql = "select * from quickscan order by id limit 1;";
            cmd2 = new MySqlCommand(sql, con);
            con.Open();
            MySqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {

                int count = reader2.GetInt32("id") + 1;
                textBox2.Text = "QuickScan" + count;
            }

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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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

        private void metroButton3_Click(object sender, EventArgs e)
        {
            int status = validateForm();

            if (status == 0)
            {


                string department = ((KeyValuePair<string, string>)metroComboBox2.SelectedItem).Key; ;
                string fileCategory = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Key; ;
                string fileExt = "";
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        
                        fileExt = ".png";
                        break;
                    case 1:
                        
                        fileExt = ".jpeg";
                        break;
                    case 2:
                        
                        fileExt = ".tiff";
                        break;

                }
                string filename = Path.Combine(textBox1.Text, textBox2.Text + fileExt);
                string cretaedBy = Properties.Settings.Default.id;
                DateTime dateTime = DateTime.UtcNow.Date;
                string createdOn = dateTime.ToString("yyyy-MM-dd");

                //storing file

                try
                {
                    setFileLimit();
                    byte[] bytes = File.ReadAllBytes(filename);

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

                    cmd2.Parameters["@filename"].Value = textBox2.Text;
                    cmd2.Parameters["@fileextension"].Value = fileExt;
                    cmd2.Parameters["@filedepartment"].Value = department;
                    cmd2.Parameters["@filecategory"].Value = fileCategory;
                    cmd2.Parameters["@createdby"].Value = cretaedBy;
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
            else
            {
                // MetroMessageBox.Show(this.MdiParent, "\nSelect A Department First ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
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
