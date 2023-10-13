using Interface;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Interface;

public class Person
{
    public string Password { get; }

    public Collection<BankAccount> CollectionBanks = new Collection<BankAccount>();
    public Collection<PersonalDiary> Diary = new Collection<PersonalDiary>();
    public Person() => Password = "1";
    public Person(string password) => Password = password;

    public void CreateBankAccount(decimal amount){
        BankAccount new_ = new BankAccount();
        new_.Data = amount;
        new_.Owner = this;
        CollectionBanks.Add(new_);        
    }

    public void CreateNote(string note){
        PersonalDiary new_ = new PersonalDiary();
        new_.Data = note;
        new_.Owner = this;
        Diary.Add(new_);        
    }
}