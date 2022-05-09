# Delegates

The delegate is a reference type data type that defines the method signature. You can define variables of delegate, just like other data type, that can refer to any method with the same signature as the delegate.

## How do they work?

1. Declare a delegate
2. Set a target Method
3. Invoke a delegate

### Syntax

```
[access modifier] delegate [return type] [delegate name]([parameters])
```

### Example

```

public delegate void MyDelegate(string msg); // declare the delegate

//set the target method
MyDelegate del = new MyDelegate(MethodA);
// or
MyDelegate del = MethodA;
// or set lambda expression
MyDelegate del = (string msg) =>  Console.WriteLine(msg);

// target method
static void MethodA(string message)
{
    Console.WriteLine(message);
}

```

## Passing the Delegate as a parameter

A method can have a parameter of the delegate type, in the following answer.

```
    public delegate void MyDelegate(string msg); //declaring a delegate

class Program
{
    static void Main(string[] args)
    {
        MyDelegate del = ClassA.MethodA;
        InvokeDelegate(del);

        del = ClassB.MethodB;
        InvokeDelegate(del);

        del = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
        InvokeDelegate(del);
    }

    static void InvokeDelegate(MyDelegate del) // MyDelegate type parameter
    {
        del("Hello World");
    }
}

class ClassA
{
    static void MethodA(string message)
    {
        Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
    }
}

class ClassB
{
    static void MethodB(string message)
    {
        Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
    }
}

```

** Note: In .NET, Func and Action types are built-in generic delegates that should be used for most common delegates instead of creating new custom delegates.**

## Multicast Delegates

The delegate can point to multiple methods. A delegate that points multiple methods is a multicast delegate. The '+' and '+=' operator adds a function to the invocation list and the '-' and '-=' operator removes it.

```
public delegate void MyDelegate(string msg); //declaring a delegate

class Program
{
    static void Main(string[] args)
    {
        MyDelegate del1 = ClassA.MethodA;
        MyDelegate del2 = ClassB.MethodB;

        MyDelegate del = del1 + del2; // combines del1 + del2
        del("Hello World");

        MyDelegate del3 = (string msg) => Console.WriteLine("Called lambda expression: " + msg);
        del += del3; // combines del1 + del2 + del3
        del("Hello World");

        del = del - del2; // removes del2
        del("Hello World");

        del -= del1 // removes del1
        del("Hello World");
    }
}

class ClassA
{
    static void MethodA(string message)
    {
        Console.WriteLine("Called ClassA.MethodA() with parameter: " + message);
    }
}

class ClassB
{
    static void MethodB(string message)
    {
        Console.WriteLine("Called ClassB.MethodB() with parameter: " + message);
    }
}
```

The addition and subtraction operators always work as part of the assignment: del1 += del2; is exactly equivalent to del1 = del1+del2; and likewise for subtraction.

If a delegate returns a value, then the last assigned target method's value will be return when a multicast delegate called.

### Multicast Delegate returning a value

```
    public delegate int MyDelegate(); //declaring a delegate

class Program
{
    static void Main(string[] args)
    {
        MyDelegate del1 = ClassA.MethodA;
        MyDelegate del2 = ClassB.MethodB;

        MyDelegate del = del1 + del2;
        Console.WriteLine(del());// returns 200
    }
}

class ClassA
{
    static int MethodA()
    {
        return 100;
    }
}

class ClassB
{
    static int MethodB()
    {
        return 200;
    }
}
```

## Generic Delegates

A generic delegate can be defined the same way as a delegate but using generic type parameters or return type. The generic type must be specified when you set a target method.

```
    public delegate T add<T>(T param1, T param2); // generic delegate

class Program
{
    static void Main(string[] args)
    {
        add<int> sum = Sum;
        Console.WriteLine(sum(10, 20));

        add<string> con = Concat;
        Console.WriteLine(conct("Hello ","World!!"));
    }

    public static int Sum(int val1, int val2)
    {
        return val1 + val2;
    }

    public static string Concat(string str1, string str2)
    {
        return str1 + str2;
    }
}
```

