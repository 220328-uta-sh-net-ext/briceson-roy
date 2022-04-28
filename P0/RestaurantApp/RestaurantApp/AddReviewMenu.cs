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
    internal class AddReviewMenu 
    {
        private static Review newReview = new Review();

        private  IBL _repository = new RRBL();

        public void Display()
        {
            Console.WriteLine("Press <1> to add stars to your Review");
            Console.WriteLine("Press <2> to add a Note to the review");
            Console.WriteLine("Press <3> to save the review");
            Console.WriteLine("Press <0> to return to the main menu");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput) {
                case "0":
                    return "MainMenu";
                case "1":
                      Console.Write("Please Add the star count to the review: ");
                    newReview.Rating = Convert.ToInt32(Console.ReadLine());
                    return "AddReview";
                case "2":
                    Console.Write("Please enter any specific notes you want to add about the service. ");
                    newReview.Note = Console.ReadLine();
                    return "AddReview";
                case "3":
                  ;try
                    { 
                        _repository.AddReview(newReview);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    return "MainMenu";
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
     