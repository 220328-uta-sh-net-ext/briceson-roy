
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

        List<User> GetUserName(string Username);
        List<User> GetPassword(string Password);

    }

    interface IRestaurantSearch
    {
        List<Restaurant> searchAll();
    }
}
