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
            Console.WriteLine("How many stars do you give the restaurant?");
            Console.WriteLine("Are there any special details you'd like to share?");
        }

        public void UserChoice()
        {
          string userInput = Console.ReadLine();
          
          int rating = Convert.ToInt32(userInput);

          string Details = userInput;
            
        }
    }
}
     