// See https://aka.ms/new-console-template for more information
using RestaurantUI;
using RestaurantBL;
using RestaurantDL;
using Models;

bool active = true;

IRepository repository = new SqlRepository();
IBL bL = new RRBL(repository);



IMenu menu = new LoginMenu(bL);
while (active)
{
    string response = menu.UserChoice();
    
    switch (response)
    {
        case "LoginMenu":
            Console.WriteLine("Returning to start");
            menu = new LoginMenu(bL);
            break;
        case "Register":
            menu = new RegisterUser();               
            break;
        case "MainMenu":
            menu = new MainMenu();
            break;
        case "AdminMenu":
            menu = new AdminMenu(bL);
            break;
        case "RestaurantMenu":
            menu = new RestaurantMenu(bL);
            break; 
        case "AddRestaurant":
            menu = new AddRestaurantMenu();
            break;
        case "ReviewMenu":
            menu = new ReviewMenu();
            break;
        case "Exit":
            active = false;
            break;
        default:
            Console.WriteLine("This menu does not exist. Try Again...");
            continue;
    }
}


//Restaurant name = new Restaurant();
//name.AvgRating = RatingCalc.AverageRating();
//Console.WriteLine(name.AvgRating.ToString());