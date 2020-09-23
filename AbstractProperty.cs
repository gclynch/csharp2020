// abstract property in an abstract class

using System;

public abstract class Shape
{
    // auto-implemented property
    public String ID { get; set; }

    // read only abstract property - virtual implied
	// set not appropriate here since area calculated
	// Shape must be abstract, similiar syntax to auto property
	
    public abstract double Area { get; }
   

    // constructor 
    protected Shape(String ID)
    {
        this.ID = ID;       // use auto property
    }
}

public class Square : Shape
{
    // auto property
    public double Side { get; set; }

    // implement Area calculation for a Square
    public override double Area
    {
        get => Side * Side;
    }

    // default constructor
    public Square(String id, double side) : base(id)
    {
        Side = side;
    }
}


// test class
public class Test
{
    static void Main()              // private
    {
        Square s = new Square("Square 1", 10);
        Console.WriteLine(s.Area);
    }
}