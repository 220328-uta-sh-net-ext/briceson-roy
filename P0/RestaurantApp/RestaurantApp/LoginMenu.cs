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
                    var Username = Console.ReadLine();
                    List<User> nameResult = bL.GetUserName(Username);
                    if(nameResult.Count > 0)
                    {
                        Console.WriteLine("Enter Password: ");
                        var Password = Console.ReadLine();
                        List<User> passResult = bL.GetPassword(Password);
                        if(passResult.Count > 0)
                        {
                            Console.WriteLine("Successful Login");
                            return "MainMenu";
                        }
                        else
                        {
                        Console.WriteLine("UserName or Password is invalid. Try again...");
                        goto case "1";
                         }
                    }
                    Console.WriteLine("Please enter Valid UserName");
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
