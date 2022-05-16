﻿using Models;
using RestaurantModel;

namespace RestaurantDL
{
    public interface IRepository
    {
        List<Restaurant> GetAllRestaurants();

        List<Review> GetAllReviews();

        List<User> GetAllUsers();

        User GetUserByName(string username);

        Restaurant AddRestaurant(Restaurant restaurantToAdd);


        User AddUser(User userToAdd);

        List<Restaurant> SearchRestaurants(string searchTerm);

        Restaurant GetRestaurantById(int restaurantId);

        string AddReview(Review newReview);

        bool DeleteRestaurant(Restaurant restaurant);
        bool DeleteReview(Review review);

        bool BanUser(User user);
    }
}