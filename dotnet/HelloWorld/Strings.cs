// See https://aka.ms/new-console-template for more information
//String Escape Sequences

// the \n will add a new line
Console.WriteLine("Hello\nWorld!");

// the \t will insert a tab space
Console.WriteLine("Hello\tWorld!");

//escape clauses will cause errors
//Console.WriteLine("Hello "World"!"); 

//use escape clauses to break out and use special characters
Console.WriteLine("Hello \"World\"!");

/*can't use forward slashes to display a file path since that's 
reserved for escape clauses*/
// Console.WriteLine("c:\source\repos");

//to solve this use // to display file paths
Console.WriteLine("c:\\source\\repos");

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
/*A verbatim string literal will keep all whitespace and characters 
without the need to escape the backslash. To create
 a verbatim string, use the @ directive before the literal string.*/
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
