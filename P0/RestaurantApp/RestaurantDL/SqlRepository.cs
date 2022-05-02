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
            string commandString = "SELECT * FROM Restaurants";

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
                    ZipCode = (int)reader.GetInt32(5)
                }) ;
            }
            return restaurants;
        }

        public List<User> GetAllUsers()
        {
            string commandString = "SELECT * FROM USERS";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet data = new();
            connection.Open();
            adapter.Fill(data);
            connection.Close();

            var users = new List<User>();
            foreach(DataRow row in data.Tables[0].Rows)
            {
                users.Add(new User
                {
                    Username = (string)row[1],
                    Password = (string)row[2],
                });
            }

            return users;
        }



        public User AddUser(User userToAdd)
        {
            string commandString = "INSERT INTO USERS (UserName, Password) VALUES (@Username, @Password)";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            
            
            command.Parameters.AddWithValue("@Username", userToAdd.Username);
            command.Parameters.AddWithValue("@Password", userToAdd.Password);
            connection.Open();
            command.ExecuteNonQuery();

            return userToAdd;

        }

        public Restaurant AddRestaurant(Restaurant restaurantToAdd)
        {
            string commandString = "INSERT INTO Restaurants (Name, Rating, City, State, ZipCode) VALUES (@name, @avg, @city, @state, @zip)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

         
            command.Parameters.AddWithValue("@name", restaurantToAdd.Name);
            command.Parameters.AddWithValue("@avg", restaurantToAdd.AvgRating);
            command.Parameters.AddWithValue("@city", restaurantToAdd.City);
            command.Parameters.AddWithValue("@state", restaurantToAdd.State);
            command.Parameters.AddWithValue("@zip", restaurantToAdd.ZipCode);
            connection.Open();
            command.ExecuteNonQuery();

            return restaurantToAdd;
        }

        public void AddReview(int restaurantId, Review reviewToAdd)
        {
            string commandString = "INSERT INTO Reviews (Rating, Details) VALUES (@restaurantId, @rating, @detail)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            
            command.Parameters.AddWithValue("@restaurantid", reviewToAdd.RestaurantId);
            command.Parameters.AddWithValue("@rating", reviewToAdd.Rating);
            command.Parameters.AddWithValue("@detail", reviewToAdd.Note);
            connection.Open();
            command.ExecuteNonQuery();
        }

        public void UpdateAvgRating(int restaurantID, decimal rating)
        {
            String commandString = "UPDATE Restaurants SET AvgRating=@avg WHERE id=@restaurantID";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);

            
            command.Parameters.AddWithValue("@rating", rating);
            connection.Open();
            command.ExecuteNonQuery();
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
