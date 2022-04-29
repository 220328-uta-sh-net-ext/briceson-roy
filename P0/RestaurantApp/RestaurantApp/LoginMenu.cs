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
 
        public void Display()
        {
            Console.WriteLine("If you are a new User press <1> to login");
            Console.WriteLine("To exit the App please press <0>");
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
                    Console.WriteLine("Enter your username: ");
                    var Username = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    var Password = Console.ReadLine();
                    if (Username == && Password ==)
                    {

                    }
                    else if(Username == && Password == )
                    {

                    }
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
