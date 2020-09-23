// demo of properties

using System;

public class Person                     // : Object
{
    // 2 private fields
    private string name;
    private int age;

    // 2 public properties

    // property name doesn't have to correspond to field name
    public string Name			        // read-write property for name
    {
        get                             // no params allowed
        {
            return name;
        }

        set                             // no params allowed
        {
            if (!String.IsNullOrWhiteSpace(value))
            {
                name = value;		    // implicit parameter called "value"
            }
            else
            {
                throw new ArgumentException("Name invalid");
            }

        }

        // max 1 get block, max 1 set block
    }

    public int Age
    {
        get
        {
            return age;
        }
        set                         // can restrict get or set e.g. private set
        {
            if ((value >= 0) && (value <= 110))
            {
                age = value;		// implicit parameter called "value"
            }
            else
            {
                throw new ArgumentException("Age must be between 0 and 110");
            }
        }
    }


    // default constructor
    public Person() : this("no name", 0)
    {
    }

    // constructor
    public Person(String name) : this(name, 0)
    {
    }

    // constructor
    public Person(string name, int age)
    {
        Name = name;			// set called
        Age = age;              // set called
    }

}

public class Test
{
    static void Main()		// private
    {
        Person p1 = new Person("Gary", 42);

        Console.WriteLine(p1.Name);	// get called
        Console.WriteLine(p1.Age);	// get called

        p1.Age++;		            // set called
        Console.WriteLine(p1.Age);	// get called  

        // object initialiser "syntactic sugar":
        Person p2 = new Person { Name = "Ringo Starr", Age = 78 };			// default constructor called first, then setters
        Console.WriteLine(p2.Name);

        // object initialiser using non-default constructor first
        Person p3 = new Person("Paul McCartney") { Age = 77 };
        Console.WriteLine(p3.Name + " " + p3.Age);
    }
}