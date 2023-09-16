// See https://aka.ms/new-console-template for more information
using TestConsoleApp;
using figures;
{ }

var circle = new Circle(1);
var rectangle = new Rectangle(2, 2);
var triangle = new Triangle(3, 4, 5);

var collection = new List<IHaveArea>
{
    circle,
    rectangle,
    triangle
};



foreach (var item in collection)
{
    Console.WriteLine(item.get_space());
}


//string tempt = Console.ReadLine(); //// = "(){[(})]";
//Console.WriteLine(chechbreaker.Check(tempt));

