using SilevenText.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

            string username = EGetLine();

            return username;
        }

        static private string EGetLine()
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9\s@,.]*$");
            
            string username = "";
            
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) throw new EscapeException();
                
                if (key.Key == ConsoleKey.Backspace && username.Length > 0)
                {
                    username = username.Substring(0, username.Length - 1);

                    Console.Write("\b \b");
                }
                
                if (regex.IsMatch(key.KeyChar.ToString()))
                {
                    username += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                
                if (key.Key == ConsoleKey.Enter) return username.TrimEnd('\r');
            }
        }
    }
}
