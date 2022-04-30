using Models;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantModel;

namespace RestaurantDL
{
    public class SqlRepository : IRepository
    {
        private string connectionStingPath = "../../../../RestaurantDL/connectionString.txt";
        private readonly string connectionString;

        public SqlRepository()
        {
            connectionString = File.ReadAllText(connectionStingPath);
        }

        public List<Review> GetAllReviews()
        {
            string commandString = "SELECT * FROM Reviews";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var reviews = new List<Review>();
            while (reader.Read())
            {
                reviews.Add(new Review
                {
                    Rating = reader.GetInt32(3),
                    Note = reader.GetString(4)
                });

            }
            return reviews;
        }
        public List<Review> GetSomeReviews(int restaurantId)
        {
            string commandString = "SELECT * FROM Reviews WHERE ";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();

            var reviews = new List<Review>();
            while (reader.Read())
            {
                reviews.Add(new Review
                {
                    Rating = reader.GetInt32(3),
                    Note = reader.GetString(4)
                });

            }
            return reviews;
        }

        public List<Restaurant> GetAllRestaurants()
        {
            string commandString = "SELECT * FROM Restaruant";

            using SqlConnection connection = new(connectionString);
            using IDbCommand command = new SqlCommand(commandString, connection);
            connection.Open();
            using IDataReader reader = command.ExecuteReader();

            var restaurants = new List<Restaurant>();
            while (reader.Read())
            {
                restaurants.Add(new Restaurant
                {
                    Name = reader.GetString(1),
                    AvgRating = (double)reader.GetDecimal(2),
                    City = reader.GetString(3),
                    State = reader.GetString(4),
                    ZipCode = reader.GetString(5)
                });
            }
            return restaurants;
        }



        public User AddUser(User userToAdd)
        {
            string commandString = "INSERT INTO USER (UserName, isAdmin)";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.AddWithValue("@Username", userToAdd.Username);
            command.Parameters.AddWithValue("@Password", userToAdd.Password);
            command.Parameters.AddWithValue("@isAdmin", userToAdd.isAdmin);

            return userToAdd;

        }

        public Restaurant AddRestaurant(Restaurant restaurantToAdd)
        {
            string commandString = "INSERT INTO Restaurants (Name, AvgRating, City, State, ZipCode)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.AddWithValue("@name", restaurantToAdd.Name);
            command.Parameters.AddWithValue("@avg", restaurantToAdd.AvgRating);
            command.Parameters.AddWithValue("@city", restaurantToAdd.City);
            command.Parameters.AddWithValue("@state", restaurantToAdd.State);
            command.Parameters.AddWithValue("@zip", restaurantToAdd.ZipCode);


            return restaurantToAdd;
        }

        public void AddReview(int restaurantId, Review reviewToAdd)
        {
            string commandString = "INSERT INTO Reviews (RestaurantId, Rating, City, State, ZipCode)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            connection.Open();
            command.ExecuteNonQuery();
            command.Parameters.AddWithValue("@restaurantid", reviewToAdd.RestaurantId);
            command.Parameters.AddWithValue("@rating", reviewToAdd.Rating);
            command.Parameters.AddWithValue("@detail", reviewToAdd.Note);

        }

        public void UpdateAvgRating(int restaurantID, decimal rating)
        {
            String commandString = "UPDATE Restaurants SET AvgRating=@avg WHERE id=@restaurantID";
        }

        public List<Restaurant> SearchRestaurants(string searchTerm)
        {
            return GetAllRestaurants();
        }

        public bool IsDuplicate(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public void AddReview(Review newReview)
        {
            throw new NotImplementedException();
        }
    }
}
