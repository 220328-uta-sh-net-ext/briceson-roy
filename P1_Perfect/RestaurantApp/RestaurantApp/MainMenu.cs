namespace RestaurantUI
{
    public class MainMenu : IMenu
    {

        public void Display()
        {

            Console.WriteLine("To Search a Restaurant please press <1>");
            Console.WriteLine("To Add a Restaurant please press <2>");
            Console.WriteLine("To exit the App please press <0>");
        }
        public string UserChoice()
        {
            Display();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    return "RestaurantMenu";
                case "2":
                    return "AddRestaurant";
                case "3":
                    return "ReviewMenu";
                case "0":
                    return "Exit";
                default :
                    Console.WriteLine("Response not acceptable");
                    Console.WriteLine("To continue press <enter> to continue");
                    Console.ReadLine();
                    return "MainMenu";

            }
        }
    }
}