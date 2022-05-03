using RestaurantDL;
using RestaurantModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    public class RegisterUser : IMenu
    {
        private static User newAccount = new User();
        private IRepository _repository = new SqlRepository();

        public void Display()
        {
            Console.WriteLine("Please press <1> to input a valid username and password");
            Console.WriteLine("Press <0> to return to the login menu");
        }

        //public bool ValidateUser()
        //{
        //    Console.WriteLine("Enter your username: ");
        //    var Username = Console.ReadLine();
        //    Console.WriteLine("Enter Password: ");
        //    var Password = Console.ReadLine();
        //    if (Username == null || Password == null)
        //    {
        //        return false;
        //    }
        //    else if (Username != Account.Username || Password != Account.Password)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        public string UserChoice()
        {
            Display();
           string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1" :
                Console.WriteLine("Enter your username: ");
                newAccount.Username = Console.ReadLine();
                    Console.WriteLine("Enter Password: ");
                    newAccount.Password = Console.ReadLine();
                    newAccount.isAdmin = false;
                    _repository.AddUser(newAccount);
                    
                    
                    return "LoginMenu";
                case "0" :
                    Console.WriteLine("Returning");
                    return "LoginMenu";
                default :
                    Console.WriteLine("Please input a valid response");
                    return "Register";
            }
        }
    }
}
