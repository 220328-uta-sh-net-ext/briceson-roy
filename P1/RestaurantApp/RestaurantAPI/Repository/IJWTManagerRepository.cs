using RestaurantModel;


namespace RestaurantAPI.Repository
{
    public interface IJWTManagerRepository
    {
        Tokens Authenticate(User user);
    }
}
