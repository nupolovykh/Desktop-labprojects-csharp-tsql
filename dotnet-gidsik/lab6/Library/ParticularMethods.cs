namespace Library
{
    public class ParticularMethods
    {
        public static string Create(int option) {
            if(option == 0) Console.WriteLine("Enter your username:");
            else Console.WriteLine("Enter your age:");
            return Console.ReadLine()!.Trim();
        }
        public static void List(List<Person> people)
        {
            foreach (var person in people) Console.WriteLine($"{person.name} {person.age} years old");
        }
    }
}