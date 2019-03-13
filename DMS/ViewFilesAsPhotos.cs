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

namespace DMS
{
    public partial class ViewFilesAsPhotos : MetroForm
    {
        string name, id, type;
        public ViewFilesAsPhotos(string fileName,string fileType,string fileId)
        {
            InitializeComponent();
            name = fileName;
            type = fileType;
            id = fileId;
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
       

        private void ViewFilesAsPhotos_Load(object sender, EventArgs e)
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
            
            dataread(name, type, id);//load original file
            pictureBox1.BackgroundImage = Image.FromFile(Path.GetTempPath() + name + type);

        }
    }
}
