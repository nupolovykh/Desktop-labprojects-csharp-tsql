// See https://aka.ms/new-console-template for more information
using System.ComponentModel;
using Methods;

public static class Extensions
{
    public static void TestTheInput(this string input)
    {
        foreach(char it in input) if(it != '-' && !char.IsDigit(it)) throw new ArgumentException("Error");
    }
}

internal class Program
{
    private static void Main(string[] args)
    {
        double[] array = new double[10];
        for (int i = 0; i < array.Length; i++)
        {
            string input = Console.ReadLine();
            Extensions.TestTheInput(input);
            array[i] = double.Parse(input);
        }

        Console.WriteLine("Minimum = " + ArrayMethodsLibrary.FindMinimum(array));
        Console.WriteLine("Maximum = " + ArrayMethodsLibrary.FindMaximum(array));
        Console.WriteLine("Average = " + ArrayMethodsLibrary.FindAverage(array));
        Console.WriteLine("Median = " + ArrayMethodsLibrary.FindMedian(array));
        Console.WriteLine("GeometricAverage = " +ArrayMethodsLibrary.FindGeometricAverage(array));

        // string expression = Console.ReadLine(); //"(0-3)*(5+8-(1*5)+2)/2"
        // Calculator.Tests(expression);
        // string reverse_describe = Calculator.Dijkstra(expression);
        // Console.WriteLine($"({reverse_describe}) --> {Calculator.Decode(reverse_describe)}");
    }
}