# Recap of what Delegates are.

```
    1) Delegate is the reference type data type that defines the signature.

    2) Delegate type variable can refer to any method with the same signature as the delegate.

    3) Syntax: [access modifier] delegate [return type] [delegate name]([parameters])

    4) A target method's signature must match with delegate signature.

    5) Delegates can be invoke like a normal function or Invoke() method.

    6) Multiple methods can be assigned to the delegate using "+" or "+=" operator and removed using "-" or "-=" operator. It is called multicast delegate.

    7) If a multicast delegate returns a value then it returns the value from the last assigned target method.

    8) Delegate is used to declare an event and anonymous methods in C#.
```

# Func Delegate

C# includes built-in generic delegate types Func and Action, so that you don't need to define custom delegates manually in most cases.

Func is a generic delegate included in the System namespace. It has zero or more input parameters and one out parameter. The last parameter is considered as an out parameter.

```
namespace System
{
    public delegate TResult Func<in T, out TResult>(T arg);
}
```

The last parameter in the angle brackets <> is considered the return type, and the remaining parameters are considered input parameter types, as shown in the following figure.

You can assign any method to the above func delegate that takes two ints and returns an int value.

```
class Program
{
    static int Sum(int x, int y)
    {
        return x + y;
    }

    static void Main(string[] args)
    {
        Func<int,int, int> add = Sum;

        int result = add(10, 10);

        Console.WriteLine(result);
    }
}

//output
20
```

## Func with an Anonymous Method

You can assign an anonymous method to the Func delegate by using the delegate keyword.

```
Func<int> getRandomNumber = delegate()
                            {
                                Random rnd = new Random();
                                return rnd.Next(1, 100);
                            };
```

## With a Lamda Expressions

```
Func<int> getRandomNumber = () => new Random().Next(1, 100);

//Or

Func<int, int, int>  Sum  = (x, y) => x + y;
```

### In Summary

```
1) Func is built-in delegate type.

2) Func delegate type must return a value.

3) Func delegate type can have zero to 16 input parameters.

4) Func delegate does not allow ref and out parameters.

5) Func delegate type can be used with an anonymous method or lambda expression.
```

# Action Delegate

Action is a delegate type defined in the System namespace. An Action type delegate is the same as Func delegate except that the Action delegate doesn't return a value. In other words, an Action delegate can be used with a method that has a void return type.

## Example

```
public delegate void Print(int val);

static void ConsolePrint(int i)
{
    Console.WriteLine(i);
}

static void Main(string[] args)
{
    Print prnt = ConsolePrint;
    prnt(10);
}

//output
10
```


# Anonymous Methods

As the name suggests, an anonymous method is a method without a name. Anonymous methods in C# can be defined using the delegate keyword and can be assigned to a variable of delegate type.

```
public delegate void Print(int value);

static void Main(string[] args)
{
    Print print = delegate(int val) { 
        Console.WriteLine("Inside Anonymous method. Value: {0}", val); 
    };

    print(100);
}

// OutPut
Inside Anonymous Value: 100
```


Anonymous methods can access variables defined in an outer function.

```
public delegate void Print(int value);

static void Main(string[] args)
{
    int i = 10;
    
    Print prnt = delegate(int val) {
        val += i;
        Console.WriteLine("Anonymous method: {0}", val); 
    };

    prnt(100);
}

//Output 
Anonymous value: 110
```

Anonymous methods can also be passed to a method that accepts the delegate as a parameter.

In the following example, PrintHelperMethod() takes the first parameters of the Print delegate:

```
public delegate void Print(int value);

class Program
{
    public static void PrintHelperMethod(Print printDel,int val)
    { 
        val += 10;
        printDel(val);
    }

    static void Main(string[] args)
    {
        PrintHelperMethod(delegate(int val) { Console.WriteLine("Anonymous method: {0}", val); }, 100);
    }
}
```

## Limitations

It cannot contain jump statement like goto, break or continue.
It cannot access ref or out parameter of an outer method.
It cannot have or access unsafe code.
It cannot be used on the left side of the is operator.