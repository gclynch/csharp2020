// demo of indexers, access an object like an array (using [] syntax)

using System;
using System.Collections.Generic;

// a simple blog
class Blog
{
    private List<string> words;				

    // default constructor

    public Blog()
    {
        words = new List<string>();
    }

    public String Author { get; set;}

    // read-only property
    public int Length
    {
        get
        {
            return words.Count;                    
        }
    }

    // an indexer is a property called "this"
    // indexer, read/write
    public String this[int i]
    {
        get
        {
            if ((i >= 0) && (i < words.Count))
            {
                return words[i];
            }
            else
            {
                throw new ArgumentException("index is out of bounds: " + i);
            }
        }
        set
        {
            if ((i >= 0) && (i < words.Count))
            {
                words[i] = value;                       // replace
            }
            else if (i == words.Count)
            {
                words.Add(value);                       // add at end
            }
            else
            {
                throw new ArgumentException("index is out of bounds: " + i);
            }

        }

    }

    // can overload indexers - each with different index types
    // can put indexers in interfaces
}

// test class
class Test
{
    public static void Main()
    {
        Blog blog = new Blog();

        // set the author
        blog.Author = "GC";

        // indexer sets, treat a blog object like it was an array
        blog[0] = "Welcome";				// 0 is 1st
        blog[1] = "2";
        blog[1] = "to";                     // overwrite
        blog[2] = "my";
        blog[3] = "blog";


        for (int i = 0; i < blog.Length; i++)
        {
            Console.Write(blog[i] + " ");	// indexer gets
        }

        Console.WriteLine();
    }


    // indexer could be public char this[int i, int j]	// 2D collection

    // index doesn't have to be an int e.g.
    //		public Customer this[string name]			// in CustomerList class
    //		Customer c = CustomerList["Gary Clynch"]   
}