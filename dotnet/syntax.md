# Syntax of C#

## Basic rules

```
Console.WriteLine("Welcome to Jamrock!"); //writes a line that's specified in the parentheses
var name=Console.ReadLine(); //takes an input in string format i.e name
```

### for creating single char values

```
Console.WriteLine('W');
```

### for creating multi char literal values

```
Console.WriteLine("Count your sins!");
```

this will generate an error

```
Console.WriteLine('Count your sins!');
```

### writing integers

```
Console.WriteLine(555);
```

### writing floating decimal values

```
Console.WriteLine(3.14m);
```

### writing Booleans

```
Console.WriteLine(true);
Console.WriteLine(false);
```

### you can use Write to print multiple lines as if they were on one line.

```
Console.Write("This ");
Console.Write("is");
Console.Write("Cool");
```

# declaring a variables

### strings

```
string rider;
rider = "Build";
//variables can be reassigned
rider="Ex-Aid";
Console.WriteLine(rider);
```

### chars

```
char userOptions;
userOptions = 'y';
Console.WriteLine(userOptions);
```

### integers

```
int gameCode;
gameCode = 555;
Console.WriteLine(gameCode);
```

### decimals

```
decimal particlesPerMillion;
particlesPerMillion= 12.3m;
Console.WriteLine(particlesPerMillion);
```

### booleans

```
bool processedCustomer;
processedCustomer= true;
Console.WriteLine(processedCustomer);
```

## Note! implicitly typed local variable

cannot implicitly convert type 'decimal' to 'string'

```
// var message = "Hello World";
// message = 10.0m;
```

## Note! var can only be used if a variable is initialized

```
//var message;
```

# String Escape Sequences

### the \n will add a new line

```
Console.WriteLine("Hello\nWorld!");
```

### the \t will insert a tab space

```
Console.WriteLine("Hello\tWorld!");
```

### **using special characters in the middle of strings will cause errors**

```
Console.WriteLine("Hello "World"!"); //Error!
```

### use escape clauses to break out and use special characters

```
Console.WriteLine("Hello \"World\"!");
```

**Note! You can't use forward slashes to display a file path since that's reserved for escape clauses**

```
Console.WriteLine("c:\source\repos"); // Error!
```

**To solve this use // to display file paths**

```
Console.WriteLine("c:\\source\\repos");
```

//mock up of command line
Console.WriteLine("Generating invoices for customer \"ABC Corp\" ...\n");
Console.WriteLine("Invoice: 1021\t\tComplete!");
Console.WriteLine("Invoice: 1022\t\tComplete!");
Console.WriteLine("\nOutput Directiory:\t");
Console.Write(@"c:\invoices");

// To generate Japanese invoices:
// Nihon no seikyū-sho o seisei suru ni wa:
Console.Write("\n\n\u65e5\u672c\u306e\u8acb\u6c42\u66f8\u3092\u751f\u6210\u3059\u308b\u306b\u306f\uff1a\n\t");
Console.WriteLine(@"c:\invoices\app.exe -j");

