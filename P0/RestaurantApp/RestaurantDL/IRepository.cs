using Models;
using RestaurantModel;

namespace RestaurantDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();

        List<Review> GetAllReviews();

        void AddRestaurant(Restaurant restaurantToAdd);

        void AddReview(int restaurantId, Review reviewToAdd);

        void AddUser(User userToAdd);

        List<Restaurant> SearchRestaurants(string searchTerm);

        bool IsDuplicate(Restaurant restaurant);
        void AddReview(Review newReview);
    }
}