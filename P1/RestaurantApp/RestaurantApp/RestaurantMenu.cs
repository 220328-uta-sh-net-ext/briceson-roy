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
        static IRepository repository = new SqlRepository();

         readonly IBL bL;

        public RestaurantMenu(IBL bL)
        {
            this.bL = bL;
        }

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the restaurant database");
            Console.WriteLine("Press <1> By Name");
            Console.WriteLine("Press <2> By ZipCode");
            Console.WriteLine("Press <3> By State");
            Console.WriteLine("Press <4> By ID");
            Console.WriteLine("Press <0> Go Back");
        }
        public string UserChoice()
        {
            Display();
            string userInput = Console.ReadLine();

            switch(userInput)
            {
                case "0":
                    return "Main Menu";
                case "1":
                    Console.WriteLine("Please enter a name for the restaurant: ");
                    string name = Console.ReadLine().Trim();
                    var results = repository.SearchRestaurants(name);
                    if (results.Count() > 0)
                    {
                        foreach(var result in results)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());  
                            Console.WriteLine("=================");
                            var reviewList = bL.GetReviewsById(result.Id);
                            foreach(var review in reviewList)
                            {
                                Console.WriteLine("-----------------");
                                Console.WriteLine(review); 
                                Console.WriteLine("-----------------");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {name} not found");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a ZipCode for the restaurant: ");
                    string zipCode = Console.ReadLine();
                    int zipCodeInt;
                    bool canConvert = int.TryParse(zipCode, out zipCodeInt);
                    if(canConvert == false)
                    {
                       Console.WriteLine("Input can not be converted please input valid input.");
                        goto case "2";
                    }
                    var resultsZip = bL.SearchRestaurantByZipCode(zipCodeInt);
                    if (resultsZip.Count > 0)
                    {
                        foreach (var result in resultsZip)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());
                            var reviewList = bL.GetReviewsById(result.Id);
                            foreach (var review in reviewList)
                            {
                                Console.WriteLine("-----------------");
                                Console.WriteLine(review);
                                Console.WriteLine("-----------------");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {zipCode} not found");
                        //goto case "2";
                    }


                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                case "3":
                    Console.WriteLine("Please enter a State for the restaurant: ");
                    string state = Console.ReadLine();
                    var resultsState = bL.SearchRestaurantsByState(state);
                    if (resultsState.Count() > 0)
                    {
                        foreach (var result in resultsState)
                        {
                            Console.WriteLine("=================");
                            Console.WriteLine(result.ToString());
                            var reviewList = bL.GetReviewsById(result.Id);
                            foreach (var review in reviewList)
                            {
                                Console.WriteLine(review);
                                Console.WriteLine("-----------------");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Restaurant with search string {state} not found");
                    }
                    Console.WriteLine("Press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";
                case "4":
                    Console.WriteLine("Please enter a valid Id for the restaurant you want: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    var resultsFour = repository.GetRestaurantById(id);
                    if (resultsFour != null)
                    {
                        Console.WriteLine("=================");
                        Console.WriteLine(resultsFour.ToString());
                        var menu = new AddReviewMenu(id);
                        menu.UserChoice();
                    }
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
