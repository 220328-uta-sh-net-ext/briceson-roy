global using System;
using CSharpBasics;

Console.Write("Please enter a number");
var x = Convert.ToDouble(Console.ReadLine());
Console.Write("Please enter a number");
var y = Convert.ToDouble(Console.ReadLine());

Mathematics obj=new Mathematics();


var sum= obj.Add(x, y);
Console.WriteLine($"{x} + {y} equals {sum}");