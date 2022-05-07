using RestaurantDL;
using RestaurantBL;
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

        readonly IBL bL;

        public RegisterUser(IBL bL)
        {
            this.bL = bL;
        }

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
                newAccount.Username = newAccount.Username.Trim();
                    List<User> existingUsers = bL.GetUserName(newAccount.Username);
                    foreach (User user in existingUsers)
                    {
                        if (user.Username == newAccount.Username)
                        {
                            Console.WriteLine("Desired username is already in use please type in a new user");
                            goto case "1";
                        }
                        break;
                    }
                    Console.WriteLine("Enter Password: ");
                    newAccount.Password = Console.ReadLine();
                    newAccount.Password = newAccount.Password.Trim();   
                if (newAccount.Username.Length > 0 && newAccount.Password.Length > 0)
                {
                       
                        newAccount.isAdmin = false;
                        _repository.AddUser(newAccount);
                        Log.Information($"New User Created at {newAccount.Username} created successfully."); 
                }
               else{
                        Console.WriteLine("The Username and/or password can not be empty please input valid inputs");
                        goto case "1";
                }


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
