using Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface;

public class Person
{
    public string Password { get; set; }
    public Person() => Password = "1";
    public Person(string password) => Password = password;

    public BankAccount BankAccount = new BankAccount(0);

    public void CreateNewDiary(string password)
    {
        
    }
    public void CreateNewBankAccont(string password)
    {

    }
}
