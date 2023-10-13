using System.Reflection.Metadata;

using Interface;



internal class Tempt
{
    public static void Main()
    {
        Person nik = new Person("some");
        nik.CreateBankAccount(0);
        nik.CreateBankAccount(100);
        nik.CreateBankAccount(1000);
        foreach(var it in nik.CollectionBanks){
            Console.WriteLine(it.Data);
        }
    }
}