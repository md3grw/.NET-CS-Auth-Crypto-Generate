using SilevenText.Entity;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.Remoting.Messaging;
using SilevenText.Data;

namespace SilevenText.Authorization
{
    internal class Validator
    {
        public static bool IsValid(User user)
        {
            Validator validator = new Validator();

            if (user == null) 
            {
                return false;
            }

            if (validator.IsUserExisted(user) == true)
            {
                return false;
            }

            if (validator.IsUsernameCorrect(user.Username) == false) 
            {
                return false;
            }

            if (validator.IsPasswordCorrect(user.Password) == false)
            {
                return false;
            }

            if (validator.IsEmailCorrect(user.Email) == false)
            {
                return false;
            }

            return true;
        }

        private bool IsUserExisted(User user) 
        {
            DataBase dataBase = new DataBase();

            dataBase.LoadUsers();

            bool result = dataBase.IsUserExisted(user);

            dataBase.Clear();

            return result;
        }

        private bool IsEmailCorrect(string email) 
        {
            Regex regex = new Regex(@"[a-z0-9_]+@[a-z]{2,20}\.[a-z]{2,15}");

            Match match = regex.Match(email);

            if (match.Success)
            {
                return true;
            }

            return false;
        }

        private bool IsUsernameCorrect(string username)
        {
            if (username.Length < 4)
            {
                return false;
            }

            foreach(var ch in username) 
            {
                if (ch == ' ')
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsPasswordCorrect(string password) 
        {
            if (password.Length < 6)
            {
                return false;
            }

            foreach (var ch in password)
            {
                if (ch == ' ')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
