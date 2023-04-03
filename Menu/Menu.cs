using System;
using SilevenText.Entity;
using SilevenText.Authorization;
using System.Linq;
using System.Text;
using System.Xml;
using SilevenText.Cipher;

namespace SilevenText.MenuNamespace
{
    internal class Menu
    {
        public void Start()
        {
            //authorization process
            bool authorization = IsSignedUp();

            if (authorization)
            {
                Register();  
            }
            else
            {
                Login();
            }

            while (true)
            {
                Console.WriteLine("What do you want to do?");
                Console.WriteLine("1. Encrypt text(text will be inputed)");
                Console.WriteLine("2. Decrypt text(text will be inputed)");
                Console.WriteLine("3. Encrypt text(text will be taken from the file)");
                Console.WriteLine("4. Decrypt text(text will be taken from the file)");
                Console.WriteLine("5. EXIT");

                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS
                //TRY CATCH ANSWERS + FILE CLEARNESS

                string choice = Console.ReadLine();
                switch(choice[0]) 
                {
                    case '1':
                        EncryptText();
                        break;
                    case '2':
                        DecryptText();
                        break;
                    case '3':
                        EncryptFile();
                        break;
                    case '4':
                        DecryptFile();
                        break;
                    case '5':
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        private int CipherChoosing()
        {
            Console.WriteLine("Which cipher do you want to use?: ");
            Console.WriteLine("1. Caesar cipher.");
            Console.WriteLine("2. MECipher(improved Caesar's cipher).");
            Console.WriteLine("3. Vigenere Cipher.");

            string choice = Console.ReadLine();

            switch (choice[0])
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                default:
                    return 4;
            }
        }
        private void CipherText(int action, int type=0)
        {
            int cipher = CipherChoosing();
            string text;

            if (type == 0)
            {
                Console.Write("Input text: ");
                text = Console.ReadLine();
            }
            else
            {
                Console.Write("Input file path:");
                string path = Console.ReadLine();

                text = System.IO.File.ReadAllText(path);
            }

            string result;

            if (cipher == 1)
            {
                CaesarCipher caesarCipher = new CaesarCipher();

                Console.WriteLine("Input shift: ");

                int shift;
                try
                {
                    shift = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Your value is incorrect, the shift is 3.");
                    shift = 3;
                }

                if (action == 0)
                {
                    result = caesarCipher.Encrypt(text, shift);
                }
                else 
                {
                    result = caesarCipher.Decrypt(text, shift);
                }
                
            }

            else if (cipher == 2)
            {
                MECipher mECipher = new MECipher();

                Console.WriteLine("Input shift: ");

                int shift;
                try
                {
                    shift = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Your value is incorrect, the shift is 5.");
                    shift = 5;
                }

                if (action == 0)
                {
                    result = mECipher.Encrypt(text, shift);
                }
                else
                {
                    result = mECipher.Decrypt(text, shift);
                }
            }

            else
            {
                VigenereCipher vigenere = new VigenereCipher();

                Console.WriteLine("Input key-word: ");

                string keyWord = Console.ReadLine();

                if (action == 0)
                {
                    result = vigenere.Encrypt(text, keyWord);
                }
                else
                {
                    result = vigenere.Decrypt(text, keyWord);
                }
            }
            
            if (type == 0)
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.Write("Enter path for save: ");
                string path = Console.ReadLine();

                System.IO.File.WriteAllText(path, result);
            }

            return;

        }
        private void EncryptText()
        {
            CipherText(0);
        }
        private void DecryptText()
        {
            CipherText(1);
        }
        private void EncryptFile()
        {
            CipherText(0, 1);
        }
        private void DecryptFile() 
        {
            CipherText(1, 1);
        }

        private void Register()
        {
            SignUp signUp = new SignUp();

            while (true)
            {
                string username = AskForUsername();
                string email = AskForEmail();
                string password = AskForPassword();

                User user = new User(username, email, password);

                if (signUp.Register(user) == true)
                {
                    Console.WriteLine("You have successfully signed up!");
                    break;
                }

                Console.Write("Do you want to try[t] again or use login function[l]?");
                string choice = (Console.ReadLine()).ToLower();

                if (choice[0] == 'l')
                {
                    Login();
                    break;
                }
            }
        }
        private void Login()
        {
            SignIn signIn = new SignIn();
            
            while (true)
            {
                string username = AskForUsername();
                string email = AskForEmail();
                string password = AskForPassword();

                User user = new User(username, email, password);

                if (signIn.Login(user) == true)
                {
                    Console.WriteLine("You have successfully signed in!");
                    break;
                }

                Console.Write("Do you want to try again[t] or use registration function[r]?");
                string choice = (Console.ReadLine()).ToLower();

                if (choice[0] == 'r')
                {
                    Register();
                    break;
                }
            }
        }
        private string AskForUsername()
        {
            string username = string.Empty;

            Console.Write("[Username has to have more than 3 symbols] Input username: ");
            username = Console.ReadLine();

            //check for its validnost'

            return username;
        }
        private string AskForPassword()
        {
            string password = string.Empty;

            Console.Write("[Password has to be longer than 5 symbols] Input password: ");
            password = Console.ReadLine();

            //check for its validnost'

            return password;
        }
        private string AskForEmail()
        {
            string email  = string.Empty;

            Console.Write("Input email: ");
            email  = Console.ReadLine();

            //check for its validnost'

            return email;
        }
        private bool IsSignedUp() 
        {
            Console.Write("Do you want to Sign Up(Register[U/R]) or Sign In(Login[I/L])?: ");
            string result = Console.ReadLine();
            result = result.ToUpper();

            if (result[0] == 'I' || result[0] == 'L') 
            {
                return false;
            }

            return true;
        }
    }
}
