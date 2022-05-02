using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModel;
using RestaurantBL;

namespace RestaurantUI
{
    internal class ReviewMenu : IMenu
    {
        private readonly IBL _b1;

        public ReviewMenu()
        {
        }

        private ReviewMenu(IBL bL)
        {
            _b1 = bL;
        }

        
        public void Display()
        {
            Console.WriteLine("To leave a review for this restaurant please press <1>");
            Console.WriteLine("To see all reviews for this restaurant please press <2>");
            Console.WriteLine("To go back to the main menu the App please press <0>");
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
                    return "AddReviewMenu";
                case "2":
                    return "AllReviews";
                default:
                    Console.WriteLine("Please enter a valid response");
                    Console.WriteLine("Please press <enter> to continue");
                    Console.ReadLine();
                    return "SearchRestaurant";
            }
        }
    }
}
