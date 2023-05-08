using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class Drawer
    {
        public void DrawLineX(int x, int y, int length, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y); 

            for (int i = 0; i < length; i++) 
            {
                Console.ForegroundColor = color;
                Console.Write("█");
            }

            Console.ForegroundColor= ConsoleColor.White;
        }

        public void DrawLineY(int x, int y, int length, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            for (int i = y; i < y+length; i++)
            {
                Console.SetCursorPosition(x, i);
                Console.Write("█");
            }

            Console.ForegroundColor = ConsoleColor.White;

        }

        public void PrintText(int x,int y, string text, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(text);

            Console.ForegroundColor= ConsoleColor.White;
        }
    }
}
