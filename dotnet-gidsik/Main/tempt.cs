namespace Tempt
{
    class Person {
        public string name = "Undefined";
        public string Name { get { return name; } set { name = value; } }
    }

    public static class Tempt{
        public static void MyMethod(){
            Person person = new Person();
            person.name = "delef";
            person.Name = "Undefined";
            Console.WriteLine(person.name);
            Console.WriteLine(person.Name);
        }
    }
}