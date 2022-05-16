using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantBL;
using RestaurantModel;

namespace RestaurantUI
{
    internal class AdminMenu :IMenu
    {
        private IRepository _repository = new SqlRepository();
        readonly IBL bL;

        public AdminMenu(IBL bL)
        {
            this.bL = bL;
        }

        public void Display()
        {
            Console.WriteLine("Press <1> to see All users in your app");
            Console.WriteLine("Press <2> to search a specific user");
            Console.WriteLine("Press <3> to go to the Main Menu");
            Console.WriteLine("Press <0> to return to Exit");
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
                    var allUsers = _repository.GetAllUsers();
                    foreach(var user in allUsers)
                    {
                        Console.WriteLine("=============");
                        Console.WriteLine(user);
                        Console.WriteLine("=============");
                    }
                 return "AdminMenu";
                case "2":
                    Console.WriteLine("Please enter a name for the User you want to view: ");
                    string username = Console.ReadLine();
                    List<User> userResult = bL.GetUserAccounts(username);
                    if (userResult.Count > 0)
                    {
                        foreach (var result in userResult)
                        {
                            Console.WriteLine("=============");
                            Console.WriteLine(result.ToString());
                            Console.WriteLine("=============");
                        }
                        return "AdminMenu";
                    }
                    return "AdminMenu";
                case "3":
                    return "MainMenu";
                default:
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "AdminMenu";
            }
        }
    }
}
