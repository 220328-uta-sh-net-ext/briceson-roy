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

    /// <summary>
    /// Searches the Restaurants by a search term
    /// </summary>
    /// <param name="searchTerm"></param>
    /// <returns></returns>
    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        var restaurants = _repo.GetAllRestaurants();
        var filteredRestaurants = restaurants.Where(restaurant => restaurant.Name.ToLower().Contains(searchTerm)).ToList();
        return filteredRestaurants;

    }

    public List<Restaurant> SearchRestaurantsByState(string searchState)
    {
        var restaurants = _repo.GetAllRestaurants();
        var filteredByState = restaurants.Where(restaurant => restaurant.State.Contains(searchState)).ToList();
        return filteredByState;
    }

    public List<Restaurant> SearchRestaurantByZipCode(int searchZip)
    {
        var restaurants = _repo.GetAllRestaurants();
        var filteredByZip = restaurants.Where(restaurant => restaurant.ZipCode.Equals(searchZip)).ToList();
        return filteredByZip;
    }


    public Restaurant GetRestaurantById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Review> GetAllReviews()
    {
        var reviews = _repo.GetAllReviews();
        return reviews;
    }

    
    

    public List<User> GetUserAccount(string Username, string Password)
    {
        List<User> users = _repo.GetAllUsers();
        var filteredUsernames = users.Where(user => user.Username.ToLower().Contains(Username)
        && user.Password.ToLower().Contains(Password)).ToList();
        return filteredUsernames;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="Username"></param>
    /// <returns>returns the account info that an admin searches for</returns>

    public List<User> GetUserAccounts(string Username)
    {
        List <User> users = _repo.GetAllUsers();
        var filteredAccounts = users.Where(user => user.Username.ToLower().Equals(Username)).ToList();
        return filteredAccounts;
    }

    public List<User> GetUserName(string Username)
    {
        List<User> users = _repo.GetAllUsers();
        var filteredUserNames = users.Where(user => user.Username.ToLower().Equals(Username)).ToList();
        return filteredUserNames;
    }
}