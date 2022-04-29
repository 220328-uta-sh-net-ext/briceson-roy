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
            Console.WriteLine("Please select an option to filter the restaurant database");
            Console.WriteLine("Press <1> By Name");
            Console.WriteLine("Press <2> By Average Rating");
            Console.WriteLine("Press <3> By Zip Code");
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
                            return "ReviewMenu";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {name} not found");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    break ;
                case "2":
                    Console.WriteLine("Please enter a name for the restaurant: ");
                    string rating = Console.ReadLine();
                    var resultsTwo = repository.SearchRestaurants(rating);
                    if (resultsTwo.Count() > 0)
                    {
                        foreach (var result in resultsTwo)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());
                            return "ReviewMenu";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {rating} not found");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                case "3":
                    Console.WriteLine("Please enter a name for the restaurant: ");
                    string zipCode = Console.ReadLine();
                    var resultsThree = repository.SearchRestaurants(zipCode);
                    if (resultsThree.Count() > 0)
                    {
                        foreach (var result in resultsThree)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());
                            return "ReviewMenu";
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {zipCode} not found");
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
