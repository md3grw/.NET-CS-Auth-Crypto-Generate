using SilevenText.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Menu
{
    internal class TextInput
    {
        static public string AskForText(string text)
        {
            Console.Clear();

            GameGraphics gameGraphics = new GameGraphics();
            gameGraphics.PrintText(30, 18, text, ConsoleColor.Red);
            Console.SetCursorPosition(30, 19);

            return Console.ReadLine();
        }
    }
}
