// demo of interfaces - part 2

using System;

// 2 interfaces

public interface IDrawable
{
    void Draw();
}

public interface IHasColor
{
    String Color { get; set; }
}


// Circle has a color and origin (x, y) coordinates
class ColoredCircle : IHasColor, IDrawable
{
    // origin
    public int X { get; set; }                 // x coordinate in 2D space
    public int Y { get; set; }                 // y coordinate in 2D space

    public int Radius { get; set; }

    // implement Color property because of IDraw
    public void Draw() =>
        Console.WriteLine($"Drawing a {Color} Circle at ({X}, {Y}), Radius {Radius}");

    // implement Color property because of IHasColor, auto property will suffice for now
    public String Color { get; set; }
}

class Test
{
    public static void Main()
    {
        // polymorphic reference of interface type
        IDrawable i = new ColoredCircle { X = 10, Y = 20, Radius = 10, Color = "Red" };
        i.Draw();                                               // can't call Color on i   

        // polymorphic reference of interface type
        IHasColor c = new ColoredCircle { X = 5, Y = 5, Radius = 10, Color = "Blue" };
        Console.WriteLine(c.Color);                             // can't call Draw on c

        // multiple polymorphism
    }
}