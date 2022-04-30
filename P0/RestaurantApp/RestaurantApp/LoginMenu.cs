using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantModel;

namespace RestaurantUI
{
    internal class LoginMenu : IMenu
    {
        private static User Account = null;
        private IRepository _repository = new SqlRepository();

        public void Display()
        {
            Console.WriteLine("If you are a new User press <1> to login");
            Console.WriteLine("To exit the App please press <0>");
        }

        public bool ValidateUser()
        {
            Console.WriteLine("Enter your username: ");
            var Username = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            var Password = Console.ReadLine();
            if (Username == null || Password == null)
            {
                return false;
            }
            else if(Username != Account.Username|| Password != Account.Password)
            {
                return false;
            }
            else{
                return true;
            }
        }

        public string UserChoice()
        {
            Display();             
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    if (ValidateUser() == true)
                    {
                        return "MainMenu";
                    }
                    else 
                    {
                        Console.WriteLine("Username or Password was not correct please retry");
                        return "Login";
                    }
                default:
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "LoginMenu";
            }
        }
    }
}
