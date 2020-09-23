// demo of async and await C# 5
// async: an asynchronous method which runs synchronously until first await at which point it suspends
// and returns to its caller to be continued, awaited task will complete later

using System;
using System.Threading.Tasks;

namespace AsynchronousProgrammingDemo
{
    class Demo
    {
        // an asynchronous method i.e. call to it may return after it's first await
        // return statement returns an int since Task<int> is return type
        // the int is "awaitable"
        public static async Task<int> SleepAsync()
        {
            // random length nap in milliseconds
            int nap = new Random().Next(10000);         // get random number up to 10000

            Console.WriteLine("SleepAsync: About to sleep ");
            await Task.Delay(nap);                      // suspend execution and return to caller if Task.Delay() not finished

            // continue here, nap finished
            Console.WriteLine("SleepAsync: Finished sleep");
            return nap;                                 // an int

            // return type can be Task, Task<T> or void
            // an async method must have an await otherwise it is synchronous, flagged with compiler warning
        }


        // run some async methods, a method with an await must be async itself
        // no return statement, Task
        public async static Task RunAsync()
        {
            Console.WriteLine("RunAsync: async call to SleepAsync");
            Task<int> t = SleepAsync();

            // do some other indepedent work here in the meantime.... here or call a synchronous method

			// out of things to do now await result from t
            Console.WriteLine("RunAsync: awaiting SleepAsync result..");
            int slept = await t;                                // suspend and return to caller if not finished

            // or
            // int slept = await SleepAsync();					

            // result in slept now available
            Console.WriteLine("RunAsync: Slept for " + slept + " milliseconds");

            // no return value
        }

        // entry point
        static void Main()
        {
            Task t = RunAsync();
            t.Wait();                                           // block, not the same as an await, fine since no UI
            // await means method being called must return Task or Task<T>
        }
    }
}

// await takes a single argument - an "awaitable" i.e. an asynchronous operation (method, lambda, anonymous method)
// await will check if the awaitable is finished, if so just continue on executing the code after the await (act synchronously)
// if not finished then it tells the awaitable to run the rest of the method when it finishes and then return (i.e. act asynchronously)
// the awaitable when finished will run the rest of the async method
// awaitable types are Task and Task<T>
// an async method can have a Task, Task<T> or void return type (void is not awaitable)
// a method does not have to be async to be awaited, but an await in a method means it must be async