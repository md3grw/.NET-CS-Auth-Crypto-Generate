using System;
using SilevenText.Entity;
using SilevenText.Authorization;
using System.Linq;
using System.Text;
using System.Xml;
using SilevenText.Cipher;
using System.IO;
using SilevenText.Graphics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Newtonsoft.Json;
using SilevenText.WorkWithFiles;
using SilevenText.Menu;
using PasswordGenerator;
using System.Net;

namespace SilevenText.MenuNamespace
{
    internal class Menu
    {
        GameGraphics gameGraphics;
        bool isLogined;

        public Menu()
        {
            gameGraphics = new GameGraphics();
            isLogined = false;
        }

        public void Start()
        {
            int choice;

            while (true)
            {
                choice = ShowMenu(new GraphicMainMenu(), 4);

                if (choice == 0)
                {
                    choice = ShowMenu(new AuthenticationGraphicMenu(), 2);
                    HandleAuthorizationChoice(choice);
                }
                else if (choice == 1 && isLogined == true)
                {
                    TypeOfCipher encryptionType = ConvertChoiceToTOC(ShowMenu(new EncryptionTypeMenu(), 3));
                        if (encryptionType == TypeOfCipher.Null) continue;
                    CipherActionCode encryptOrDecrypt = ConvertChoiceToCAC(ShowMenu(new EncryptionGraphicMenu(), 2));
                        if (encryptOrDecrypt == CipherActionCode.Null) continue;
                    TypeOfSavings textSavingsType = ConvertChoiceToTOS(ShowMenu(new TextSaveGraphicMenu(), 2));
                        if (textSavingsType == TypeOfSavings.Null) continue;

                    new CipherHandler().HandleChoice(encryptionType, encryptOrDecrypt, textSavingsType);
                }
                else if (choice == 2 && isLogined == true)
                {
                    HandlePasswordGenerator();
                }
                else if (choice == 3)
                {
                    GameGraphics gameGraphics = new GameGraphics();
                    gameGraphics.PrintAboutAuthor();
                }
            }
            
        }

        private bool Register()
        {
            SignUp signUp = new SignUp();

            Console.Clear();

            string username = "";
            string password = "";
            string email = "";

            try
            {
                username = TextInput.AskForText("Please input username: ");
                password = TextInput.AskForText("Please input password: "); 
                email = TextInput.AskForText("Please input email: ");
            }
            
            catch (EscapeException)
            {
                return false;
            }

            User user = new User(username, email, password);

            if (signUp.Register(user) == true)
            {
                gameGraphics.PrintText(25, 24, "You have successfully signed up!", ConsoleColor.Red);
                Thread.Sleep(4000);
                isLogined = true;
                return true;
            }

            gameGraphics.PrintText(25, 24, "Please try again!", ConsoleColor.Red);
            gameGraphics.PrintText(25, 24, "Either login, email or password is wrong!", ConsoleColor.Red);
            Thread.Sleep(4000);
            return false;
        }
        private bool Login()
        {
            SignIn signIn = new SignIn();

            Console.Clear();

            string username = "";
            string password = "";
            string email = "";

            try
            {
                username = TextInput.AskForText("Please input username: ");
                password = TextInput.AskForText("Please input password: ");
                email = TextInput.AskForText("Please input email: ");
            }

            catch (EscapeException)
            {
                return false;
            }
            User user = new User(username, email, password);

            if (signIn.Login(user) == true)
            {
                gameGraphics.PrintText(25, 24, "You have successfully signed in!", ConsoleColor.Red);
                Thread.Sleep(4000);
                isLogined = true;
                return true;
            }

            gameGraphics.PrintText(25, 24, "Please try again!", ConsoleColor.Red);
            gameGraphics.PrintText(25, 24, "Either login, email or password is wrong!", ConsoleColor.Red);
            Thread.Sleep(4000);
            return false;
        }

        private void HandleAuthorizationChoice(int choice)
        {
            if (choice == 0)
            {
                Register();
            }
            else if (choice == 1)
            {
                Login();
            }
        }

        private void HandlePasswordGenerator()
        {
            string sLength = "";

            try { sLength = TextInput.AskForText("Please, input length of the password: "); }
            catch (EscapeException) { return; }
            
            int length;
         
            if (int.TryParse(sLength, out length)) { }
            else { length = 15; }

            string password = new PasswordGenerator.PasswordGenerator()
                .IncludeLowercase()
                .IncludeUppercase()
                .IncludeNumeric()
                .IncludeSpecial()
                .LengthRequired(length)
                .Next();

            new GameGraphics().PrintText(30, 25, "Your result is: ", ConsoleColor.Green);
            new GameGraphics().PrintText(30, 26, password, ConsoleColor.Green);
            new GameGraphics().PrintText(30, 27, "Press any button...", ConsoleColor.Green);
            Console.ReadKey(true);
            
        }

        private int ShowMenu(IGraphicMenu graphicMenu, int size)
        {
            Console.Clear();

            size--;
            int choice = 0;
            graphicMenu.DrawMenu(choice);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.S)
                {
                    if (choice == size) choice = 0;
                    else choice++;

                    graphicMenu.DrawMenu(choice);
                    continue;
                }

                else if (key.Key == ConsoleKey.W)
                {
                    if (choice == 0) choice = size;
                    else choice--;
                    
                    graphicMenu.DrawMenu(choice);
                    continue;
                }

                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();

                    return choice;
                }

                else if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }

            return -1;
        }

        private TypeOfCipher ConvertChoiceToTOC(int choice) 
        {
            if (choice == 0)
                return TypeOfCipher.Caesar;

            if (choice == 1)
                return TypeOfCipher.ME;

            else if (choice == 2)
                return TypeOfCipher.Vigenere;

            return TypeOfCipher.Null;
        }

        private CipherActionCode ConvertChoiceToCAC(int choice)
        {
            if (choice == 0)
                return CipherActionCode.Encryption;

            else if (choice == 1)
                return CipherActionCode.Decryption;

            return CipherActionCode.Null;
        }

        private TypeOfSavings ConvertChoiceToTOS(int choice)
        {
            if (choice == 0)
                return TypeOfSavings.ResultAsFile;

            else if (choice == 1)
                return TypeOfSavings.ResultAsText;

            return TypeOfSavings.Null;
        }

    }
}
