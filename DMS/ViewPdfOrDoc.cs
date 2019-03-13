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
using Microsoft.Office.Interop.Word;
using System.IO;
using MySql.Data.MySqlClient;

namespace DMS
{
    public partial class ViewPdfOrDoc : MetroForm
    {
        public string name,type,id;
        public ViewPdfOrDoc(string fileName, string fileType,string fileId)
        {
            InitializeComponent();
            name = fileName;
            type = fileType;
            id = fileId;
        }

        private void ViewPdfOrDoc_Load(object sender, EventArgs e)
        {
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
            
            loadFile(name, type, id);
            
        }
        private void dataread(string fileName,string fileType,string fileId)
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
        private void loadFile(string fileName,string fileType,string fileId)
        {
            

            try
            {
                dataread(fileName, fileType, fileId);//load original file

                if (fileType == ".pdf")
                {
                    string file = Path.GetTempPath() + fileName + fileType;
                    axAcroPDF1.src = file;
                }
                else if (fileType == ".doc" || fileType == ".docx")
                {
                    string file = Path.GetTempPath() + fileName + fileType;
                    string output = Path.GetTempPath() + fileName + ".pdf";
                    string extension = System.IO.Path.GetExtension(file);
                    Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                    Document doc = null;
                    doc = app.Documents.Open(file, Type.Missing, false);

                    doc.ExportAsFixedFormat(output, WdExportFormat.wdExportFormatPDF);
                    doc.Close(false, Type.Missing, Type.Missing);
                    app.Quit(false, false, false);
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                    axAcroPDF1.src = output;
                }
                else
                {
                    MessageBox.Show("Unable to view file please download it.");
                }
            }

            catch(Exception fuck)
            {
                MessageBox.Show("Something going wrong! Contact App Vendor");
            }
            
            
           
        }
    }
}
