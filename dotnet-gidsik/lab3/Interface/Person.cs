
using Microsoft.VisualBasic;

namespace Interface;

public class Person
{
    //public Lazy<Account> account;
    public Account Account;
    public string Password { get; }

    Random random = new Random();

    // public Account account
    // {
    //     get
    //     {
    //         Account = new Account();
    //         return Account;
    //     }
    // }

    public Person()
    {
        Password = "1";
        Account = new Account();
        Account.CreateBankAccount(random.Next(1000, 5000));
        Account.CreateNote("salary");

        //account = new Lazy<Account>(() => new Account());
    }

    public Person(string password)
    {
        Password = password;
        Account = new Account();
        Account.CreateBankAccount(random.Next(2000, 5000));
        Account.CreateNote("salary");

        //account = new Lazy<Account>(() => new Account());
    }

    public void Increase(decimal amount, int index){
        if(index >= 0 && index <= Account.CollectionBanks.Count()) Account.CollectionBanks[index].Data += amount;
    }

    public void Decrease(decimal amount, int index){
        if(index >= 0 && index <= Account.CollectionBanks.Count()) Account.CollectionBanks[index].Data -= amount;
    }

    public void ShowBalance(){
        foreach(var it in Account.CollectionBanks){
            Console.WriteLine(it.Data);
            Console.WriteLine(it.Info);
        }
    }

}
