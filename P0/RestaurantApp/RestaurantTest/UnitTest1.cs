using Xunit;
using Models;
using RestaurantModel;
using RestaurantBL;
using RestaurantDL;



namespace RestaurantTest
{
    public class UnitTests
    {
        [Fact]
        public void RegisterUserTest()
        {
           User newUser = new User();

            newUser.Username = "user123";
            newUser.Password = "password456";
            newUser.isAdmin = false;

            Assert.Equal("user123", newUser.Username);
            Assert.Equal("password456", newUser.Password);
            Assert.Equal(false, newUser.isAdmin);
        }

        public void RegisterAdminUserTest()
        {
            User newUser = new User();

            newUser.Username = "admin123";
            newUser.Password = "password456";
            newUser.isAdmin = true;

            Assert.Equal("admin123", newUser.Username);
            Assert.Equal("password456", newUser.Password);
            Assert.Equal(true, newUser.isAdmin);
        }


        [Fact]
        public void RestaurantAddTest()
        {
            Restaurant newRestaurant = new Restaurant();

            newRestaurant.Name = "Blaze Pizza";
            newRestaurant.City = "Laurel";
            newRestaurant.State = "MD";
            newRestaurant.ZipCode = 20707;

             Assert.Equal("Blaze Pizza", newRestaurant.Name);
             Assert.Equal("Laurel", newRestaurant.City);
             Assert.Equal("MD", newRestaurant.State);
            Assert.Equal(20707, newRestaurant.ZipCode);
        }

        [Fact]
        public void ReviewAddTest()
        {
            Review newReview = new Review();

            newReview.Rating = 5;
            newReview.Note = null;
           
            Assert.Equal(5, newReview.Rating);
            Assert.Equal(null, newReview.Note);
        }
    }
}