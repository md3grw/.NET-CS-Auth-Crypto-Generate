using System;
using SilevenText.Entity;
using SilevenText.Authorization;
using System.Linq;
using System.Text;
using System.Xml;

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

            //program's logic process

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
