using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class TextSaveGraphicMenu : ObjectDrawer, IGraphicMenu
    {
        public void DrawMenu(int choice)
        {
            if (choice == 0)
            {
                DrawFileChooseSign(ConsoleColor.Green);
                DrawInputChooseSign(ConsoleColor.White);
            }
            else
            {
                DrawFileChooseSign(ConsoleColor.White);
                DrawInputChooseSign(ConsoleColor.Green);
            }
        }

        public void DrawFileChooseSign(ConsoleColor color)
        {
            DrawRectangle(20, 2, 40, 10, color);
            PrintText(37, 6, "RESULT AS A FILE", color);
        }

        public void DrawInputChooseSign(ConsoleColor color)
        {
            DrawRectangle(20, 22, 40, 10, color);
            PrintText(37, 26, "RESULT AS TEXT", color);
        }
    }
}
