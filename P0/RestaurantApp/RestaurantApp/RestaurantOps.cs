using RestaurantDL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantUI
{
    internal class RestaurantOps
    {
        static Repository repository = new Repository();

        public static void GetAllRestaurants()
        {
            var restaurants=repository.GetAllRestaurants();
            foreach (var restaurant in restaurants)
            {
                Console.WriteLine(restaurant.ToString());
            }
        }

        public static void GetAllReviews()
        {
            var reviews=repository.GetAllReviews();
            foreach (var review in reviews)
            {
                Console.WriteLine(review.ToString());
            }
        }

    }
}
