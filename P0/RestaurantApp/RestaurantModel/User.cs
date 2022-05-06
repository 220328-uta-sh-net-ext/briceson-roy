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
        { get ; set; }

        //Password
        private string _password;

        public string Password { get ; set;}   

        public bool isAdmin { get; set; }

        public User()
        {
            Username = "LoremIpsum";
            Password = "Password";
            isAdmin = false;
        }

        public override string ToString()
        {
            return $" UserName - {Username}, Password - {Password}";
        }

        class Admin : User
        {
            public AdminRights adminRights;
        }
    }
}