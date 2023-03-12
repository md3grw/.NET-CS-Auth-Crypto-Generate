//registration

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Authorization
{
    internal class SignUp
    {
        private void addUser(string username, string password)
        {
            //user has been added to the database 
        }

        public bool signUp(string username, string password)
        {
            if (!LoginValidator.isValid(username, password)) 
            {
                //try again or use login function
                return false;
            }
            else
            {
                //add crypted data to a file
                addUser(username, password);
                return true;
            }
        }
    }
}
