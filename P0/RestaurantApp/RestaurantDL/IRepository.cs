using RestaurantModel;
using System.Collections.Generic;

namespace RestaurantDL
{
    public interface IRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User AddUser(User user);

        List<User> GetAllUsers();
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns></returns>
        Restaurant AddRestaurant(Restaurant restaurant);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Restaurant> GetAllRestaurants();


        /// <summary>
        /// 
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Review AddReview(Review review);


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Review> GetAllReviews();
    }
}
