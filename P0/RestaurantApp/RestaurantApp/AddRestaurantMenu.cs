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
        private IRepository _repository = new SqlRepository();

        //private IRepository _repository = new SqlRepository(); //UpCasting

        //readonly IBL bL;
        //readonly IRepository repository;

        //public AddRestaurantMenu(IBL bL, IRepository repository)
        //{
        //    this.bL = bL;
        //    this.repository = repository;
        //}

        public void Display()
        {
            Console.WriteLine("<5> Name - " + newRestaurant.Name);
            Console.WriteLine("<4> City - " + newRestaurant.City);
            Console.WriteLine("<3> State - " + newRestaurant.State);
            Console.WriteLine("<2> ZipCode - " + newRestaurant.ZipCode);
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
                        //Log.Information("Adding a pokemon - " + newRestaurant.Name);
                        _repository.AddRestaurant(newRestaurant);
                        //Log.Information("Pokemon added successfully");                  
                    return "MainMenu";
                case"2":
                    Console.WriteLine("Please enter the Zip Code: ");
                    newRestaurant.ZipCode = Convert.ToInt32(Console.ReadLine());
                    return "AddRestaurant";
                case "3":
                    Console.Write("Please enter its State: ");
                    newRestaurant.State = Console.ReadLine();
                    return "AddRestaurant";
                case "4":
                    Console.Write("Please enter its City: ");
                    newRestaurant.City = Console.ReadLine();
                    return "AddRestaurant";
                case "5":
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