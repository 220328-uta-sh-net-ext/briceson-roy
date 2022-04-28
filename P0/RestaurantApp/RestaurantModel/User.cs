using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;


namespace RestaurantModel
{
    public class User
    {
        enum AdminRights
        {
            Approve, Search, Ban
        }

        //Username
        private string _username;
        public string Username 
        { get => _username ; set
            {
                Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
                    if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InputInvalidException("Name can't be empty");
                }
                    else if(!pattern.IsMatch(value))
                    {
                    throw new InputInvalidException("Username can only have alphanumeric characters, white space, !, ?, and '.");
                }
                    else if(value.Length < 25)
                {
                    throw new InputInvalidException("Username cannot exceed 25 chars");
                }
            }
                
          }

        //Password
        private string _password;

        public string Password { get => _password; set {
                Regex pattern = new Regex("^[a-zA-Z0-9 !?']+$");
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new InputInvalidException("Name can't be empty");
                }
                else if (!pattern.IsMatch(value))
                {
                    throw new InputInvalidException("Username can only have alphanumeric characters, white space, !, ?, and '.");
                }
                else if (value.Length < 25)
                {
                    throw new InputInvalidException("Username cannot exceed 25 chars");
                }
            } 
        }   

        public bool isAdmin { get; set; }

        public User()
        {
            Username = "LoremIpsum";
            Password = "";
            isAdmin = false;
        }

        public override string ToString()
        {
            return $"Welcome to Restaurant review. Your UserName is {Username} and Password is {Password}";
        }

        class Admin : User
        {
            public AdminRights adminRights;
        }
    }
}