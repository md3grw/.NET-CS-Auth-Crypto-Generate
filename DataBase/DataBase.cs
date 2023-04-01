using SilevenText.WorkWithFiles;
using SilevenText.Entity;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace SilevenText.Data
{
    internal class DataBase
    {
        private List<User> users;

        private readonly string path;

        public DataBase()
        {
            path = "../../DB.json";

            users = new List<User>();
        }

        public void InitializeDataBase()
        {
            FileManager fileManager = new FileManager();
            fileManager.CreateFile(path);
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

        public bool IsUserExisted(User user)
        {
            if (users != null && users.Count > 0)
            {
                foreach (var i in users)
                {
                    if (user.Username == i.Username)
                    {
                        return true;
                    }

                    if (user.Email == i.Email)
                    {
                        return true;
                    }
                }
            }

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
            users.Clear();
        }

        
    }
}
