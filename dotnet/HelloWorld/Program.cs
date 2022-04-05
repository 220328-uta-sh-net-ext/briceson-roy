using System;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Welcome to Jamrock! Who you a-be?"); //writes a line that's specified in the parentheses
var name=Console.ReadLine(); //takes an input in string format i.e name

var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Current Date: {currentDate:d} \nWah Gwan, {name}!");