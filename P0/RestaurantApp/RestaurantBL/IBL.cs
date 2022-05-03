
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using RestaurantModel;

namespace RestaurantBL
{
    public interface IBL
    {
        List<Restaurant> SearchRestaurants(string searchString);

        List<Restaurant> GetAllRestaurants();

        List<Review> GetAllReviews();

        void AddRestaurant(Restaurant restaurantToAdd);

        void AddReview(Review newReview);

        List<User> GetUserName(string Username, string Password);

     

        public List<User> GetUserAccounts(string Username);
    }

    interface IRestaurantSearch
    {
        List<Restaurant> searchAll();
    }
}
