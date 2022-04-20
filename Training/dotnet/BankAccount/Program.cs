// See https://aka.ms/new-console-template for more information
using Classes;


var account = new BankAccount("Briceson", 1000);
// Console.WriteLine($"Account {account.Number} was created for {account.Owner} with {account.Balance} initial balance.");

// account.MakeWithdrawal(500, DateTime.Now, "Rent payment");
// Console.WriteLine(account.Balance);
// account.MakeDeposit(100, DateTime.Now, "Friend paid me back");
// Console.WriteLine(account.Balance);

// Test that the initial balances must be positive.
// BankAccount invalidAccount;
// try
// {
//     invalidAccount = new BankAccount("invalid", -55);
// }
// catch (ArgumentOutOfRangeException e)
// {
//     Console.WriteLine("Exception caught creating account with negative balance");
//     Console.WriteLine(e.ToString());
//     return;
// }

// 

Console.WriteLine(account.GetAccountHistory());