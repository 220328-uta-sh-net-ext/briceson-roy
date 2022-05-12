using RestaurantModel;
using RestaurantBL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RestaurantAPI.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IBL bL = new RRBL();
        private IConfiguration configuration;
        public JWTManagerRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public Tokens Authenticate(User user)
        {
            if(bL.GetUserAccount(user) ==  )
            {
                return null;
            }
                
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:KEY"]);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.Username)
                    }),
                Expires = DateTime.UtcNow.AddHours(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256)
                };

            var token = tokenHandler.CreateToken(tokenDescription);
            return new Tokens { Token = tokenHandler.WriteToken(token) };
             }
        }
    }

