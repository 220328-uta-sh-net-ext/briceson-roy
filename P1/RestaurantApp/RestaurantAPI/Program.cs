global using Serilog;
using RestaurantBL;
using RestaurantDL;
using System.Text;
using RestaurantAPI.Repository;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;



Log.Logger = new LoggerConfiguration()
    .WriteTo.File("C:/Users/royzo/Desktop/Projects/Revature/briceson-roy/P1/RestaurantApp/RestaurantDL/logs.txt").MinimumLevel.Information()
    .CreateLogger();


string connectionStringFilePath = "C:/Users/royzo/Desktop/Projects/Revature/briceson-roy/P1/RestaurantApp/RestaurantDL/connectionString.txt"; ;
string connectionString = File.ReadAllText(connectionStringFilePath);

var builder = WebApplication.CreateBuilder(args);

//to access the appSettings.json file JWT token info we will use thi variable
ConfigurationManager Config = builder.Configuration;


// Add services to the container.
//boiler plate code to configure security with JWT 
builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(o => {
    var key = Encoding.UTF8.GetBytes(Config["JWT:Key"]);
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidIssuer = Config["JWT:Issuer"],
        ValidAudience = Config["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateLifetime = true,
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddMemoryCache();
builder.Services.AddControllers(options =>
    options.RespectBrowserAcceptHeader = true
    )
    .AddXmlSerializerFormatters();//adding xml formatter 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository>(repo => new SqlRepository());
builder.Services.AddScoped<IBL, RRBL>();
//builder.Services.AddSingleton<IJWTManagerRepository, JWTManagerRepository>();

//app here refers to the pipeline middleware
var app = builder.Build();
app.Logger.LogInformation("App Started");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();