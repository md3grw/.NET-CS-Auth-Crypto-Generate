using SilevenText.MenuNamespace;
using SilevenText.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SilevenText.Data;
using SilevenText.Graphics;

namespace SilevenText.ProgramBody
{
    internal class DataProcessor
    {
        public static void Begin()
        {
            Console.Title = "SILEVEN TEXT";

            DataBase dataBase = new DataBase();
            MenuNamespace.Menu menu = new MenuNamespace.Menu();

            Console.SetBufferSize(120, 80);
            Console.SetWindowSize(80, 40);

            GameGraphics gameGraphics = new GameGraphics();
            
            gameGraphics.PrintGameLogo();
            gameGraphics.PrintIntroduction();

            menu.Start();
        }
    }
}
