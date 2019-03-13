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

namespace DMS
{
    public partial class Settings : MetroForm
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            metroTextBox1.Text = Properties.Settings.Default.dbpath;

            metroTextBox5.Text = Properties.Settings.Default.ClientScreenHeight.ToString();
            metroTextBox4.Text = Properties.Settings.Default.ClientScreenWidth.ToString();

            listingAllThemes();

            readingSettings();

        }

        private void readingSettings()
        {
            switch (Properties.Settings.Default.DefaultFormStyleColor)
            {
                case 0:
                    this.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Default;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Default;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Default;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Default;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Default;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Default;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Default;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Default;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Default;

                    break;
                case 1:
                    this.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Black;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Black;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Black;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Black;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Black;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Black;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Black;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Black;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Black;

                    break;
                case 2:
                    this.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.White;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.White;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.White;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.White;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.White;
                    metroButton1.Style = MetroFramework.MetroColorStyle.White;
                    metroButton2.Style = MetroFramework.MetroColorStyle.White;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.White;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.White;

                    break;
                case 3:
                    this.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Silver;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Silver;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Silver;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Silver;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Silver;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Silver;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Silver;

                    break;
                case 4:
                    this.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Blue;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Blue;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Blue;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Blue;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Blue;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Blue;

                    break;
                case 5:
                    this.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Green;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Green;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Green;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Green;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Green;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Green;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Green;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Green;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Green;

                    break;
                case 6:
                    this.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Lime;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Lime;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Lime;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Lime;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Lime;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Lime;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Lime;

                    break;
                case 7:
                    this.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Teal;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Teal;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Teal;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Teal;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Teal;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Teal;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Teal;

                    break;
                case 8:
                    this.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Orange;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Orange;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Orange;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Orange;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Orange;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Orange;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Orange;

                    break;
                case 9:
                    this.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Brown;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Brown;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Brown;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Brown;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Brown;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Brown;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Brown;

                    break;
                case 10:
                    this.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Pink;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Pink;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Pink;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Pink;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Pink;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Pink;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Pink;

                    break;
                case 11:
                    this.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Magenta;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Magenta;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Magenta;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Magenta;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Magenta;

                    break;
                case 12:
                    this.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Purple;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Purple;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Purple;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Purple;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Purple;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Purple;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Purple;

                    break;
                case 13:
                    this.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Red;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Red;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Red;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Red;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Red;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Red;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Red;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Red;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Red;

                    break;
                case 14:
                    this.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    //metroTextBox2.Style = MetroFramework.MetroColorStyle.Yellow;
                    //metroTextBox3.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox4.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroTextBox5.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroComboBox1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroButton1.Style = MetroFramework.MetroColorStyle.Yellow;
                    metroButton2.Style = MetroFramework.MetroColorStyle.Yellow;
                    //metroButton3.Style = MetroFramework.MetroColorStyle.Yellow;
                    //metroButton4.Style = MetroFramework.MetroColorStyle.Yellow;

                    break;
            }
        }

        private void detectClientScreen()
        {
            metroTextBox4.Text = SystemInformation.VirtualScreen.Width.ToString();
            metroTextBox5.Text = SystemInformation.VirtualScreen.Height.ToString();
        }

        private void listingAllThemes()
        {
            Dictionary<string, string> formthemes = new Dictionary<string, string>();

            formthemes.Add("0", "Defalut");
            formthemes.Add("1", "Black");
            formthemes.Add("2", "White");
            formthemes.Add("3", "Silver");
            formthemes.Add("4", "Blue");
            formthemes.Add("5", "Green");
            formthemes.Add("6", "Lime");
            formthemes.Add("7", "Teal");
            formthemes.Add("8", "Orange");
            formthemes.Add("9", "Brown");
            formthemes.Add("10", "Pink");
            formthemes.Add("11", "Magenta");
            formthemes.Add("12", "Purple");
            formthemes.Add("13", "Red");
            formthemes.Add("14", "Yellow");

            metroComboBox1.DataSource = new BindingSource(formthemes, null);
            metroComboBox1.DisplayMember = "Value";
            metroComboBox1.ValueMember = "Key";
            metroComboBox1.SelectedIndex = Properties.Settings.Default.DefaultFormStyleColor;

        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            detectClientScreen();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string folder = folderBrowserDialog1.SelectedPath;
                metroTextBox1.Text = folder;
            }
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string formDefaultColor = ((KeyValuePair<string, string>)metroComboBox1.SelectedItem).Value;
            if (formDefaultColor == "Defalut")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 0;
            }
            else if (formDefaultColor == "Black")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 1;
            }
            else if (formDefaultColor == "White")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 2;
            }
            else if (formDefaultColor == "Silver")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 3;
            }
            else if (formDefaultColor == "Blue")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 4;
            }
            else if (formDefaultColor == "Green")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 5;
            }
            else if (formDefaultColor == "Lime")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 6;
            }
            else if (formDefaultColor == "Teal")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 7;
            }
            else if (formDefaultColor == "Orange")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 8;
            }
            else if (formDefaultColor == "Brown")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 9;
            }
            else if (formDefaultColor == "Pink")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 10;
            }
            else if (formDefaultColor == "Magenta")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 11;
            }
            else if (formDefaultColor == "Purple")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 12;
            }
            else if (formDefaultColor == "Red")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 13;
            }
            else if (formDefaultColor == "Yellow")
            {
                Properties.Settings.Default.DefaultFormStyleColor = 14;
            }

            Properties.Settings.Default.ClientScreenHeight = Convert.ToInt32(metroTextBox5.Text);
            Properties.Settings.Default.ClientScreenWidth = Convert.ToInt32(metroTextBox4.Text);
            Properties.Settings.Default.dbpath = metroTextBox1.Text.ToString();

            Properties.Settings.Default.Save();
            //this.Dispose();
            this.Hide();
            //MetroMessageBox.Show(this.MdiParent, "\nSettings Saved Successfully. Please Restart Application To Reflact Changes!", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Question);
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.checked_checkbox_48;
            popup.ImagePadding = new Padding(20, 20, 20, 20);
            popup.TitleText = "Alert";

            popup.ContentText = "\nSettings Saved Successfully. Please Restart Application To Reflact Changes!";
            popup.Popup();
        }
    }
}
