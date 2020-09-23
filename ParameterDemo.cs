using System;

// demo of value, reference and output parameters, and Equals

// test class - a character list (array)
class Point
{
    // 2 auto-implemented properties

    public int X { get; set; }

    public int Y { get; set; }

    // constructor
    public Point(int x, int y)				// int is a value type
    {
        this.X = x;
        this.Y = y;
    }

    public override string ToString()
    {
        return "X: " + X + " Y: " + Y;
    }

    // inherited from Object
    // Equals by default tests reference (not value) equality for reference types i.e. do they refer to same object
    // and value equality (bitwise) for value types

    // override to do value comparison
    public override bool Equals(Object obj)
    {
        Point p = obj as Point;         // returns null if cast not possible rather than throwing InvalidCastException

        if (p is null)					// pattern match against constant
        {
            return false;
        }

        // does p have the same data as this ?
        if ((p.X == this.X) && (p.Y == this.Y))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // good practice to override this if overriding Equals
    public override int GetHashCode()
    {
        // return a hash (key) value for this object
        // object with same content should return same hash value

        return (X * 17) ^ Y;			// simple hash: multiply by a prime and XOR the result
    }

}

// class to demo parameter options

class Geometry
{
    public static void Move(Point p, int xAmount, int yAmount)	// ref implied since ref type
    {
        p.X += xAmount;
        p.Y += yAmount;
    }

    public static void Swap1(int x, int y)				        // value, no swap
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Swap2(ref int x, ref int y)			    // ref, swap works
    {
        int temp = x;
        x = y;
        y = temp;
    }
	
	// can also have a ref return type i.e. returns memory location of item e.g. in a big data structure which
	// can be modified afterwards

    public static void Add(int x, int y, out int answer)		// output parameter
    {
        answer = x + y;
    }
	
	// functions can be defined inside functions

}

// test class
class Test
{
    public static void Main()
    {
        Point p1 = new Point(10, 20);
        Point p2 = new Point(10, 20);

        if (p1 == p2)						// false, different objects
        {
            Console.WriteLine(p1 + " == " + p2);
        }

        // true, values are same in p1 and p2
        if (p1.Equals(p2))					// or Object.Equals(p1, p2)
        {
            Console.WriteLine(p1 + " Equals " + p2);	// same	
        }

        // params demos

        Geometry.Move(p1, 10, 10);
        Console.WriteLine(p1);			    // 20,30


        int x, y;

        x = 10;
        y = 20;
        Geometry.Swap1(x, y);
        Console.WriteLine(x + " " + y);		// 10,20


        x = 10;
        y = 20;
        Geometry.Swap2(ref x, ref y);
        Console.WriteLine(x + " " + y);		// 20,10


        x = 10;
        y = 20;
        Geometry.Add(x, y, out int z);
        Console.WriteLine(z);			    // 30

    }
}