// a delegate is an object which contains a reference to a method

using System;

delegate string GreetingDelegate();			// a delegate referring to a method which returns a string taking no params

class Person
{
    string Name { get; set; }

    // method which adheres to GreetingDelegate definition
    public string SayHello()
    {
        return "Hello " + Name;
    }

    // method which adheres to GreetingDelegate definition
    public string SayGoodBye()
    {
        return "Goodbye " + Name;
    }

    // entry point
    public static void Main()
    {
        Person p1 = new Person { Name = "Gary" };

        GreetingDelegate gd = new GreetingDelegate(p1.SayHello);
        Console.WriteLine(gd());

        gd = new GreetingDelegate(p1.SayGoodBye);
        Console.WriteLine(gd());

        // plug in a lamdba expression instead (i.e. an anonymous function)
        gd = new GreetingDelegate(() => "See you soon " + p1.Name);
        Console.WriteLine(gd());
    }
}
