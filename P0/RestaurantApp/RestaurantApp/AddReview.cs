using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using RestaurantModel;

namespace RestaurantUI
{
    internal class AddReview : IUserFunctions
    {
        private static Review newReview = new Review();

        private IRepository _repository = new Repository();

        public void Display()
        {
            Console.WriteLine("Enter in Your review of this restaurant");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            newReview.StarCount = Convert.ToInt32(userInput);
            newReview.Details = userInput;
            return "Review Added";
        }

    }
}
