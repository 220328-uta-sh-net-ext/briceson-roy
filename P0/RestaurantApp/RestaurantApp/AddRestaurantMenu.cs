using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantBL;
using Models;

namespace RestaurantUI
{
    internal class AddRestaurantMenu : IMenu
    {
        private static Restaurant newRestaurant = new Restaurant();

        //private IRepository _repository = new Repository(); //UpCasting
 
        readonly IBL bL;

        public AddRestaurantMenu(IBL bL)
        {
            this.bL = bL;
        }

        public void Display()
        {
            Console.WriteLine("<4> Name - " + newRestaurant.Name);
            Console.WriteLine("<3> City - " + newRestaurant.City);
            Console.WriteLine("<2> State - " + newRestaurant.State);
            Console.WriteLine("<1> Save");
            Console.WriteLine("<0> Go Back");
        }

        public string UserChoice()
        {
            Display();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    try
                    {
                        //Log.Information("Adding a pokemon - " + newRestaurant.Name);
                        bL.AddRestaurant(newRestaurant);
                        //Log.Information("Pokemon added successfully");
                    }
                    catch (Exception ex)
                    {
                        //Log.Warning("failed to add pokemon");
                        Console.WriteLine(ex.Message);

                    }
                    return "MainMenu";
                case "2":
                    Console.Write("Please enter its City: ");
                    newRestaurant.State = Console.ReadLine();
                    return "AddRestaurant";
                case "3":
                    Console.Write("Please enter its City: ");
                    newRestaurant.City = Console.ReadLine();
                    return "AddRestaurant";
                case "4":
                    Console.Write("Please enter the name of the Restaurant: ");
                    newRestaurant.Name = Console.ReadLine();
                    return "AddRestaurant";
                /// Add more cases for any other attributes of pokemon
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddRestaurant";
            }
        }
    }
}