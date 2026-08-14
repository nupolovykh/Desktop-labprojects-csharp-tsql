using System.Collections.ObjectModel;

namespace Interface;


public class Account
{
    public List<BankAccount> CollectionBanks = new List<BankAccount>(); //static
    public List<PersonalDiary> Diary = new List<PersonalDiary>();   //static

    public void CreateBankAccount(decimal amount){
        BankAccount new_ = new BankAccount();
        new_.Info = "empty";
        new_.Data = amount;
        CollectionBanks.Add(new_);        
    }

    public void CreateNote(string note){
        PersonalDiary new_ = new PersonalDiary();
        new_.Data = note;
        Diary.Add(new_);        
    }
}