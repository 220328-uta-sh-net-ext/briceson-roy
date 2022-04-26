using CustomExceptions;
using Models;
using RestaurantDL;

namespace RestaurantBL;
public class RRBL : IBL
{
    private readonly IRepository _dl;

    public RRBL(IRepository repository)
    {
        _dl = repository;
    }

    public RRBL()
    {
    }



    /// <summary>
    /// Gets all restaurants
    /// </summary>
    /// <returns>list of all restaurants</returns>
    public List<Restaurant> GetAllRestaurants()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new restaurant to the list
    /// This method will check for the duplicate record before persisting
    /// </summary>
    /// <param name="restaurantToAdd">restaurant object to add</param>
    /// <exception cref="DuplicateRecordException">When there is a restaurant that already exists</exception>
    public void AddRestaurant(Restaurant restaurantToAdd)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Adds a new review to the restaurant that exists on that index
    /// </summary>
    /// <param name="restaurantId">index of the restaurant to leave a review for</param>
    /// <param name="reviewToAdd">a review object to be added to the restaurant</param>
    public void AddReview(int restaurantId, Review reviewToAdd)
    {
        throw new NotImplementedException();
    }

    public List<Restaurant> SearchRestaurants(string searchTerm)
    {
        var restaurants = _dl.GetAllRestaurants();
        var filteredRestaurants = restaurants.Where(restaurant => restaurant.Name.Contains(searchTerm)).ToList();

        return filteredRestaurants;

    }

    public List<Review> GetAllReviews()
    {
        throw new NotImplementedException();
    }
}