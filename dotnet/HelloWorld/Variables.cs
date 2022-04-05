// See https://aka.ms/new-console-template for more information
//declaring a variables

//strings
string rider;
rider = "Build";
//variables can be reassigned
rider="Ex-Aid";
Console.WriteLine(rider);

//chars
char userOptions;
userOptions = 'y';
Console.WriteLine(userOptions);

//integers
int gameCode;
gameCode = 555;
Console.WriteLine(gameCode);

//decimals
decimal particlesPerMillion;
particlesPerMillion= 12.3m;
Console.WriteLine(particlesPerMillion);

//boolean
bool processedCustomer;
processedCustomer= true;
Console.WriteLine(processedCustomer);

//implicitly typed local variable
//cannot implicitly convert type 'decimal' to 'string'
var message = "Hello World";
message = 10.0m;

//var can only be used if a variable is initialized
//var message; 