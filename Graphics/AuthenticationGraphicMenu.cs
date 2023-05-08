using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class AuthenticationGraphicMenu : ObjectDrawer, IGraphicMenu
    {
        public void DrawMenu(int choice)
        {
            if (choice == 1)
            {
                DrawRegistrationButton(ConsoleColor.White);
                DrawLoginButton(ConsoleColor.Green);
            }

            else if (choice == 0)
            {
                DrawRegistrationButton(ConsoleColor.Green);
                DrawLoginButton(ConsoleColor.White);
            }
        }

        public void DrawLoginButton(ConsoleColor consoleColor)
        {
            DrawRectangle(20, 22, 40, 10, consoleColor);
            PrintText(37, 26, "SIGN IN", consoleColor);
        }

        public void DrawRegistrationButton(ConsoleColor consoleColor)
        {
            DrawRectangle(20, 2, 40, 10, consoleColor);
            PrintText(37, 6, "SIGN UP", consoleColor);
        }
    }
}
