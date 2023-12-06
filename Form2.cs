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
    public partial class Form2 : Form
    {
        int user_rights_to_change;
        string right_to_change;
        string right_now;
        //TextBox
        string read_textbox;
        string write_textbox;
        string modify_textbox;
        //ComboBox
        string read_combobox;
        string write_combobox;
        string modify_combobox;
        //Button
        string read_button;
        string write_button;
        string modify_button;
        //numeric
        string read_numeric;
        string write_numeric;
        string modify_numeric;
        //Admin
        string admin_;

        string new_user;
        string user_rights;

        string[] to_search = new string[7];

        public Form2()
        {
            InitializeComponent();
        }

        void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Data.auth = false;
            Data.admin_auth = false;
            Form1.Main.Show();
        }

        //ADD USER
        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text != "")&&(textBox2.Text == textBox3.Text))
            {
                if(File.ReadAllLines(@"B:\ICS\Users.txt", Encoding.Default).Length >= 7)
                {
                    MessageBox.Show("User amount can not be bigger than 7." + '\n' + "Please delete users to create new accounts.");
                }
                else
                {
                    user_rights = "";
                    //TextBox
                    if (checkBox1.Checked)
                        read_textbox = "1";
                    else read_textbox = "0";

                    if (checkBox2.Checked)
                        write_textbox = "1";
                    else write_textbox = "0";

                    if (checkBox3.Checked)
                        modify_textbox = "1";
                    else modify_textbox = "0";
                    //ComboBox
                    if (checkBox12.Checked)
                        read_combobox = "1";
                    else read_combobox = "0";

                    if (checkBox11.Checked)
                        write_combobox = "1";
                    else write_combobox = "0";

                    if (checkBox10.Checked)
                        modify_combobox = "1";
                    else modify_combobox = "0";
                    //Button
                    if (checkBox14.Checked)
                        read_button = "1";
                    else read_button = "0";

                    if (checkBox13.Checked)
                        write_button = "1";
                    else write_button = "0";

                    if (checkBox9.Checked)
                        modify_button = "1";
                    else modify_button = "0";
                    //Numeric
                    if (checkBox17.Checked)
                        read_numeric = "1";
                    else read_numeric = "0";

                    if (checkBox16.Checked)
                        write_numeric = "1";
                    else write_numeric = "0";

                    if (checkBox15.Checked)
                        modify_numeric = "1";
                    else modify_numeric = "0";
                    //Admin
                    if (checkBox4.Checked)
                        admin_ = "1";
                    else admin_ = "0";

                    user_rights = "";
                    user_rights = read_textbox + write_textbox + modify_textbox + read_combobox + write_combobox + modify_combobox + read_button + write_button + modify_button + read_numeric + write_numeric + modify_numeric + admin_;

                    new_user = textBox1.Text + '|' + textBox2.Text + '*';
                    File.AppendAllText(@"B:\ICS\Users.txt", new_user + user_rights + '\n');

                    comboBox1.Items.Add(textBox1.Text);
                    Data.user_info_refresh();
                    textBox1.Text = "";
                    MessageBox.Show("User added successfully!");
                }  
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Data.common.Length > 0)
                comboBox1.Items.AddRange(Data.users);
        }

        //DELETE USER
        private void button2_Click(object sender, EventArgs e)
        {
            bool found = false;
            to_search = File.ReadAllLines(@"B:\ICS\Users.txt", Encoding.Default);
            for (int i = 0; i < to_search.Length; i++)
            {
                if (to_search[i].IndexOf(textBox4.Text) > -1)
                {
                    found = true;
                    to_search[i] = "";
                    for (int n = i; n < to_search.Length-1; n++)
                    {
                        to_search[n] = to_search[n + 1];
                    }
                    Array.Resize(ref to_search, to_search.Length - 1);
                    break;
                }
            }
            if (!found)
            {
                MessageBox.Show("User not found!");
            }
            else
            {
                File.WriteAllText(@"B:\ICS\Users.txt", string.Empty);
                for (int k = 0; k < to_search.Length; k++)
                {
                    File.AppendAllText(@"B:\ICS\Users.txt", to_search[k] + '\n');
                }
                comboBox1.Items.Remove(textBox4.Text);
                textBox4.Text = "";
                MessageBox.Show("User deleted successfully!");
            }  
        }

        //QUIT
        private void button3_Click(object sender, EventArgs e)
        {
            Data.auth = false;
            Data.admin_auth = false;
            this.Close();
            Form1.Main.Show();
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Data.user_info_refresh();
            for (int i = 0; i < Data.users.Length; i++)
            {
                if (comboBox1.SelectedItem.ToString() == Data.users[i])
                {
                    //MessageBox.Show("ZASHEL 2");
                    right_now = Data.rights[i];
                    user_rights_to_change = i;
                    break;
                }
            }
            //TextBox
            if (right_now[0] == '1')//TextBox Read
                checkBox8.Checked = true;
            else checkBox8.Checked = false;

            if (right_now[1] == '1')//TextBox Write
                checkBox7.Checked = true;
            else checkBox7.Checked = false;

            if (right_now[2] == '1')//TextBox Modify
                checkBox6.Checked = true;
            else checkBox6.Checked = false;
            //ComboBox
            if (right_now[3] == '1')//ComboBox Read
                checkBox27.Checked = true;
            else checkBox27.Checked = false;

            if (right_now[4] == '1')//ComboBox Write
                checkBox26.Checked = true;
            else checkBox26.Checked = false;

            if (right_now[5] == '1')//ComboBox Modify
                checkBox25.Checked = true;
            else checkBox25.Checked = false;
            //Button
            if (right_now[6] == '1')//Button Read
                checkBox24.Checked = true;
            else checkBox24.Checked = false;

            if (right_now[7] == '1')//Button Write
                checkBox23.Checked = true;
            else checkBox23.Checked = false;

            if (right_now[8] == '1')//Button Modify
                checkBox21.Checked = true;
            else checkBox21.Checked = false;
            //Numeric
            if (right_now[9] == '1')//Numeric Read
                checkBox20.Checked = true;
            else checkBox20.Checked = false;

            if (right_now[10] == '1')//Numeric Write
                checkBox19.Checked = true;
            else checkBox19.Checked = false;

            if (right_now[11] == '1')//Numeric Modify
                checkBox18.Checked = true;
            else checkBox18.Checked = false;
            //Admin
            if (right_now[12] == '1')//Admin
                checkBox5.Checked = true;
            else checkBox5.Checked = false;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        //CHANGE RIGHTS
        private void button4_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedItem.ToString().Length == 0)
            {
                MessageBox.Show("Please choose the user!");
            }
            else
            {
                //TextBox
                if (checkBox8.Checked)
                    read_textbox = "1";
                else read_textbox = "0";

                if (checkBox7.Checked)
                    write_textbox = "1";
                else write_textbox = "0";

                if (checkBox6.Checked)
                    modify_textbox = "1";
                else modify_textbox = "0";
                //ComboBox
                if (checkBox27.Checked)
                    read_combobox = "1";
                else read_combobox = "0";

                if (checkBox26.Checked)
                    write_combobox = "1";
                else write_combobox = "0";

                if (checkBox25.Checked)
                    modify_combobox = "1";
                else modify_combobox = "0";
                //Button
                if (checkBox24.Checked)
                    read_button = "1";
                else read_button = "0";

                if (checkBox23.Checked)
                    write_button = "1";
                else write_button = "0";

                if (checkBox21.Checked)
                    modify_button = "1";
                else modify_button = "0";
                //Numeric
                if (checkBox20.Checked)
                    read_numeric = "1";
                else read_numeric = "0";

                if (checkBox19.Checked)
                    write_numeric = "1";
                else write_numeric = "0";

                if (checkBox18.Checked)
                    modify_numeric = "1";
                else modify_numeric = "0";
                //Admin
                if (checkBox5.Checked)
                    admin_ = "1";
                else admin_ = "0";

                right_to_change = "";
                right_to_change = read_textbox + write_textbox + modify_textbox + read_combobox + write_combobox + modify_combobox + read_button + write_button + modify_button + read_numeric + write_numeric + modify_numeric + admin_;
                Data.rights[user_rights_to_change] = right_to_change;

                File.WriteAllText(@"B:\ICS\Users.txt", string.Empty);
                for (int k = 0; k < Data.users.Length; k++)
                {
                    File.AppendAllText(@"B:\ICS\Users.txt", Data.users[k] + '|' + Data.passwords[k] + '*' + Data.rights[k] + '\n');
                }
                Data.user_info_refresh();
                MessageBox.Show("User rights have been changed successfully!");
            }
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
