using CustomExceptions;
using Models;
using RestaurantDL;
using RestaurantModel;

namespace RestaurantBL;
public class RRBL : IBL
{
    private readonly IRepository _repo;
    public RRBL(IRepository _repo)
    {
        this._repo = _repo;
    }

    /// <summary>
    /// Adds a new restaurant to the list
    /// This method will check for the duplicate record before persisting
    /// </summary>
    /// <param name="restaurantToAdd">restaurant object to add</param>
    /// <exception cref="DuplicateRecordException">When there is a restaurant that already exists</exception>
    public Restaurant AddRestaurant(Restaurant restaurantToAdd)
    {
       return _repo.AddRestaurant(restaurantToAdd);
    }

    /// <summary>
    /// Adds a new review to the restaurant that exists on that index
    /// </summary>
    /// <param name="restaurantId">index of the restaurant to leave a review for</param>
    /// <param name="reviewToAdd">a review object to be added to the restaurant</param>
    public string AddReview(Review reviewToAdd)
    {
        return null;
    }

    public User AddUser(User userToAdd)
    {
        return _repo.AddUser(userToAdd);
    }


    public bool DeleteRestaurant(string name)
    {
        var restaurants = _repo.GetAllRestaurants();
        foreach (var restaur in restaurants)
        {
            if (restaur.Name.Equals(name))
                if (_repo.DeleteRestaurant(restaur) == true)
                    return true;
        }
        return false;
    }
    public bool DeleteReview(int restaurantId)
    {
        var reviews = _repo.GetAllReviews();
        foreach (var rev in reviews)
        {
            if (rev.RestaurantId.Equals(restaurantId))
                if (_repo.DeleteReview(rev) == true)
                    return true;
        }
        return false;
    }

    public bool BanUser(string username)
    {
        var users = _repo.GetAllUsers();
        foreach (var u in users)
        {
            if (u.Username.Equals(username))
                if (_repo.BanUser(u) == true)
                    return true;
        }
        return false;
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
        var filteredRestaurants = restaurants.Where(restaurant => restaurant.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
        return filteredRestaurants;

    }

    public List<Restaurant> SearchRestaurantsByState(string searchState)
    {
        var restaurants = _repo.GetAllRestaurants();
        var filteredByState = restaurants.Where(restaurant => restaurant.State.ToLower().Contains(searchState.ToLower())).ToList();
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


    public List<Review> GetReviewsById(int id)
    {
        var restaurants = _repo.GetAllReviews();
        var filteredReviews = restaurants.Where(restaurant => restaurant.RestaurantId.Equals(id)).ToList();
        return filteredReviews;
    }
    
    

    public List<User> GetUserAccount(string Username, string Password)
    {
        List<User> users = _repo.GetAllUsers();
        var filteredUsernames = users.Where(user => user.Username.ToLower().Equals(Username)
        && user.Password.ToLower().Equals(Password)).ToList();
        return filteredUsernames;
    }

    public bool Authenticate(User user)
    {
        List<User> users = _repo.GetAllUsers();
        if(users.Exists(auth => auth.Username == user.Username && auth.Password == user.Password))
            return true;
        else
            return false;
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

    string IBL.AddReview(Review newReview)
    {
        return _repo.AddReview(newReview);
    }
}