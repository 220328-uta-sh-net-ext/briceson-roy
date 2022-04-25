using RestaurantBL;
using RestaurantDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class RestaurantMenu : IMenu
    {
        static Repository repository = new Repository();

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the pokemon database");
            Console.WriteLine("Press <1> By Name");
            Console.WriteLine("Press <0> Go Back");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return "Main Menu";
                    break;
                case "1":
                    Console.WriteLine("Please enter a name for the restaurant: ");
                    string name = Console.ReadLine();
                    var results = repository.SearchRestaurants(name);
                    if (results.Count() > 0)
                    {
                        foreach(var result in results)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {name} not found");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                default:
                    Console.WriteLine("Please enter a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "SearchRestaurant";
            }
        }
      

     

    }
}
