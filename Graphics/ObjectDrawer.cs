using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class ObjectDrawer : Drawer
    {
        public void DrawRectangle(int x, int y, int sizeX, int sizeY, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);

            DrawLineX(x, y, sizeX, color);
            DrawLineY(x, y, sizeY, color);
         
            DrawLineX(x, y+sizeY, sizeX, color);
            DrawLineY(x+sizeX, y, sizeY+1, color);
        }

        public void DrawSquare(int x, int y, int size, ConsoleColor color)
        {
            DrawRectangle(x, y, size*2, size, color);
        }
    }
}
