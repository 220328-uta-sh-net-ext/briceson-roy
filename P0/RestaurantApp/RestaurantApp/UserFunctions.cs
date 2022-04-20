namespace RestaurantUI
{
    public class UserFunctions : IUserFunctions
    {
        public void Display()
        {
            Console.WriteLine("Welcome to the Restaurant Review App");
            Console.WriteLine("If you are a new User press <r> to register");
            Console.WriteLine("If you are a returning User press <l> to log in");
            Console.WriteLine("To exit the App please press <x>");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "x":
                    return "Exit";
                case "r":
                    return "Register";
                case "l":
                    return "Login";
                default:
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "LoginMenu";
            }
        }

        public string MainMenuDisplay()
        {
            string userInput = Console.ReadLine();

            Console.WriteLine("To Search a Restaurant please press <1>");
            Console.WriteLine("To leave a review for a restaurant please press <2>");
            Console.WriteLine("To exit the App please press <x>");

            switch (userInput)
            {
                case "1":
                    return "Search Restaurant";
                    break;
                case "2":
                    return "leave Review";
                    break ;
                case "3":
                    return "Exit";
                default :
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "Main Menu";

            }
        }


    }
}