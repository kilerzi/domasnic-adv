using System;
using System.Collections.Generic;

public class PrintInConsole
{
    //printni bilo koj single value od bilo koj tip
    public void Print<T>(T value)
    {
        Console.WriteLine(value);
    }

    // printni bilo koj collection od bilo koj tip
    public void PrintCollection<T>(IEnumerable<T> collection)
    {
        foreach (var item in collection)
        {
            Console.WriteLine(item);
        }
    }
}
