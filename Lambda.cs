// Lambda expressions =>
// a Lambda is an expression which returns a method
// no method name specified, return type inferred from context where used
// specify input parameters (and optionally their types)
// and a method body (or an expression if just one statement in method body)

using System;

namespace LambdaCalculus
{

    class Lamdbda1                       // '=>' defines a lamdbda expression i.e. "goes to"
    {
        delegate int UnaryIntegerOperation(int x);
        delegate int BinaryIntegerOperation(int x, int y);

        static int DoUnaryOperator(UnaryIntegerOperation op, int x)
        {
            return op(x);
        }

        static int DoBinaryOperator(BinaryIntegerOperation op, int x, int y)
        {
            return op(x, y);
        }

        // plug and play methods for the various delegates and call DoUnaryOperator and
        // DoBinaryOperator, methods defined using lambda expressions
        public static void Main()
        {
            Console.WriteLine(DoUnaryOperator(x => x * x, 5));                          // square 5
            Console.WriteLine(DoUnaryOperator(x => { x = x * x; return x; }, 5));       // square 5
            Console.WriteLine(DoUnaryOperator((int x) => x * x * x, 6));                // cube 6, explicit type for param

            Console.WriteLine(DoBinaryOperator((x, y) => x * y, 5, 6));                 // 5 * 6   
        }
    }
}