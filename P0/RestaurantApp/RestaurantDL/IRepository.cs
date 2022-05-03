using Models;
using RestaurantModel;

namespace RestaurantDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();

        List<Review> GetAllReviews();

        List<Review> GetSomeReviews(int restaurantId);

        List<User> GetAllUsers();

        User GetUserByName(string username);

        Restaurant AddRestaurant(Restaurant restaurantToAdd);

        void AddReview(int restaurantId, Review reviewToAdd);

        User AddUser(User userToAdd);

        //void UpdateAvgRating(int restaurantId, decimal rating);

        List<Restaurant> SearchRestaurants(string searchTerm);

        Restaurant GetRestaurantById(int restaurantId);

        bool IsDuplicate(Restaurant restaurant);
        void AddReview(Review newReview);
    }
}