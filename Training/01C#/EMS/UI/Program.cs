//Call Employee
using UI;

Employee emp = new Employee();
//emp.firstName = "Garey";
//emp.lastName = "Greene";

//Employee.planet = "Venus"; //constants can never be changed after declaration
//Console.WriteLine("Enter your first name: ");
//var firstName = Console.ReadLine();
//Console.WriteLine("Enter your last name: ");
//var lastName = Console.ReadLine();
//Console.WriteLine("Enter your Employee ID: ");
//var id = Console.ReadLine();
//Console.WriteLine("Enter your Work Hours: ");
//var hours = float.Parse(Console.ReadLine());

Console.WriteLine($"Employee Id - {emp.id}\nEmployee Name- {emp.firstName} {emp.lastName}\n{Employee.planet}");
//emp.DoTask(firstName, lastName, id, hours);
//or
// emp.DoTask("Blake", "Harris", "432", 8);

Manager mgr = new Manager();
//Console.WriteLine(mgr.GetDetails("Blake", "Harris", "432", 28));
mgr.firstName = "Roy";
mgr.lastName = "Fokker";
mgr.id = "444";
mgr.authority = Authority.Delegate;

mgr.payRate = 150.00M;
mgr.healthCare = 155;
mgr.taxes = 0.3M * mgr.payRate;
mgr.bonus = 100;
mgr.housing = 1000;
mgr.paidVacation = 800;

Console.WriteLine(mgr.ToString());
Console.WriteLine(mgr.PayCalc());

Console.WriteLine(emp.FirstName);

//method overloading
emp.payRate = 55.60M;
emp.hours = 9;

emp.taxes = 0.3M * emp.payRate;
//Example of method overloading
Console.WriteLine($"Salay = {emp.PayCalc("100.00", "1000")*20}/month");  