using RestaurantDL;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class RegisterUser : IMenu
    {
        private static User newAccount = new User();
        private IRepository _repository = new SqlRepository();

        public void Display()
        {
            Console.WriteLine("Please press <1> to input a valid username and password");
            Console.WriteLine("Press <0> to return to the login menu");
        }

        public string UserChoice()
        {
           string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1" :
                Console.WriteLine("Enter your username: ");
                newAccount.Username = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    newAccount.Password = Console.ReadLine();
                    _repository.AddUser(newAccount);
                    return "Log successful";
                case "0" :
                    Console.WriteLine("Returning");
                    return "Login Menu";
                default :
                    Console.WriteLine("Please input a valid response");
                    return "Try again with valid information";
            }
        }
    }
}