//Verbatim String Literal
/_A verbatim string literal will keep all whitespace and characters
without the need to escape the backslash. To create
a verbatim string, use the @ directive before the literal string._/
Console.WriteLine(@" c:\source\repos
(Code goes here)");

//unicode escape characters
// \u and a four character code creates a character in unicode
Console.WriteLine("\u3053\u3093\u306B\u3061\u306F World!"); //Koni

//String Concatenation
// Concatenation is programmer speak for combining two or more values
string firstName = "Bob";
string message = "Hello " + firstName;
Console.WriteLine(message);

//concatentate multiple variable calls
// string greeting= "Hello";
// string name= "Bob";

// string messageTwo = greeting + ", " + name + ".";
// Console.WriteLine(messageTwo);

//avoiding use of intermidiate variables
// string greeting= "Hello";
// string name= "Bob";

// Console.WriteLine(greeting + ", " + name + "!");

//string interpolation
//refers to combining multipe values into a message through the use of {}
string rider = "Kamen Rider Quiz!";
string henshin = $"Fashion! Passion! Question! {rider}!";

Console.Write(henshin);

//can be done with multiple values
// string boss= "Huge Battleship";
// string bossName= "Great Thing";
// string warning = $"Warning! {boss}! {bossName}! Is Approaching!";
// Console.WriteLine(warning);

//can be done without intermediate values
string boss= "Huge Battleship";
string bossName= "Great Thing";

Console.WriteLine($"Warning! {boss}! {bossName}! Is Approaching!");

//combining with verbatim strings
string projectName = "Nebula";
Console.WriteLine($@"C:\Output\{projectName}\Data");

//or

string projectNameTwo = "Wingman";
Console.WriteLine($"C:\\Output\\{projectName}\\Data");

//basic operations with numbers

//simple addition
int x = 12;
int y = 7;
Console.Write(x + y);

//impicit type conversion
//program understands you're trying to convert an int to a string

/_ string name = "Mark";
int productsSold= 42;
Console.WriteLine(name + " sold" + productsSold + " boxes of chocolate.");_/

//attempting to add numbers in a concatenated string
/_string name = "Mark";
int productsSold= 42;
Console.WriteLine(name + " sold " + productsSold + 7 + " boxes of chocolate.");_/

// will misunderstand the adding of additional number as part of concatenation
// use parentheses to better make it understand

string name = "Mark";
int productsSold= 42;
Console.WriteLine(name + " sold " + (productsSold + 7) + " boxes of chocolate.");

//math Operators
int sum = 7 + 5;
int difference = 7 - 5;
int product = 7 \* 5;
int quotient = 7 / 5;

Console.WriteLine("Sum: " + sum);
Console.WriteLine("Difference: " + difference);
Console.WriteLine("Product: " + product);
Console.WriteLine("Quotient: " + quotient);

//division with literal decimals
decimal decimalQuotient = 7.0m/5;
Console.WriteLine("Decimal quotient: " + decimalQuotient);
//or
//decimal decimalQuotient = 7 / 5.0m;
//decimal decimalQuotient = 7.0m / 5.0m;

//these won't work so don't try them
// int decimalQuotient = 7 / 5.0m;
// int decimalQuotient = 7.0m / 5;
// int decimalQuotient = 7.0m / 5.0m;
// decimal decimalQuotient = 7 / 5;

//you could also specify with conversion
int first = 7;
int second = 5;
decimal quotient= (decimal)first/ (decimal)second;
Console.WriteLine(quotient);

//remainders of a value with modulus
Console.WriteLine("Modulus of 200/5: " + (200 % 5));
Console.WriteLine("Modulus of 7 / 5 : " + (7 % 5));

//Order of operations is determined automatically:
//Parentheses
//exponents
//Multiplication and Division (Left to Right)
//Addition and Subtraction (Left to Right)
int value1 = 3 + 4 _ 5;
int value2 = (3 + 4) _ 5;
Console.WriteLine(value1);
Console.WriteLine(value2);

//increment and decrementing values
// += will increment by a specified value
int initial = 0;
int increment = initial + 5;
increment +=5;
//++ will increment by 1 automatically
int initial = 0;
int increment = initial + 1;
initial ++;
//Note! this technique can be used for arithmatic operations
//++, += addition
//-=, -- subtraction
//\*= multiplication
// /= division(?)

//coding the increment and decrement process
//incrementng
int value = 1;

value = value + 1;
Console.WriteLine("First increment: " + value);

value += 1;
Console.WriteLine("Second increment: " + value);

value++;
Console.WriteLine("Third increment: " + value);

//decrementing
value= value - 1;
Console.WriteLine("First decrement: " + value);

value -= 1;
Console.WriteLine("Second decrement: " + value);

value--;
Console.WriteLine("Third decrement: " + value);

//positioning of the increment/decrement
int value = 1;
value++;
Console.WriteLine("First: " + value);
//Retrieve the current value of the variable value and use that in the string interpolation operation.
//Increment the value.
Console.WriteLine("Second: " + value++);
Console.WriteLine("Third: " + value);
//Increment the value.
/_Retrieve the new incremented value of the variable value and
use that in the string interpolation operation._/
Console.WriteLine("Fourth: " + (++value));

/\*
The .NET Class Library supplies us with a wealth of functionality that we can use by merely referencing the classes and methods we need.

Even our data types are part of the .NET Class Library. C# merely provides an alias for those data types.

A namespace prevents naming collisions between class names in the .NET Class Library.
\*/

//Calling methonds from the class library
Random dice = new Random();
int roll = dice.Next(1, 21);
Console.WriteLine(roll);
/\*The first line of code creates a new instance of the System.Random class in the .NET Class Library and stores the reference to the new object in a variable named dice.

The second line of code calls the dice object's Next() method passing in two parameters: the minimum and maximum value of the random number. The Next() method returns the value, which we save into a variable named roll.

The third line of code calls the WriteLine() method to print the value of roll to the console.
\*/

//stateful vs stateless

// state describes the condition of the execution environment at a specific moment in time.

// stateless methods or static methods are implemented so that they can work without referencing or changing any values already stored in memory.

//stateful methods or instance are built in such a way that they rely on values stored in memory by previous lines of code that have already executed.

//creating instances of a class
Random d20 = new Random();

//new operator
/\*
It first requests an address in the computer's memory large enough to store a new object based on the Random class.

It creates the new object, and stores it at the memory address.

It returns the memory address so that it can be saved in the dice variable.
\*/

//working with return values

//Overloading methods
//An overloaded method is defined with multiple method signatures. Overloaded methods provide different ways to call the method or provide different types of data.
int number = 7;
string text = "seven";

Console.WriteLine(number);
Console.WriteLine();
Console.WriteLine(text);

Random d100 = new Random();
//The first version of the Next() method doesn't set an upper and lower boundary,
//so the method will return values ranging from 0 to 2,147,483,647, which is the maximum value an int can store.
int roll1 = d100.Next();
//The second version of the Next() method specifies the maximum value as an upper boundary, so in this case, we can expect a random value between 0 and 100.
int roll2 = d100.Next(101);
//The third version of the Next() method specifies both the minimum and maximum values, so in this case, we can expect a random value between 50 and 100.
int roll3 = d100.Next(50, 101);

Console.WriteLine($"First roll: {roll1}");
Console.WriteLine($"Second roll: {roll2}");
Console.WriteLine($"Third roll: {roll3}");

# Logi

## If statements

if statements are used to execute a code under certain conditions

```
Random card = new Random();

int draw1 = card.Next(1, 11);
int draw2 = card.Next(1, 11);
int draw3 = card.Next(1, 11);

int total = draw1 + draw2 + draw3;

Console.WriteLine($"Card Draw: {draw1} + {draw2} + {draw3} = {total}");

if (total <=  21){
    Console.WriteLine("You Win!!!");
}
if(total == 21){
    Console.WriteLine("BLACKJACK!");
}
if (total > 21) {
    Console.WriteLine("You Lose...");
}
```

# if...else Statements

You can use else to substitue another if to count for general or other conditions

```
Random card = new Random();

int draw1 = card.Next(1, 11);
int draw2 = card.Next(1, 11);
int draw3 = card.Next(1, 11);

int total = draw1 + draw2 + draw3;

Console.WriteLine($"Card Draw: {draw1} + {draw2} + {draw3} = {total}");

if (total <=  21){
    Console.WriteLine("You Win!!!");
}
if(total == 21){
    Console.WriteLine("BLACKJACK!");
}
else {
    Console.WriteLine("You Lose...");
}
```
You can also use nested if...elses to count for conditions that are more specific

```
Random card = new Random();

int draw1 = card.Next(1, 11);
int draw2 = card.Next(1, 11);
int draw3 = card.Next(1, 11);

int total = draw1 + draw2 + draw3;

Console.WriteLine($"Card Draw: {draw1} + {draw2} + {draw3} = {total}");

if (total <=  21){
    if(total == 21){
    Console.WriteLine("BLACKJACK!");
    }
    else{
        Console.WriteLine("Under 21! You Win!!!");
    }
}
else {
    Console.WriteLine("Over 21! Sorry You Lose...");
}
```

Yo can use Else if as an alternate to multiple ifs

```
Random random = new Random();
int daysUntilExpiration = random.Next(12);
int discountPercentage = 0;

if (daysUntilExpiration == 0)
{
    Console.WriteLine("Your subscription has expired.");
}
else if (daysUntilExpiration == 1)
{
    Console.WriteLine("Your subscription expires within a day!");
    discountPercentage = 20;
}
else if (daysUntilExpiration <= 5)
{
    Console.WriteLine($"Your subscription expires in {daysUntilExpiration} days.");
    discountPercentage = 10;
}
else if (daysUntilExpiration <= 10)
{
    Console.WriteLine("Your subscription will expire soon. Renew now!");
}

if (discountPercentage > 0)
{
    Console.WriteLine($"Renew now and save {discountPercentage}%.");
}
```


# Arrays 

An array is a sequence of individual data elements accessible through a single variable name. You use a zero-based numeric index to access each element of an array. As you'll see, arrays allow us to collect together similar data that shares a common purpose or characteristics in a single data structure for easier processing.

## Declaring A new array

```
string[] fradulentOrderIDs = new string[3]
```

## Assing values to elements of an Array

```
string[] fraudulentOrderIDs = new string[3];
fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
```

## Indexing an element that is out of bounds

Trying to index an element outside an established boundary will result in an error

```
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
fraudulentOrderIDs[3] = "D000"; //ERROR!
```

## Retreiveing values of an array

```
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");
```

## Reassigning Values

The elements of an array are just like any other variable value inasmuch as you can assign, retrieve, and reassign a value to each element of the array.

```
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
```

## Initializing an array


```
/*
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";
*/

string[] fraudulentOrderIDs = { "A123", "B456", "C789" };

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");
```

## Getting the size of an array.

```
/*
string[] fraudulentOrderIDs = new string[3];

fraudulentOrderIDs[0] = "A123";
fraudulentOrderIDs[1] = "B456";
fraudulentOrderIDs[2] = "C789";
// fraudulentOrderIDs[3] = "D000";
*/

string[] fraudulentOrderIDs = { "A123", "B456", "C789" };

Console.WriteLine($"First: {fraudulentOrderIDs[0]}");
Console.WriteLine($"Second: {fraudulentOrderIDs[1]}");
Console.WriteLine($"Third: {fraudulentOrderIDs[2]}");

fraudulentOrderIDs[0] = "F000";

Console.WriteLine($"Reassign First: {fraudulentOrderIDs[0]}");

Console.WriteLine($"There are {fraudulentOrderIDs.Length} fraudulent orders to process.");
```

# ForEach Loop and Array

The foreach statement loops through each element in an array, running the code block below its declaration, substituting the value in a temporary variable for the value of the array that the current loop represents.

```
int[] inventory = { 200, 450, 700, 175, 250 };
int sum = 0;
int bin = 0;
foreach (int items in inventory)
{
    sum += items;
    bin++;
    Console.WriteLine($"Bin {bin} = {items} items (Running total: {sum})");
}
Console.WriteLine($"We have {sum} items in inventory.");
```