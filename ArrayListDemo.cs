// demo of ArrayList - dynamically sized collections, which can have items added to the end, inserted in
// the middle, and removed easily
// collection of Object references, if value types then boxed/unboxed - performance hit
// dynamic array, Count, Capacity

using System;
using System.Collections;

namespace Animal
{
    public class Dog
    {
        // 2 auto properties
        public String Name { get; set; }
        public String Breed { get; set; }

        public override string ToString()
        {
            return Name + " is a " + Breed;
        }
    }

    // test class
    class Test
    {
        public static void Main()
        {
            ArrayList litter = new ArrayList();                                     // a collection of Objects
            // add 2 dogs
            litter.Add(new Dog() { Name = "Snoop", Breed = "Rottweiler" });
            litter.Add(new Dog() { Name = "Pluto", Breed = "Labrador" });

            // can add other things other than Dogs litter.Add(new Object());

            foreach (Dog d in litter)                   // ArrayList is an enumerable type
            {
                Console.WriteLine(d);
            }

            Console.WriteLine();

            // insert a new dog in middle of litter
            litter.Insert(1, new Dog() { Name = "Scooby", Breed = "Great Dane" });

            // take out last dog
            litter.RemoveAt(litter.Count - 1);                          // Count, not Length

            for (int i = 0; i < litter.Count; i++)
            {
                // retireve item and cast to Dog
                Dog dog = (Dog) litter[i];                              // indexer get, set also possible, O(1)
                Console.WriteLine(dog);
            }
        }
    }
}