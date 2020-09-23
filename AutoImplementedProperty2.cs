// demo of automatic properties, part 2

using System;

// this is an exmaple of an immutable class - cannot change state once constructed
public class Person
{
    // get only auto property with initialiser
    public string Name { get; }            

    // get only auto property, can be initialsed here or in constructor
    // if not initialised then backing field has default value (null for reference types)

    public Person()
    {
        Name = "Gary";
    }

  
    public Person(String name) => Name = name;
   
    // can set backing field in a constructor either
    
}

public class Test
{
    static void Main()
    {
        Person p1 = new Person();
        Console.WriteLine(p1.Name);

        Person p2 = new Person("Fred");
        Console.WriteLine(p2.Name);
    }
}