// deconstructor
// not same as destructor (for managed resources) or finalizer (for unmanaged resources)
// allows spittling an object into constitutent components using simple syntax
// use value tuples

using System;

namespace Tuples
{
    class Point
    {
        public int X
        {
            get; set;
        }

        public int Y { get; set; }

        // public void Deconstruct(out T1 x1, ..., out Tn xn) { ... } is a desconstructor

        public void Deconstruct(out int x, out int y)
        {
            x = X;
            y = Y;
        }
    }

    class Test
    {
        public static void Main()
        {
            Point p = new Point { X = 10, Y = 20 };
            var (x, y) = p;                                 // deconstruct object
            Console.WriteLine("(" + x + "," + y + ")");
        }
    }
}