using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class EncryptionTypeMenu : ObjectDrawer, IGraphicMenu
    {
        public void DrawMenu(int choice)
        {
            if (choice == 0)
            {
                DrawCaesarSign(ConsoleColor.Green);
                DrawMESign(ConsoleColor.White);
                DrawVigenereSign(ConsoleColor.White);
            }
            else if (choice == 1)
            {
                DrawCaesarSign(ConsoleColor.White);
                DrawMESign(ConsoleColor.Green);
                DrawVigenereSign(ConsoleColor.White);
            }
            else
            {
                DrawCaesarSign(ConsoleColor.White);
                DrawMESign(ConsoleColor.White);
                DrawVigenereSign(ConsoleColor.Green);
            }
        }

        public void DrawCaesarSign(ConsoleColor color)
        {
            DrawRectangle(20, 5, 40, 5, color);
            DrawLineY(21, 6, 5, color);
            DrawLineY(59, 6, 5, color);

            PrintText(37, 7, "CAESAR'S", color);
            PrintText(37, 8, "CIPHER", color);
        }

        public void DrawMESign(ConsoleColor color)
        {
            DrawRectangle(20, 19, 40, 5, color);
            DrawLineY(21, 19, 5, color);
            DrawLineY(59, 19, 5, color);

            PrintText(34, 21, "ME CIPHER", color);
        }

        public void DrawVigenereSign(ConsoleColor color)
        {
            DrawRectangle(20, 33, 40, 5, color);
            DrawLineY(21, 34, 5, color);
            DrawLineY(59, 34, 5, color);
            PrintText(34, 35, "VIGENERE CIPHER", color);
        }
    }
}
