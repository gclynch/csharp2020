using System;

// a library assembly i.e. dll
// csc /target:library Car.cs produces Car.dll

namespace Garage									                    // sort of like a Java package
{
    public class Car : Object						                    // i.e. System.Object, internal default
    {
        private string make, model, registration;					    // fields (member vars in Java)

        // constructor
        public Car(string make, string model, string registration)	    // default is private
        {
            this.make = make;
            this.model = model;
            this.registration = registration;
        }

        // default constructor (one provided if none specified)
        public Car() : this("", "", "")
        {
        }

        // destructor, called by garbage collector, can't be explicitly called
        ~Car()
        {
          Console.WriteLine("{0} destructed", this.registration);
        }


        // public virtual string ToString() in System.Object, virtual => can be overriden in subclasses 
        public override string ToString() => $"make: {make} model {model} registration {registration}";			
        // string interpolation

        // expression body defintion (methods, property get or set, indexer, constructor)

    }
}