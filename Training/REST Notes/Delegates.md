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
