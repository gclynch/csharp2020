using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    delegate int SimpleDelegate();

    // a closure is a block of code that refers to a free variable (one declared outside itself)
    // that variable therefore does not go out of scope once referred to by that block of code
    // i.e the block of code "closes" over the variable

    class Closure
    {
        static SimpleDelegate CreateSimpleDelegate()
        {
            int i = 1;                      // the variable 
            return (() => i++);             // the block of code referring to it (an anonymous method)
        }

        // the anonymous method is "closed" over the free variable i (i is not a parameter or local variable in the anonymous method)
        // closures are a result of one function being defined inside the scope of another
        // the compiler detects when a anonymous method refers to a free variable and promotes it
        // and the free variable into a class that it generates and passes this compiler generated class around
        

        static void Main()
        {
            SimpleDelegate d = Closure.CreateSimpleDelegate();          // i will still be in scope for the anonymous method in CreateSimpleDelegate 
            Console.WriteLine(d());                                     // 2
            Console.WriteLine(d());                                     // 3
        }
    }
}
