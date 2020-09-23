// Main.cs

// can have several entry points, 1 per class
// csc /main:Main1 Main.cs
// won't compile unless 1 entry point specified

class Main1
{
	static void Main(string[] args)				// internal
	{
		System.Console.WriteLine("In Main1 with args");
	}
}

class Main2
{
	static int Main()					        // internal
	{
		System.Console.WriteLine("In Main2");
		return 1;					            // won't compile without return value
	}
}


/*

4 possible Mains:

public static void Main();
public static int Main();
public static void Main(string[] args);
public static int Main(string[] args);

*/