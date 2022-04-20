namespace DL
{
    // POCO -> Plain of CLR Object
    public class Employee
    {
        public string FirstName { get; set; }
        
        public string LastName { get; set; }

        public string Id { get; set; }

        public Employee()
        {
            FirstName = "Steve";
            LastName = "Jobs";
            Id = "001";
        }
        public Employee(string firstname, string lastname, string id) //parametised constructor
        {
            FirstName = firstname;
            LastName = lastname;    
            Id = id;    
        }
    }
}