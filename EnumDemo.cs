// demo of enumerations - enums are value types
// System.Enum is base class for enumerations, enums behave as value types, 
// System.Enum subclass of System.ValueType

using System;
using static System.Console;

// RGB colors
public enum Color				                    // underlying type is int
{
    Red, Green, Blue                                // 0, 1, 2 variants
}

// days of the week
public enum Day
{
    Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
}

class Test
{
    public static void Main()
    {
        Color c1 = Color.Red;
        Color c2 = c1;                          // enums are value types, this is a copy
        c2 = Color.Green;
        WriteLine(c1);                          // still Red
        WriteLine(c2);                          // Green
        WriteLine((int)Color.Blue);             // 2

        Day d1 = Day.Wednesday;
        short dayNo = (short)d1;                // 2
        WriteLine("Day " + dayNo);
        dayNo++;
        d1 = (Day)dayNo;                        // Thursday is day 3
        WriteLine(d1);

        // can parse a string to an enum
        Day d2 = (Day)Enum.Parse(typeof(Day), "Friday");           // can throw ArgumentException, case sensitive
        Console.WriteLine(d2);

    }
}
