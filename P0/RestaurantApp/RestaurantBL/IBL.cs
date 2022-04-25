
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace RestaurantBL
{
    public interface IBL
    {
        List<Restaurant> SearchRestaurants(string searchString);

        List<Restaurant> GetAllRestaurants();

        void AddRestaurant(Restaurant restaurantToAdd);

        void AddReview(int restaurantId, Review reviewToAdd);

    }

    interface IRestaurantSearch
    {
        List<Restaurant> searchAll();
    }
}
