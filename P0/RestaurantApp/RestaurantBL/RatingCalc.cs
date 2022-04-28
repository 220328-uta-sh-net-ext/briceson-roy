using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDL;
using Models;

namespace RestaurantBL
{
    public class RatingCalc
    {
        public static double AverageRating()
        {
            Repository reviews = new Repository();
            var review = reviews.GetAllReviews();


            double sum = 0;
            //Get all the ratings for a restaurant
            for(int i = 0; i < review.Count; i++)
            {
                sum += review[i].Rating;
            }

            //Add them up and divid

           return Math.Round(sum / review.Count, 2);
            //send result to the repository
           
        }
    }
}
