using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Net.Mail;
using Tulpep.NotificationWindow;
using MetroFramework.Forms;

namespace DMS
{
    

    public partial class Activation : Form
    {
        public static int Flags = 0;
        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public Activation()
        {
            InitializeComponent();
        }

        private void Activation_Load(object sender, EventArgs e)
        {
            
        }

        void monitoring_product_key()
        {

            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.ConnectionString);
            MySqlCommand cmd1;
            try
            {
                string CmdString = "select * from product_key;";
                cmd1 = new MySqlCommand(CmdString, connection);
                connection.Open();
                MySqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    String entered_pk = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text + "-" + textBox4.Text + "-" + textBox5.Text;
                    //MessageBox.Show(entered_pk + "  " + reader1.GetString("product_key"));
                    String real_pk = reader1.GetString("product_key");

                    if (entered_pk.CompareTo(real_pk) == 0)
                    {
                        pictureBox1.Visible = true;
                        //MessageBox.Show("matched");
                    }
                    else
                    {
                        pictureBox1.Visible = false;
                    }
                }



            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            monitoring_product_key();
            if (textBox1.Text.Length == 5)
            {
                textBox2.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            monitoring_product_key();
            if (textBox2.Text.Length == 5)
            {
                textBox3.Focus();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            monitoring_product_key();
            if (textBox3.Text.Length == 5)
            {
                textBox4.Focus();
            }
        }

        private void sendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled)
                MessageBox.Show(string.Format("{0}sendcancled.", e.UserState), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.Error != null)
                MessageBox.Show(string.Format("{0} {1}", e.UserState, e.Error), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.checked_checkbox_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nProduct activation details are sent to developer !";
                popup.Popup();
                Flags = 1;
            }
        }

        public static string GetOSInformation()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    return ((string)wmi["Caption"]).Trim() + ", " + (string)wmi["Version"] + ", " + (string)wmi["OSArchitecture"];
                }
                catch { }
            }
            return "Unknown";
        }


        void send()
        {
            try
            {
                login = new NetworkCredential("inventorymanagementbygaurav@gmail.com", "gaurav14111994");
                client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.Credentials = login;
                msg = new MailMessage { From = new MailAddress("inventorymanagementbygaurav@gmail.com", "Inventory Management System", Encoding.UTF8) };
                msg.To.Add(new MailAddress("gauravmute@gmail.com"));
                msg.Subject = "Product Activation";
                msg.Body = "Recently Data Management System is Installed and Trying to Activate. System Details PC Name- " + GetComputerName() + " Running on OS " + GetOSInformation();
                msg.BodyEncoding = Encoding.UTF8;
                msg.IsBodyHtml = true;
                msg.Priority = MailPriority.High;
                msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                client.SendCompleted += new SendCompletedEventHandler(sendCompletedCallback);
                string userstate = "Sending...";
                client.SendAsync(msg, userstate);

                /*
                 * 
                 * 
                 * 
                 MailMessage msg = new MailMessage();  
                msg.From = new MailAddress("nilusilu3@gmail.com");  
                msg.To.Add(textBox1.Text);  
                msg.Subject = textBox3.Text;  
                msg.Body = textBox2.Text;  
  
                SmtpClient smt = new SmtpClient();  
                smt.Host = "smtp.gmail.com";  
                System.Net.NetworkCredential ntcd = new NetworkCredential();  
                ntcd.UserName = "nilusilu3@gmail.com";   
                ntcd.Password = "";  
                smt.Credentials = ntcd;  
                smt.EnableSsl = true;  
                smt.Port = 587;  
                smt.Send(msg);  
  
                MessageBox.Show("Your Mail is sended");
                 * 
                 * */
            }
            catch (Exception ec)
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nYou Must Be Connected To Internet During Prdouct Activation !";
                popup.Popup();
            }
        }

        public static String GetComputerName()
        {
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            String info = String.Empty;
            foreach (ManagementObject mo in moc)
            {
                info = (string)mo["Name"];
                //mo.Properties["Name"].Value.ToString();
                //break;
            }
            return info;
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            monitoring_product_key();
            if (textBox4.Text.Length == 5)
            {
                textBox5.Focus();
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            monitoring_product_key();
            if (textBox5.Text.Length == 5)
            {
                button1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                PopupNotifier popup = new PopupNotifier();
                popup.Image = Properties.Resources.delete_sign_48;
                popup.ImagePadding = new Padding(20, 20, 20, 20);
                popup.TitleText = "Alert";

                popup.ContentText = "\nAll Fields Are Mandetory !";
                popup.Popup();
            }

            else
            {
                send();
                if (Flags == 1)
                {
                    string entere_key = textBox1.Text + "-" + textBox2.Text + "-" + textBox3.Text + "-" + textBox4.Text + "-" + textBox5.Text;
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                        MySqlCommand cmd2, cmd1;
                        string sql = "select * from product_key;";
                        cmd2 = new MySqlCommand(sql, con);
                        con.Open();
                        MySqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            string product_key = reader2.GetString("product_key");
                            if (entere_key == product_key)
                            {
                                con.Close();
                                con.Open();
                                string query = "update install_detail set product_status='ACTIVATED';";
                                cmd1 = new MySqlCommand(query, con);
                                cmd1.ExecuteNonQuery();
                                //MetroMessageBox.Show(this,"\nProduct Activated Successsfully, Restart Application to reflect changes.", "Product Activation", MessageBoxButtons.OK, MessageBoxIcon.Question);
                                PopupNotifier popup = new PopupNotifier();
                                popup.Image = Properties.Resources.checked_checkbox_48;
                                popup.TitleText = "User Login";
                                popup.ImagePadding = new Padding(20, 20, 20, 20);
                                popup.ContentText = "\nProduct Activated Successsfully, Restart Application to reflect changes";
                                popup.Popup();
                                this.Hide();

                            }
                            else
                            {
                                PopupNotifier popup = new PopupNotifier();
                                popup.Image = Properties.Resources.delete_sign_48;
                                popup.ImagePadding = new Padding(20, 20, 20, 20);
                                popup.TitleText = "Alert";

                                popup.ContentText = "\nYou have entered wrong Licence Key. Please Enter correct Licence key or Contact Brahamdeo Technology !";
                                popup.Popup();
                            }
                        }

                    }
                    catch (Exception exc)
                    {
                        MetroMessageBox.Show(this, exc.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.delete_sign_48;
                    popup.ImagePadding = new Padding(20, 20, 20, 20);
                    popup.TitleText = "Alert";

                    popup.ContentText = "\nYou Must Be Connected To Internet During Prdouct Activation !";
                    popup.Popup();
                }

            }
        }
    }
}
