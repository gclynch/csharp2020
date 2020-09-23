// ValueTuple struct (alternative to System.Tuple reference type)
// useful when a method returns multiple values
// alternative to out params or System.Tuple (verbose) or custom built-in transport type

using System;

namespace Tuples
{
    class Demo
    {
        // a method whoose return type is a value type
        static (string name, string email) Lookup(String staffID)
        {
            // check db or file ...
            return ("Gary Clynch", "gary.clynch@ittdublin.ie");
        }

        static void Main()
        {
            var details = Lookup("422");
            Console.WriteLine(details.name + " " + details.email);			
        }

        // tuple can have up to 8 components
		
		// (string, string)		has Item1 and Item2 component names
    }
}
