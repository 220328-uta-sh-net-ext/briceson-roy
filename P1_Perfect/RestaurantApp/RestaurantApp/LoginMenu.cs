using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBL;
using RestaurantDL;
using RestaurantModel;

namespace RestaurantUI
{
    internal class LoginMenu : IMenu
    {
        
        private IRepository _repository = new SqlRepository();
        readonly IBL bL;

        public LoginMenu(IBL bL)
        {
            this.bL = bL;
        }

        public void Display()
        {
            Console.WriteLine("Welcome to the Restaurant Review App");
            Console.WriteLine("If you are a returning User press <1> to login");
            Console.WriteLine("If you are a new User press <2> to register");
            Console.WriteLine("To exit the App please press <0>");
        }

      

        public string UserChoice()
        {
            Display();             
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter your username: ");
                    string Username = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    string Password = Console.ReadLine();
                    List<User> nameResult = bL.GetUserAccount(Username, Password);
                    if (nameResult.Count > 0)
                    {
                        bool isAdmin = nameResult[0].isAdmin;
                        if (isAdmin)
                        {
                            Log.Information($"Admin {Username}, has logged in.");
                            return "AdminMenu";
                        }
                        Log.Information($"User, {Username}, has logged in");
                        return "MainMenu";
                    }
                    else
                    {
                        Console.WriteLine("UserName or Password is invalid. Try again...");
                        goto case "1";
                    }
                    goto case "1";
                case "2":
                    Console.WriteLine("Heading to registration");
                    return "Register";
                case "0":
                    return "Exit";
                default:
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "LoginMenu";
            }
        }
    }
}
