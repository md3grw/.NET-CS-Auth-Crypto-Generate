using SilevenText.MenuNamespace;
using SilevenText.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SilevenText.Data;

namespace SilevenText.ProgramBody
{
    internal class DataProcessor
    {
        public static void Begin()
        {
            DataBase dataBase = new DataBase();
            Menu menu = new Menu();

            dataBase.InitializeDataBase();

            menu.Start();
        }

        public static void End() 
        {

        }
    }
}
