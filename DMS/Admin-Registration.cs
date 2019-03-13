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

namespace DMS
{
    public partial class Admin_Registration : MetroForm
    {
        public Admin_Registration()
        {
            InitializeComponent();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
            metroTextBox5.Text = "";
            metroTextBox6.Text = "";

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            int status = validate_form();
            if (status == 0)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(Properties.Settings.Default.ConnectionString);
                    MySqlCommand cmd2;
                    string CmdString = "insert into admin(admin_id,admin_name,password,contact,email) values(@admin_id,@admin_name,@pass,@contact,@pump_add);";
                    cmd2 = new MySqlCommand(CmdString, con);
                    cmd2.Parameters.Add("@admin_id", MySqlDbType.VarChar, 100);
                    cmd2.Parameters.Add("@admin_name", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@pass", MySqlDbType.VarChar, 50);
                    cmd2.Parameters.Add("@contact", MySqlDbType.VarChar, 10);
                    cmd2.Parameters.Add("@pump_add", MySqlDbType.VarChar, 300);

                    cmd2.Parameters["@admin_id"].Value = metroTextBox6.Text;
                    cmd2.Parameters["@admin_name"].Value = metroTextBox1.Text;
                    cmd2.Parameters["@pass"].Value = metroTextBox2.Text;
                    cmd2.Parameters["@contact"].Value = metroTextBox5.Text;
                    cmd2.Parameters["@pump_add"].Value = metroTextBox4.Text;

                    con.Open();
                    int RowsAffected = cmd2.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MetroMessageBox.Show(this, "\nAdmin Registred Succesfully !", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.Dispose();
                        //show launch creen.......
                        new LaunchScreen().Show();
                        con.Close();
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

        private int validate_form()
        {
            if (metroTextBox1.Text == "" || metroTextBox2.Text == "" || metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroTextBox6.Text == "")
            {
                MetroMessageBox.Show(this, "\nAll Fields Are Mandetory ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                if (metroTextBox1.Text == "") metroTextBox1.WithError = true;
                if (metroTextBox2.Text == "") metroTextBox2.WithError = true;
                if (metroTextBox3.Text == "") metroTextBox3.WithError = true;
                if (metroTextBox4.Text == "") metroTextBox4.WithError = true;
                if (metroTextBox5.Text == "") metroTextBox5.WithError = true;
                if (metroTextBox6.Text == "") metroTextBox6.WithError = true;

                return 1;

            }

            if (metroTextBox5.Text.Length != 10)
            {
                MetroMessageBox.Show(this, "\nContact Should Be Ten Digit Long ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                metroTextBox5.WithError = true;
                
                return 1;
            }

            if (metroTextBox2.Text != metroTextBox3.Text)
            {
                MetroMessageBox.Show(this, "\nBoth Password Field Sholud Be Same ! ", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                metroTextBox2.WithError = true;
                metroTextBox3.WithError = true;
                return 1;
            }

            return 0;
            
            
        }

        private void metroTextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsDigit(e.KeyChar) || (e.KeyChar == (char)Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void metroTextBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
