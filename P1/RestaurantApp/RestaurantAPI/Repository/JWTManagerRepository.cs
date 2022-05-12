using RestaurantModel;
using RestaurantBL;
using RestaurantDL;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace RestaurantAPI.Repository
{
    public class JWTManagerRepository : IJWTManagerRepository
    {
        private IRepository _repo = new SqlRepository();
        private IConfiguration configuration;
        private IBL bL;

        public JWTManagerRepository(IConfiguration configuration, IRepository _repo, IBL bL)
        {
            this.configuration = configuration;
            this._repo = _repo;
            this.bL = bL;
        }

        public Tokens Authenticate(User user)
        {
            if(bL.Authenticate(user) == false)
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

