using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICS_Lab_2
{
    internal class User
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public bool Read { get; set; }
        public bool Write { get; set; }
        public bool Modify { get; set; }
        public bool Admin_Is_Here { get; set; }
        public void get_rights(string rights)
        {
            if (rights[0] == '0')
                this.Read = false;
            else
                this.Read = true;

            if (rights[1] == '0')
                this.Write = false;
            else
                this.Write = true;

            if (rights[2] == '0')
                this.Modify = false;
            else
                this.Modify = true;

            if (rights[3] == '0')
                this.Admin_Is_Here = false;
            else
                this.Admin_Is_Here = true;
        }
    }
}
