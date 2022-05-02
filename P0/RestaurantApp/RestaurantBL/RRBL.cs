using CustomExceptions;
using Models;
using RestaurantDL;
using RestaurantModel;

namespace RestaurantBL;
public class RRBL : IBL
{
    private readonly IRepository _repo;
    public RRBL(IRepository repository)
    {
        this._repo = repository;
    }

    /// <summary>
    /// Adds a new restaurant to the list
    /// This method will check for the duplicate record before persisting
    /// </summary>
    /// <param name="restaurantToAdd">restaurant object to add</param>
    /// <exception cref="DuplicateRecordException">When there is a restaurant that already exists</exception>
    public void AddRestaurant(Restaurant restaurantToAdd)
    {
       IRepository repository = new SqlRepository();
        
    }

    /// <summary>
    /// Adds a new review to the restaurant that exists on that index
    /// </summary>
    /// <param name="restaurantId">index of the restaurant to leave a review for</param>
    /// <param name="reviewToAdd">a review object to be added to the restaurant</param>
    public void AddReview(Review reviewToAdd)
    {
        IRepository repository = new SqlRepository();
    }


    /// <summary>
    /// Gets all restaurants
    /// </summary>
    /// <returns>list of all restaurants</returns>
    public List<Restaurant> GetAllRestaurants()
    {   
        var restaurants = _repo.GetAllRestaurants();
        return restaurants;
    }

    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        var restaurants = _repo.GetAllRestaurants();
        var filteredRestaurants = restaurants.Where(restaurant => restaurant.Name.Contains(searchTerm)).ToList();

        return filteredRestaurants;

    }

    public List<Review> GetAllReviews()
    {
        var reviews = _repo.GetAllReviews();
        return reviews;
    }

    public List<User> GetUserName(string Username)
    {
        List<User> users = _repo.GetAllUsers();
        var filteredUsernames = users.Where(user => user.Username.ToLower().Contains(Username)).ToList();
        return filteredUsernames;
    }

    public List<User> GetPassword(string Password)
    {
        List<User> users = _repo.GetAllUsers();
        var filteredPasswords = users.Where(user => user.Password.ToLower().Contains(Password)).ToList();
        return filteredPasswords;
    }
}