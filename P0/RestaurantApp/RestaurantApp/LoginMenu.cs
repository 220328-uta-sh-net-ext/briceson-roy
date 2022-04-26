using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class LoginMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Restaurant Review App");
            Console.WriteLine("If you are a new User press <1> to look all restaurant");
            Console.WriteLine("If you are a returning User press <2> to search a restaurant");
            Console.WriteLine("To exit the App please press <x>");
        }

        public string UserChoice()
        {
            Display();
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "x":
                    return "Exit";
                case "r":
                    return "Register";
                case "l":
                    return "Login";
                default:
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "LoginMenu";
            }
        }
    }
}
