using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class GraphicMainMenu : ObjectDrawer, IGraphicMenu
    {
        public void DrawMenu(int choice)
        {
            DrawMenuSign();

            if (choice == 0)
            {
                DrawRegistrationSign(ConsoleColor.Green);
                DrawCiphersSign(ConsoleColor.White);
                DrawFindSign(ConsoleColor.White);
                DrawAboutAuthorSign(ConsoleColor.White);
            }

            else if (choice == 1)
            {
                DrawRegistrationSign(ConsoleColor.White);
                DrawCiphersSign(ConsoleColor.Green);
                DrawFindSign(ConsoleColor.White);
                DrawAboutAuthorSign(ConsoleColor.White);
            }

            else if (choice == 2)
            {
                DrawRegistrationSign(ConsoleColor.White);
                DrawCiphersSign(ConsoleColor.White);
                DrawFindSign(ConsoleColor.Green);
                DrawAboutAuthorSign(ConsoleColor.White);
            }

            else
            {
                DrawRegistrationSign(ConsoleColor.White);
                DrawCiphersSign(ConsoleColor.White);
                DrawFindSign(ConsoleColor.White);
                DrawAboutAuthorSign(ConsoleColor.Green);
            }
        }

        public void DrawMenuSign()
        {
            PrintText(17, 2, "{__       {__{________{___     {__{__     {__", ConsoleColor.Magenta);
            PrintText(17, 3, "{_ {__   {___{__      {_ {__   {__{__     {__", ConsoleColor.Magenta);
            PrintText(17, 4, "{__ {__ { {__{__      {__ {__  {__{__     {__", ConsoleColor.Magenta);
            PrintText(17, 5, "{__  {__  {__{______  {__  {__ {__{__     {__", ConsoleColor.Magenta);
            PrintText(17, 6, "{__   {_  {__{__      {__   {_ {__{__     {__", ConsoleColor.Magenta);
            PrintText(17, 7, "{__       {__{__      {__    {_ __{__     {__", ConsoleColor.Magenta);
            PrintText(17, 8, "{__       {__{________{__      {__  {_____   ", ConsoleColor.Magenta);
        }

        public void DrawRegistrationSign(ConsoleColor color)
        {
            DrawRectangle(20, 11, 40, 5, color);
            DrawLineY(21, 12, 5, color);
            DrawLineY(59, 12, 5, color);

            PrintText(37, 13, "SIGN IN", color);
            PrintText(37, 14, "SIGN UP", color);
        }

        public void DrawCiphersSign(ConsoleColor color)
        {
            DrawRectangle(20, 18, 40, 5, color);
            DrawLineY(21, 19, 5, color);
            DrawLineY(59, 19, 5, color);
            PrintText(37, 20, "CIPHERS", color);
        }

        public void DrawFindSign(ConsoleColor color)
        {
            DrawRectangle(20, 25, 40, 5, color);
            DrawLineY(21, 26, 5, color);
            DrawLineY(59, 26, 5, color);
            PrintText(34, 27, "GENERATE PASSWORD", color);
        }

        public void DrawAboutAuthorSign(ConsoleColor color)
        {
            DrawRectangle(20, 32, 40, 5, color);
            DrawLineY(21, 33, 5, color);
            DrawLineY(59, 33, 5, color);
            PrintText(34, 34, "ABOUT AUTHOR", color);
        }
    }
}
