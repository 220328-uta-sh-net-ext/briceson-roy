// See https://aka.ms/new-console-template for more information
using RestaurantUI;
using RestaurantBL;
using RestaurantDL;
using Models;

//bool active = true;
//IMenu menu = new MainMenu();
//while (active)
//{
    //string response = menu.UserChoice();
    
   /* switch (response)
    {
        case "Login":
            //Login Method
            break;
        case "Register":
            //Register Method               
            break;
        case "exit":
            active = false;
            break;
    }*/

//}


Restaurant name = new Restaurant();
name.AvgRating = RatingCalc.AverageRating();
Console.WriteLine(name.AvgRating.ToString());