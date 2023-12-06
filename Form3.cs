using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICS_Lab_2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Data.auth = false;
            Data.admin_auth = false;
            Form1.Main.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Data.user_current;
            label4.Text = Data.rights_current;
            string[] items_ = new string[] {"First", "Second", "Third"};
            comboBox1.Items.AddRange(items_);

            //textbox
            if (Data.rights_current[0] == '1')
                textBox1.UseSystemPasswordChar = false;
            else
                textBox1.UseSystemPasswordChar = true;

            if (Data.rights_current[1] == '1')
                textBox1.ReadOnly = false;
            else
                textBox1.ReadOnly = true;
            //combobox
            if (Data.rights_current[3] == '0')
            {
                comboBox1.Items.Clear();
            }
            if (Data.rights_current[4] == '0')
            {
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            if (Data.rights_current[5] == '0')
            {
               // comboBox1.Enabled = false;
            }
            //button
            if (Data.rights_current[6] == '0')
            {
                button1.Text = "***";
            }
            if (Data.rights_current[7] == '0')
            {
                button1.Enabled = false;
            }
            if (Data.rights_current[8] == '0')
            {
                button1.Visible = false;
            }
            //numeric
            if (Data.rights_current[9] == '0')
            {
                numericUpDown1.Enabled = false;
            }
            if (Data.rights_current[10] == '0')
            {
                numericUpDown1.ReadOnly = true;
            }
            if (Data.rights_current[11] == '0')
            {
                numericUpDown1.InterceptArrowKeys = false;
            }
            else
                numericUpDown1.InterceptArrowKeys = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.auth = false;
            Data.admin_auth = false;
            this.Close();
            Form1.Main.Show();
        }

        private void textBox1_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Data.rights_current[2] == '1')
            {
                if (textBox1.BackColor == Color.Green)
                {
                    textBox1.BackColor = Color.White;
                }
                else
                {
                    textBox1.BackColor = Color.Green;
                }
            }
           
        }
    }

    static class Data
    {
        public static string user_current;
        public static string rights_current;
        //public static string rights_current;

        public static bool username_filled = false;
        public static bool password_filled = false;

        public static string[] users = new string[7];
        public static string[] passwords = new string[7];
        public static string[] rights = new string[7];
        public static string[] common = new string[7];
        public static bool first_set = false;
        public static bool auth = false;
        public static bool admin_auth = false;
        public static void user_info_refresh()
        {
            int rows = File.ReadAllLines(@"B:\ICS\Users.txt", Encoding.Default).Length;
            Array.Resize(ref Data.common, rows);
            Array.Resize(ref Data.users, rows);
            Array.Resize(ref Data.passwords, rows);
            Array.Resize(ref Data.rights, rows);
            //
            for(int k = 0; k < rows; k++)
            {
                common[k] = string.Empty;
                users[k] = string.Empty;
                passwords[k] = string.Empty;
                rights[k] = string.Empty;
            }
            //
            Data.common = File.ReadAllLines(@"B:\ICS\Users.txt", Encoding.Default);
            username_filled = false;
            password_filled = false;
            for (int i = 0; i < Data.common.Length; i++)
            {
                for (int j = 0; j < Data.common[i].Length; j++)
                {
                    if (!username_filled)
                    {
                        if (Data.common[i][j] != '|')
                            Data.users[i] += Data.common[i][j];
                        else
                            username_filled = true;
                    }
                    else if (!password_filled)
                    {
                        if (Data.common[i][j] != '*')
                            Data.passwords[i] += Data.common[i][j];
                        else
                            password_filled = true;
                    }
                    else
                    {
                        Data.rights[i] += Data.common[i][j];
                    }
                }
                username_filled = false;
                password_filled = false;
            }
        }
    }
}
