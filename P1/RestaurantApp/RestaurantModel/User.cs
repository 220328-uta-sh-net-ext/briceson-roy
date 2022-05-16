using CustomExceptions;
using System.Text.RegularExpressions;
using System.Data;


namespace RestaurantModel
{
    public class User
    {
     

        //Username
        public string Username { get ; set; }

        //Password

        public string Password { get ; set;}   

        public string AccountType { get; set; }

        /*public User()
        {
            Username = "LoremIpsum";
            Password = "Password";
            isAdmin = false;
        }*/

        public override string ToString()
        {
            return $" UserName - {Username}, Password - {Password}";
        }

       
    }
}