using MetroFramework;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tulpep.NotificationWindow;

namespace DMS
{
    static class Program
    {
        public static int width = SystemInformation.VirtualScreen.Width;
        public static int hight = SystemInformation.VirtualScreen.Height;

        public static bool isadmin = false;
        public static bool isuser = false;

        public static string id;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MySqlConnection connection = new MySqlConnection(Properties.Settings.Default.voidConnectionString);

            try
            {

                MySqlCommand cmd;
                connection.Open();
                cmd = connection.CreateCommand();
                cmd.CommandText = "select SCHEMA_NAME from INFORMATION_SCHEMA.SCHEMATA where SCHEMA_NAME='" + Properties.Settings.Default.dbname + "';";
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    //DataBase Found.checking vailidity of product and exepiry data.
                    //checking validity of application.......
                    MySqlConnection connnn = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd1;
                    DateTime curdate = DateTime.UtcNow.Date;


                    string CmdString = "select * from install_detail order by DATE_FORMAT(installation_date,'%Y%m%d');";
                    cmd1 = new MySqlCommand(CmdString, connnn);
                    connnn.Open();
                    MySqlDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        DateTime instalation_date = reader1.GetDateTime("installation_date");
                        TimeSpan daysLeft = curdate - instalation_date;
                        int dayLeft = Convert.ToInt32(daysLeft.Days);
                        //MessageBox.Show(dayLeft.ToString());
                        if (1 * dayLeft >= 365)//365 denotes number of trail days....
                        {
                            //MetroMessageBox.Show(this, "Msg", "Title", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            PopupNotifier popup = new PopupNotifier();
                            popup.Image = Properties.Resources.delete_sign_48;
                            popup.TitleText = "Licence Expired";

                            popup.ContentText = "\nYour licence to Inventory Management System has benn expired ! Contact Brahamdeo Technology for renew product";
                            popup.Popup();
                            popup.ImagePadding = new Padding(20, 20, 20, 20);
                            MessageBox.Show("Your Licence is Expired Now.\n Contact Brahmdeo Technology.", "\n Licence Expired", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            connnn.Close();
                            Application.Exit();
                        }
                        else
                        {
                            //////////////

                            //MessageBox.Show("Database Found");
                            Random rnd = new Random();
                            int chance = rnd.Next(1, 5);
                            if (chance == 1 || chance == 2)
                            {
                                //checking product is activated or not.......
                                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                                MySqlCommand cmd2;
                                string sql = "select * from install_detail;";
                                cmd2 = new MySqlCommand(sql, con);
                                con.Open();
                                MySqlDataReader reader2 = cmd2.ExecuteReader();
                                if (reader2.Read())
                                {

                                    string product_status = reader2.GetString("product_status");
                                    if (product_status == "NOT-ACTIVATED")
                                    {
                                        //MessageBox.Show("You are using currently a trail version of E-Biling System");
                                        PopupNotifier popup = new PopupNotifier();
                                        popup.Image = Properties.Resources.error_48;
                                        popup.TitleText = "Activate Product";
                                        popup.ImagePadding = new Padding(20, 20, 20, 20);
                                        popup.ContentText = "\nYou are using a trail version of Data Management System!";
                                        popup.Popup();
                                        ForcedActivation fc = new ForcedActivation();
                                        Application.Run(fc);
                                    }
                                    else
                                    {
                                        // works when product is activated...........
                                        Application.Run(new LaunchScreen());

                                    }
                                }
                            }
                            else
                            {

                                //MessageBox.Show("Normal");
                                Application.Run(new LaunchScreen());

                            }
                        }
                    }
                }
                else
                {
                    //DataBase not found, creating required database.


                    Properties.Settings.Default.ClientScreenHeight = hight;
                    Properties.Settings.Default.ClientScreenWidth = width;

                    connection.Close();
                    connection.Open();
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "create database " + Properties.Settings.Default.dbname + ";     use " + Properties.Settings.Default.dbname + ";       create table department(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,department varchar(50));                    create table quickscan(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,uid varchar(100));                        create table files(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,filename varchar(500),fileextension varchar(10),filedepartment varchar(100),filecategory varchar(100),createdby varchar(100),createdon date,file longblob);             create table user(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY, userid varchar(50) UNIQUE,password varchar(50),u_name varchar(50),u_contact varchar(10),permission_create_user varchar(1),permission_edit_user varchar(1),permission_database varchar(1),permssion_add_file_category varchar(1),permission_view_file varchar(1),permission_download_file varchar(1),department varchar(50));             create table install_detail(installation_date date,product_status varchar(20));    create table product_key(product_key  varchar(34));               create table admin(admin_id varchar(100) primary key,admin_name varchar(50),password varchar(50),contact varchar(10),email varchar(300) );              create table  file_categories(id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,categoryname varchar(100) );         ";
                    cmd.ExecuteNonQuery();
                    connection.Close();


                    fillingCategories();

                    fillingDepartments();



                    MySqlCommand cmd2;
                    DateTime dateTime = DateTime.UtcNow.Date;
                    string install_on = dateTime.ToString("yyyy-MM-dd");
                    string CmdString = "insert into install_detail(installation_date,product_status) values(@date,@product_status); insert into product_key values(@key); ";
                    cmd2 = new MySqlCommand(CmdString, connection);
                    cmd2.Parameters.Add("@date", MySqlDbType.DateTime);
                    cmd2.Parameters.Add("@product_status", MySqlDbType.VarChar, 20);
                    cmd2.Parameters.Add("@key", MySqlDbType.VarChar, 34);
                    cmd2.Parameters["@date"].Value = install_on;
                    cmd2.Parameters["@product_status"].Value = "NOT-ACTIVATED";//set as a trail user..
                    cmd2.Parameters["@key"].Value = "BTGAY-G7A2U-7R7A6-V7K6U-8M3A2";//embeded product key of software change it for different client
                    connection.Open();
                    cmd2.ExecuteNonQuery();
                    connection.Close();
                    StartUp f2 = new StartUp();
                    Application.Run(f2);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private static void fillingDepartments()
        {

            try
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd2;
                string CmdString = "insert into department(department) values(@department1);" +
                                    "insert into department(department) values(@department2);";
                cmd2 = new MySqlCommand(CmdString, con);

                cmd2.Parameters.Add("@department1", MySqlDbType.VarChar, 50);
                cmd2.Parameters.Add("@department2", MySqlDbType.VarChar, 50);

                cmd2.Parameters["@department1"].Value = "Accounts";
                cmd2.Parameters["@department2"].Value = "Administration";

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private static void fillingCategories()
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                MySqlCommand cmd2;
                string CmdString = "insert into file_categories(categoryname) values(@categoryname1);"+
                                   "insert into file_categories(categoryname) values(@categoryname2);"+
                                   "insert into file_categories(categoryname) values(@categoryname3);"+
                                   "insert into file_categories(categoryname) values(@categoryname4);"+
                                   "insert into file_categories(categoryname) values(@categoryname5);"+
                                   "insert into file_categories(categoryname) values(@categoryname6);"+
                                   "insert into file_categories(categoryname) values(@categoryname7);"+
                                   "insert into file_categories(categoryname) values(@categoryname8);"+
                                   "insert into file_categories(categoryname) values(@categoryname9);"+
                                   "insert into file_categories(categoryname) values(@categoryname10);"+
                                   "insert into file_categories(categoryname) values(@categoryname11);"+
                                   "insert into file_categories(categoryname) values(@categoryname12);"+
                                   "insert into file_categories(categoryname) values(@categoryname13);"+
                                   "insert into file_categories(categoryname) values(@categoryname14);"+
                                   "insert into file_categories(categoryname) values(@categoryname15);"+
                                   "insert into file_categories(categoryname) values(@categoryname16);"+
                                   "insert into file_categories(categoryname) values(@categoryname17);"+
                                   "insert into file_categories(categoryname) values(@categoryname18);"+
                                   "insert into file_categories(categoryname) values(@categoryname19);"+
                                   "insert into file_categories(categoryname) values(@categoryname20);"+
                                   "insert into file_categories(categoryname) values(@categoryname21);"+
                                   "insert into file_categories(categoryname) values(@categoryname22);"+
                                   "insert into file_categories(categoryname) values(@categoryname23);"+
                                   "insert into file_categories(categoryname) values(@categoryname24);"+
                                   "insert into file_categories(categoryname) values(@categoryname25);";

                cmd2 = new MySqlCommand(CmdString, con);

                cmd2.Parameters.Add("@categoryname1", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname2", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname3", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname4", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname5", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname6", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname7", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname8", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname9", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname10", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname11", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname12", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname13", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname14", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname15", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname16", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname17", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname18", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname19", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname20", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname21", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname22", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname23", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname24", MySqlDbType.VarChar, 100);
                cmd2.Parameters.Add("@categoryname25", MySqlDbType.VarChar, 100);



                cmd2.Parameters["@categoryname1"].Value = "Office Order";
                cmd2.Parameters["@categoryname2"].Value = "Raj Bhawan Letter";
                cmd2.Parameters["@categoryname3"].Value = "Notification";
                cmd2.Parameters["@categoryname4"].Value = "Pay Order";
                cmd2.Parameters["@categoryname5"].Value = "Circular Proceedings";
                cmd2.Parameters["@categoryname6"].Value = "MU Orders And Notifications";
                cmd2.Parameters["@categoryname7"].Value = "Appointment Letter";
                cmd2.Parameters["@categoryname8"].Value = "Pension Related Files";
                cmd2.Parameters["@categoryname9"].Value = "UGC Files";
                cmd2.Parameters["@categoryname10"].Value = "Pay Fixations";
                cmd2.Parameters["@categoryname11"].Value = "Joining Reports";
                cmd2.Parameters["@categoryname12"].Value = "Budget";
                cmd2.Parameters["@categoryname13"].Value = "Audit Reports";
                cmd2.Parameters["@categoryname14"].Value = "Cash Book Register";
                cmd2.Parameters["@categoryname15"].Value = "Salary Invoice";
                cmd2.Parameters["@categoryname16"].Value = "Provident Fund Register";
                cmd2.Parameters["@categoryname17"].Value = "Salary Register";
                cmd2.Parameters["@categoryname18"].Value = "Vouchers";
                cmd2.Parameters["@categoryname19"].Value = "Income Tax Files"; 
                cmd2.Parameters["@categoryname20"].Value = "Dispatch Register";
                cmd2.Parameters["@categoryname21"].Value = "Notices";
                cmd2.Parameters["@categoryname22"].Value = "Group Insurances";
                cmd2.Parameters["@categoryname23"].Value = "Shop Related Rent Files";
                cmd2.Parameters["@categoryname24"].Value = "Housing Loan Files";
                cmd2.Parameters["@categoryname25"].Value = "Annual Report Files";

                con.Open();
                cmd2.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex)
            {
                //MetroMessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
