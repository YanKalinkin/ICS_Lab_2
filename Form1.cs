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

    public partial class Form1 : Form
    {
        int user_index;
        int counter = 0;
        public static Form1 Main;
        public Form1()
        {
            InitializeComponent();
            Main = this;
            button2.Visible = false;
        }

        void button1_Click(object sender, EventArgs e)
        {
            Data.auth = false;
            Data.admin_auth = false;
            for (int i = 0; i < Data.users.Length; i++)
            {
                if ((textBox1.Text == Data.users[i]) && (textBox2.Text == Data.passwords[i]))
                {
                    Data.auth = true;
                    user_index = i;
                    if (Data.rights[i][12] == '1')
                    {
                        Data.admin_auth = true;
                    }
                    break;
                }            
            }
            if(Data.auth)
            {
                if(Data.admin_auth)
                {
                    Data.user_current = Data.users[user_index];
                    Data.rights_current = Data.rights[user_index];
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.Show();
                }
                else
                {
                    Data.user_current = Data.users[user_index];
                    Data.rights_current = Data.rights[user_index];
                    this.Hide();
                    Form3 f3 = new Form3();
                    f3.Show();
                }
            }
            else
            {
                counter++;
                if(counter < 3)
                {
                    MessageBox.Show("Wrong username or password!" + '\n' + (3 - counter) + " attempts left.");
                }
                else
                {
                    MessageBox.Show("Access denied!");
                    this.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int length_ = File.ReadAllLines(@"B:\ICS\Users.txt", Encoding.Default).Length ;
         
            if (length_ >= 1)
            {
                Data.user_info_refresh();
                Data.auth = false;
                Data.admin_auth = false;
            }
            else
            {
                MessageBox.Show("No users available." + '\n' + "Ask your system administrator for support.");
                button2.Visible = true;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            Data.first_set = true;
            this.Hide();
            Form2 f2 = new Form2();
            f2.Show();
            button2.Visible = false;
        }
    }
}
