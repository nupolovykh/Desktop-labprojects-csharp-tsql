// See https://aka.ms/new-console-template for more information

string expression = Console.ReadLine(); //"(0-3)*(5+8-(1*5)+2)/2"
string reverse_describe = Calculator.Dijkstra(expression);
Console.WriteLine(reverse_describe + " --> " + Calculator.Decode(reverse_describe));