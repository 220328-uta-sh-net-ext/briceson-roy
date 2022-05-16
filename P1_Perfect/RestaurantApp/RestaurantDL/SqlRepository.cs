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
       
        private readonly string connectionString;

        public SqlRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Review> GetAllReviews()
        {
            string commandString = "SELECT * FROM Reviews";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet data = new();
            connection.Open();
            adapter.Fill(data);
            connection.Close();

            var reviews = new List<Review>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                reviews.Add(new Review
                {
                    RestaurantId = (int)row["RestaurantID"],
                    Rating = (decimal)row["Rating"],
                    Note = (string)row["Details"]
                });

            }
            return reviews;
        }

        public List<Review> GetSomeReviews(int restaurantId)
        {
            string commandString = $"Select* from Restaurants WHERE RestaurantID = {restaurantId}";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new SqlCommand(commandString, connection);
            IDataAdapter adapter = new SqlDataAdapter(command);
            DataSet data = new();
            connection.Open();
            adapter.Fill(data);
            connection.Close();

            var reviews = new List<Review>();
            foreach (DataRow row in data.Tables[0].Rows)
            {
                reviews.Add(new Review
                {
                    RestaurantId = (int)row["RestaurantID"],
                    Rating = (decimal)row["Rating"],
                    Note = (string)row["Details"]
                });

            }
            return reviews;
        }


        public List<Restaurant> GetAllRestaurants()
        {   var getReviews = GetAllReviews();
            string commandString = "SELECT * FROM Restaurants";

            using SqlConnection connection = new(connectionString);
            using IDbCommand command = new SqlCommand(commandString, connection);
            connection.Open();
            using IDataReader reader = command.ExecuteReader();
            

            var restaurants = new List<Restaurant>();
            int idCount = 1;

            while (reader.Read())
            {
                decimal rating = 0.0M;
                int counter = 0;
                foreach(Review review in getReviews)
                {
                    if (idCount == review.RestaurantId)
                    {
                        counter++;
                        rating += review.Rating;
                    }
                } 
                idCount++;
                if (counter != 0)
                      rating /= counter; 
                

                restaurants.Add(new Restaurant
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    City = reader.GetString(2),
                    State = reader.GetString(3),
                    ZipCode = (int)reader.GetInt32(4),
                    Rating = rating,
                });
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
            foreach (DataRow row in data.Tables[0].Rows)
            {
                users.Add(new User
                {
                    Username = (string)row[1],
                    Password = (string)row[2],
                    AccountType = (string)row[3]
                });
            }

            return users;
        }



        public User AddUser(User userToAdd)
        {
            string commandString = "INSERT INTO USERS (UserName, Password, AccountType) VALUES (@Username, @Password, @accountType)";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);



            command.Parameters.AddWithValue("@Username", userToAdd.Username);
            command.Parameters.AddWithValue("@Password", userToAdd.Password);
            command.Parameters.AddWithValue("@accountType", userToAdd.AccountType);

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return userToAdd;

        }

        public Restaurant AddRestaurant(Restaurant restaurantToAdd)
        {
            string commandString = "INSERT INTO Restaurants (Name, City, State, ZipCode) VALUES (@name, @city, @state, @zip)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);


            command.Parameters.AddWithValue("@name", restaurantToAdd.Name);
            command.Parameters.AddWithValue("@city", restaurantToAdd.City);
            command.Parameters.AddWithValue("@state", restaurantToAdd.State);
            command.Parameters.AddWithValue("@zip", restaurantToAdd.ZipCode);
            connection.Open();
            command.ExecuteNonQuery();

            return restaurantToAdd;
        }

        public void AddReview(int restaurantId, Review reviewToAdd)
        {
            string commandString = "INSERT INTO Reviews (RestaurantID, Rating, Details) VALUES (@restaurantId, @rating, @detail)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);


            command.Parameters.AddWithValue("@restaurantid", reviewToAdd.RestaurantId);
            command.Parameters.AddWithValue("@rating", reviewToAdd.Rating);
            command.Parameters.AddWithValue("@detail", reviewToAdd.Note);
            connection.Open();
            command.ExecuteNonQuery();
        }


        public List<Restaurant> SearchRestaurants(string searchTerm)
        {
            return GetAllRestaurants();
        }

        

        public Restaurant GetRestaurantById(int restaurantId)
        {
            string commandString = $"Select * from Restaurants WHERE RestaurantID = {restaurantId}";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            var restaurant = new Restaurant();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    restaurant.Id = reader.GetInt32(0);
                    restaurant.Name = reader.GetString(1);
                    restaurant.City = reader.GetString(2);
                    restaurant.State = reader.GetString(3);
                    restaurant.ZipCode = (int)reader.GetInt32(4);
                }

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return restaurant;
        }

        public User GetUserByName(string username)
        {
            string commandString = $"Select * from USERS WHERE Username = {username}";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            var User = new User();
            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    User.Username = reader.GetString(1);
                    User.Password = reader.GetString(2);
                }

            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            return User;
        }
        /// <summary>
        /// remove it for later
        /// </summary>
        /// <param name="newReview"></param>
            public string AddReview(Review newReview)
        {

            string commandString = "INSERT INTO Reviews (RestaurantID, Rating, Details) VALUES (@restaurantId, @rating, @detail)";

            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);


            command.Parameters.AddWithValue("@restaurantid", newReview.RestaurantId);
            command.Parameters.AddWithValue("@rating", newReview.Rating);
            command.Parameters.AddWithValue("@detail", newReview.Note);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            return "review added";
        }

        public bool DeleteRestaurant(Restaurant restaurant)
        {
            string commandString = "DELETE From Restaurants where Name = @name";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@name", restaurant.Name);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch(SqlException ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

    

        public bool DeleteReview(Review review)
        {
            string commandString = "DELETE From Reviews where RestaurantId = @restaurantid";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@name", review.RestaurantId);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool BanUser(User user)
        {
            string commandString = "DELETE From USERS where UserName = @Username";
            using SqlConnection connection = new(connectionString);
            using SqlCommand command = new(commandString, connection);
            try
            {
                command.Parameters.AddWithValue("@Username", user.Username);
                connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
