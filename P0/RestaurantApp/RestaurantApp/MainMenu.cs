namespace RestaurantUI
{
    public class MainMenu : IMenu
    {

        public void Display()
        {

            Console.WriteLine("To Search a Restaurant please press <1>");
            Console.WriteLine("To exit the App please press <0>");
        }



        public string UserChoice()
        {
            string userInput = Console.ReadLine();


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