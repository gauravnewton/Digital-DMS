using ExcelDataReader;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace DMS
{
    public partial class View : MetroForm
    {
        string fName, fType, fid;
        public View(string fileName,string fileType,string fileId)
        {
            fName = fileName;
            fType = fileType;
            fid = fileId;

            InitializeComponent();
        }

        DataSet result;
        private void viewExcelFile_Load(object sender, EventArgs e)
        {
            grabingFile();
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0: this.Style = MetroFramework.MetroColorStyle.Default; metroComboBox1.Style = MetroFramework.MetroColorStyle.Default; break;
                case 1: this.Style = MetroFramework.MetroColorStyle.Black; metroComboBox1.Style = MetroFramework.MetroColorStyle.Black; break;
                case 2: this.Style = MetroFramework.MetroColorStyle.White; metroComboBox1.Style = MetroFramework.MetroColorStyle.White; break;
                case 3: this.Style = MetroFramework.MetroColorStyle.Silver; metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver; break;
                case 4: this.Style = MetroFramework.MetroColorStyle.Blue; metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue; break;
                case 5: this.Style = MetroFramework.MetroColorStyle.Green; metroComboBox1.Style = MetroFramework.MetroColorStyle.Green; break;
                case 6: this.Style = MetroFramework.MetroColorStyle.Lime; metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime; break;
                case 7: this.Style = MetroFramework.MetroColorStyle.Teal; metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal; break;
                case 8: this.Style = MetroFramework.MetroColorStyle.Orange; metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange; break;
                case 9: this.Style = MetroFramework.MetroColorStyle.Brown; metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown; break;
                case 10: this.Style = MetroFramework.MetroColorStyle.Pink; metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink; break;
                case 11: this.Style = MetroFramework.MetroColorStyle.Magenta; metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta; break;
                case 12: this.Style = MetroFramework.MetroColorStyle.Purple; metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple; break;
                case 13: this.Style = MetroFramework.MetroColorStyle.Red; metroComboBox1.Style = MetroFramework.MetroColorStyle.Red; break;
                case 14: this.Style = MetroFramework.MetroColorStyle.Yellow; metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow; break;
            }
        }
        private void dataread(string fileName, string fileType, string fileId)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd;
                string sPathToSaveFileTo = Path.GetTempPath() + fileName + fileType;


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


                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        void grabingFile()
        {
            dataread(fName, fType, fid);
            using (var stream = File.Open(Path.GetTempPath()+fName+fType, FileMode.Open, FileAccess.Read))
            {
                // Auto-detect format, supports:
                //  - Binary Excel files (2.0-2003 format; *.xls)
                //  - OpenXml Excel files (2007 format; *.xlsx)
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    // Choose one of either 1 or 2:

                    // 1. Use the reader methods
                    do
                    {
                        while (reader.Read())
                        {
                            // reader.GetDouble(0);
                        }
                    } while (reader.NextResult());

                    // 2. Use the AsDataSet extension method
                    result = reader.AsDataSet();
                    metroComboBox1.Items.Clear();
                    foreach (DataTable dt in result.Tables)
                        metroComboBox1.Items.Add(dt.TableName);
                    reader.Close();
                    // The result of each spreadsheet is in result.Tables
                }
            }
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[metroComboBox1.SelectedIndex];
        }
    }
}
