// demo of structures, structs are value types

using System;

// all simple types in C# e.g. int, bool etc. are aliases for Structs e.g. System.Int32, System.Boolean etc.
// Structs are value types which directly contain values, allocated on stack
// Structs can be for performance enhancement
// Structs do not support inheritance (except that they inherit from Object)
// Structs can have constructors, methods, and properties

// base class of a struct is ValueType, base class of ValueType is Object

namespace StructDemo
{
    // define custom value type
    public struct ClockTime	    // use only for small data structures, implictly sealed
    {
        int hours;              // 0 .. 23          24 hour clock format
        int minutes;            // 0 .. 59
        int seconds;            // 0 .. 59

        // default constructor supplied by compiler, cannot be explicity coded


        // non-default constructor, must initialise all fields
        public ClockTime(int hours, int minutes, int seconds)
        {
            // must initialise all fields else syntax error

            if ((hours >= 0) && (hours <= 23))
            {
                this.hours = hours;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for hour: " + hours);
            }
            if ((minutes >= 0) && (minutes <= 59))
            {
                this.minutes = minutes;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for minute: " + minutes);
            }
            if ((seconds >= 0) && (seconds <= 59))
            {
                this.seconds = seconds;
            }
            else
            {
                throw new ArgumentException("Invalid value specified for seocnd: " + seconds);
            }
        }


        // read only properties

        public int Hours
        {
            get => hours;
        }

        public int Minutes
        {
            get => minutes;
        }

        public int Seconds
        {
            get => seconds;
        }

        // move the time forward by 1 second
        public void Tick()
        {
            if (seconds < 59)
            {
                seconds++;
            }
            else
            {
                seconds = 0;
                if (minutes < 59)
                {
                    minutes++;
                }
                else
                {
                    minutes = 0;
                    if (hours < 23)
                    {
                        hours++;
                    }
                    else
                    {
                        hours = 0;
                    }
                }
            }
        }
        // inherited from System.Object, via System.ValueType (an abstract class)
        public override string ToString() => $"{Hours:D2}:{Minutes:D2}:{Seconds:D2}";       // string interpolation
    }

    // todo: override Equals, ==, != since value type

    class Test
    {
        static void Main()
        {
            ClockTime t1 = new ClockTime(11, 59, 59);               // almost noon
            ClockTime t2 = t1;                                      // copy the whole structure t1 into t2
            t2.Tick();                                              // noon now, t1 unaffected
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());
        }
    }
}