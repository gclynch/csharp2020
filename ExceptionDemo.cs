using System;

class SafeDivision
{
    // throw an exception if y is 0
    public static double Divide(double x, double y)			// no throws clause in C#
    {
        if (y == 0)
        {
            throw new DivideByZeroException("Can't divide " + x + " by zero");
        }
        else
        {
            return x / y;
        }
    }

    static void Main()				        // private
    {
        try
        {
            Console.WriteLine(Divide(10, 0));
        }
        catch (DivideByZeroException e) 			
        {
            Console.WriteLine(e.Message);
        }
        catch (Exception)					// don't need an object e.g. Exception e
        {
            //...
        }
        finally
        {
            // release resources..
            // finally blocks runs after try block completes or after handling of an exception by a catch block
        }
    }
	
	// also exception filters 
	// e.g. catch (HttpWebException e) when (e.Message.Contains("400"))
}
