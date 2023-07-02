using SilevenText.Entity;
using System;
using SilevenText.Data;

namespace SilevenText.Authorization
{
    internal class SignUp
    {
        private void AddUser(User user)
        {
            DataBase dataBase = new DataBase();

            dataBase.AddUser(user);
        }

        public bool Register(User user)
        {
            if (!Validator.IsValid(user))
            {
                return false;
            }
            else 
            {
                AddUser(user);
                return true;
            }
        }
    }
}
