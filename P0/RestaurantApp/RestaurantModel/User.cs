namespace RestaurantModel
{
    public class User
    {
        enum AdminRights
        {
            Approve, Search, Ban
        }

        //Username
        public string Username { get; set; }    

        //Password
        public string Password { get; set; }   
        //FirstName
        public string FirstName { get; set; }
        //LastName
        public string LastName { get; set; }


        public User()
        {
            Username = "LoremIpsum";
            Password = "";
            FirstName = "Lorem";
            LastName = "Ipsum";
        }

        public override string ToString()
        {
            return $"Welcome to Restaurant review {FirstName} {LastName}. Your UserName is {Username} and Password is {Password}";
        }

        class Admin : User
        {
            public AdminRights adminRights;
        }
    }
}