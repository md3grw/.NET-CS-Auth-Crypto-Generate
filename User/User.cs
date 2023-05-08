using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Entity
{
    internal class User
    {
        private string username;
        private string password;
        private string email;

        public string Username 
        {
            get { return username; }
            set { username = value; } 
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }


        public User(string username, string email, string password)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }

        public User()
            : this("null", "null", "null")
        {

        }
    }
}
