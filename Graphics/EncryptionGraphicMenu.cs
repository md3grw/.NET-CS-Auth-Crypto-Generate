using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class EncryptionGraphicMenu : ObjectDrawer, IGraphicMenu
    {
        public void DrawMenu(int choice)
        {
            if (choice == 0)
            {
                DrawEncryptSign(ConsoleColor.Green);
                DrawDecryptSign(ConsoleColor.White);
            }
            else
            {
                DrawEncryptSign(ConsoleColor.White);
                DrawDecryptSign(ConsoleColor.Green);
            }
        }

        public void DrawEncryptSign(ConsoleColor color)
        {
            DrawRectangle(20, 2, 40, 10, color);
            PrintText(37, 6, "ENCRYPT", color);
        }

        public void DrawDecryptSign(ConsoleColor color)
        {
            DrawRectangle(20, 22, 40, 10, color);
            PrintText(37, 26, "DECRYPT", color);
        }
    }
}
