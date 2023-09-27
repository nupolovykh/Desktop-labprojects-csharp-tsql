// See https://aka.ms/new-console-template for more information
using FistLibrary;

double[] arrayName = { 1, 2, 3, 4, -5, 6};
Console.WriteLine(ArrayMethodsLibrary.FindMinimum(arrayName));
Console.WriteLine(ArrayMethodsLibrary.FindMaximum(arrayName));
Console.WriteLine(ArrayMethodsLibrary.FindAverage(arrayName));
Console.WriteLine(ArrayMethodsLibrary.FindMedian(arrayName));
Console.WriteLine(ArrayMethodsLibrary.FindGeometricAverage(arrayName));

// string expression = Console.ReadLine(); //"(0-3)*(5+8-(1*5)+2)/2"
// Calculator.Tests(expression);
// string reverse_describe = Calculator.Dijkstra(expression);

// Console.WriteLine($"({reverse_describe}) --> {Calculator.Decode(reverse_describe)}");
