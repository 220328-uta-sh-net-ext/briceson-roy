global using System;
using CSharpBasics;

// Console.Write("Please enter a number");
// var x = Convert.ToDouble(Console.ReadLine());
// Console.Write("Please enter a number");
// var y = Convert.ToDouble(Console.ReadLine());

// Mathematics obj=new Mathematics();


// var sum= obj.Add(x, y);
// Console.WriteLine($"{x} + {y} equals {sum}");

//Arrays

// int[] a = {54, 0 , 46, 0};
// CsharpArrays.MoveIt(a);
// foreach (var item in result){
//     Console.Write(item + " ");
// }
// CsharpCollections.GenericsLinkedList();


/*int num = 0;
int dem = 0;
Console.WriteLine("Enter Numerator");
num:
try{
    
     num = Convert.ToInt32(Console.ReadLine());
}
catch(OverflowException ex){
    Console.WriteLine(ex.Message);
    goto num;
}
catch(Exception ex){
    Console.WriteLine(ex.Message);
    goto num;
}
dem:
Console.WriteLine("Enter Denominator");
try{
  dem = Convert.ToInt32(Console.ReadLine());
}
catch(OverflowException ex){
    Console.WriteLine(ex.Message);
    goto dem;
}
catch(Exception ex){
    Console.WriteLine(ex.Message);
    goto dem;
}
var quotient = ExceptionHandling.Division(num, dem);
Console.WriteLine(quotient);*/

// try{
//     Temperature.CheckTemperature(25);
// }

Console.WriteLine(CodingChallengeTest.Palindrome("giraffarig"));

Console.WriteLine(CodingChallengeTest.Anagram("garden", "danger"));