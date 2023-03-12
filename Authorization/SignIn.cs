//Login

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Authorization
{
    internal class SignIn
    {
        public bool signIn(string username, string password)
        {
            if (!LoginValidator.isValid(username, password))
            {
                //something went wrong with sign in function! Try again or use registration function
                return false;
            }
            else
            {
                //continue
                return true;
            }
        }
    }
}
