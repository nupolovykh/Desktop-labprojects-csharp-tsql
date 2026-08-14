using System.Reflection.Metadata;

using Interface;



internal class Tempt
{
    
    public static void TryCatchFinally()
    {
        try
        {
            int index = 0;
            var person = new Person();
            var person2 = new Person();
            person.Increase(1000, index);
            Console.WriteLine($"Balance: {person.Account.CollectionBanks[index].Data}");
            person2.Decrease(500, index);
            Console.WriteLine($"Balance: {person.Account.CollectionBanks[index].Data}");

            person.ShowBalance();
            person2.ShowBalance();

            person.Account.CollectionBanks[index].LockEdit();
            person.Increase(500, index);
            person.Account.CollectionBanks[index].LockRead();
            Console.WriteLine($"Balance: {person.Account.CollectionBanks[index].Data}");
            person.Account.CollectionBanks[index].UnLock();
            Console.WriteLine($"Balance: {person.Account.CollectionBanks[index].Data}");

            
        }
        catch (ValueIsLockedException exception)
        {
            Console.WriteLine(exception.Message);
        }
        finally
        {
            Console.WriteLine("Program execution complete.");
        }
    }
}