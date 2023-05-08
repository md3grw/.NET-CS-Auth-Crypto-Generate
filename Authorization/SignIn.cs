//Login
using SilevenText.Entity;
using System;

namespace SilevenText.Authorization
{
    internal class SignIn
    {
        public bool Login(User user)
        {
            Validator validator= new Validator();
            if (!validator.IsLoginValid(user))
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
