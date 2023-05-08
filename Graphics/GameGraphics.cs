using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SilevenText.Graphics
{
    internal class GameGraphics : ObjectDrawer
    {
        public void PrintGameLogo()
        {
            const int textX = 11;
            const int textY = 10;

            DrawRectangle(7, 8, 65, 20, ConsoleColor.Green);
            DrawLineY(8, 8, 20, ConsoleColor.Green);
            DrawLineY(8 + 63, 8, 20, ConsoleColor.Green);

            PrintText(textX, textY + 0, "  {__ __      {__", ConsoleColor.Magenta);
            PrintText(textX, textY + 1, "{__    {__ {_ {__", ConsoleColor.Magenta);
            PrintText(textX, textY + 2, " {__          {__   {__    {__     {__   {__    {__ {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 3, "   {__    {__ {__ {_   {__  {__   {__  {_   {__  {__  {__", ConsoleColor.Magenta);
            PrintText(textX, textY + 4, "      {__ {__ {__{_____ {__  {__ {__  {_____ {__ {__  {__", ConsoleColor.Magenta);
            PrintText(textX, textY + 5, "{__    {__{__ {__{_           {_{__   {_         {__  {__", ConsoleColor.Magenta);
            PrintText(textX, textY + 6, "  {__ __  {__{___  {____       {__      {____   {___  {__", ConsoleColor.Magenta);

            PrintText(textX, textY + 9, "{___ {______                     {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 10, "     {__                         {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 11, "     {__       {__    {__   {__{_{_ {_", ConsoleColor.Magenta);
            PrintText(textX, textY + 12, "     {__     {_   {__   {_ {__   {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 13, "     {__    {_____ {__   {_      {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 14, "     {__    {_         {_  {__   {__  ", ConsoleColor.Magenta);
            PrintText(textX, textY + 15, "     {__      {____   {__   {__   {__ ", ConsoleColor.Magenta);

            Console.SetCursorPosition(textX, 35);
            PrintText(27, 30, "Press any key to continue...", ConsoleColor.Green);
            Console.ReadKey();

            Console.Clear();
        }

        public void PrintIntroduction()
        {
            DrawRectangle(15, 8, 55, 12, ConsoleColor.Blue);

            //introduction
            PrintText(17, 10, "Dear User,", ConsoleColor.Green);
            PrintText(17, 11, "Thank you for downloading SilevenText application,", ConsoleColor.Green);
            PrintText(17, 12, "we really appreciate it.", ConsoleColor.Green);
            PrintText(17, 13, "Here you can crypt and find data in text.", ConsoleColor.Green);
            PrintText(17, 14, "For menu controls use W[goes upper] and S[goes down].", ConsoleColor.Green);
            PrintText(17, 15, "If you want to mute music, press M. ", ConsoleColor.Green);
            PrintText(17, 16, "Thanks for using our application!", ConsoleColor.Green);

            PrintText(17, 22, "Press any key to continue...", ConsoleColor.Green);
            Console.ReadKey();

            Console.Clear();
        }

        public void PrintAboutAuthor()
        {
            DrawRectangle(15, 8, 55, 12, ConsoleColor.Blue);

            //introduction
            PrintText(17, 10, "Author is a white male.", ConsoleColor.Green);
            PrintText(17, 11, "He is from Ukraine, but living in Latvia.", ConsoleColor.Green);
            PrintText(17, 12, "He is studying in school, interested in programming", ConsoleColor.Green);
            PrintText(17, 13, "This application he wrote due to the circumstances.", ConsoleColor.Green);
            PrintText(17, 14, "He got to write an application for his exam.", ConsoleColor.Green);
            PrintText(17, 15, "If you have any questions, you may write to him,", ConsoleColor.Green);
            PrintText(17, 16, "his Telegram is @md3grw.", ConsoleColor.Green);
            PrintText(17, 17, "Thanks for using our application!", ConsoleColor.Green);

            PrintText(17, 22, "Press any key to continue...", ConsoleColor.Green);
            Console.ReadKey();

            Console.Clear();
        }
    }
}
