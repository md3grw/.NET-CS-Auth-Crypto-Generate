using SilevenText.WorkWithFiles;
using SilevenText.Entity;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace SilevenText.Data
{
    //There are functions that are connected with DataBase.
    internal class DataBase
    {
        private List<User> users;

        private readonly string path;

        public DataBase()
        {
            path = "../../DB.json";

            users = new List<User>();
        }
        
        public List<User> LoadUsers() 
        {
            try
            {
                string jsonUsers = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<User>>(jsonUsers);
            }
            catch
            {   
                return new List<User>();
            }
        }

        public void SaveUsers()
        {
            string jsonUsers = JsonConvert.SerializeObject(users);

            File.WriteAllText(path, jsonUsers);
        }

        public void AddUser(User user) 
        {
            try
            {
                users = LoadUsers();
                users.Add(user);
            }
            catch 
            {
                users= new List<User>();
                users.Add(user);
            }

            SaveUsers();

            users.Clear();
        }

        public void RemoveUser(User user) 
        {
            users = LoadUsers();

            users.Remove(user);

            SaveUsers();

            users.Clear();
        }

        public void ChangeName(User user, string newName) 
        {
            var index = users.IndexOf(user);
            users[index].Username = newName;
        }

        public bool IsUserExisted(User user, bool checkForPassword=false)
        {
            users = LoadUsers();

            if (users != null)
            {
                if (checkForPassword==false)
                {
                    foreach (User currentUser in users)
                    {
                        if (currentUser.Username == user.Username)
                        {
                            Clear();
                            return true;
                        }

                        else if (currentUser.Email == user.Email)
                        {
                            Clear();
                            return true;
                        }
                    }
                }
                else
                {
                    foreach (User currentUser in users)
                    {
                        if (currentUser.Username == user.Username && currentUser.Password == user.Password && currentUser.Email == user.Email)
                        {
                            Console.WriteLine(currentUser.Username + " " + user.Username);
                            Console.WriteLine(currentUser.Password + " " + user.Password);
                            Console.WriteLine(currentUser.Email + " " + user.Email);
                            Clear();
                            return true;
                        }
                    }
                }
                
            }

            Clear();

            return false;
        }

        public void ChangePassword(User user, string newPassword)
        {
            var index = users.IndexOf(user);
            users[index].Password = newPassword;
        }

        private void ShowUsers()
        {
            foreach(User us in users)
            {
                Console.WriteLine(us.Username + " " + us.Password);
            }
        }

        public void Clear()
        {
            if (users != null)
            {
                users.Clear();
            }
        }

        
    }
}
