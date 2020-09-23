using System;
using Garage;

// application assembly i.e. .exe
// csc /reference:Car.dll CarTest.cs

// or csc car.cs cartest.cs

// default (global) namespace

class CarTest
{
    // can have several Mains
    public static void Main()
    {
        // constructor needs to be public, internal no good, different assembly
        Car c = new Car("Mazerati", "Ghibli", registration: "202 MH 202");		// Garage.Car....

        Console.WriteLine(c);                                   // c.ToString()
		
		// to do: use unit tests instead of main
    }
}