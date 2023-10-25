using System.Text.Json;

namespace UnitTests;

using System.Data;
using System.Transactions;
using Main;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;

public class UnitTestSecond
{

    [Fact]
    public void AgeTest()
    {
        string pathToInput = @"..\..\..\..\People.json";
        string pathToOutput = @"..\..\..\..\OfficeBirthdays.txt";
        List<Person> people = Birthdays.CreateBirthdayFile(pathToInput, pathToOutput);

        using FileStream stream = new FileStream(pathToOutput, FileMode.Open);
        using StreamReader reader = new StreamReader(stream);

        bool answer = true;
        int indexOfPeople = 0;
        while(!reader.EndOfStream){
            string str = reader.ReadLine()!;

            char pointer = str[0];
            int index, indexMouth = 0;
            for(index = 0; pointer != ':'; index++){
                if(char.IsLetter(pointer) & indexMouth == 0) indexMouth = index;
                pointer = str[index];
            }
            string birthday, mounthStr;
            int mounthInt = 0, day, age;
            birthday = str.Substring(0, index - 1);
            mounthStr = birthday.Substring(indexMouth - 1);

            Birthdays birthdays = new Birthdays();
            foreach (KeyValuePair<int, string> mouth in birthdays.mounth){
                if (mouth.Value == mounthStr){
                    mounthInt = mouth.Key;
                    break;
                }
            }
            day = Convert.ToInt32(char.IsDigit(birthday[1]) ? birthday.Substring(0, 2) : birthday[0].ToString());
            age = Convert.ToInt32(str.Substring(str.Length - 2));

            DateTime currentTime = DateTime.Now;
            //currentTime = currentTime.AddMonths(-7);
            if(currentTime <= people[indexOfPeople].Birthday) age--;

            if(people[indexOfPeople].Age != age) answer = false;
            if(people[indexOfPeople].Birthday.Day != day) answer = false;
            if(people[indexOfPeople].Birthday.Month != mounthInt) answer = false;
            if(!answer) break;
            indexOfPeople++;
        }
        Assert.Equal(true!, answer);
    }

    [Theory]
    [InlineData("1 Января: Valeria Red - исполнится 41", 1)]
    [InlineData("9 Февраля: Tom Red - исполнится 15", 3)]
    [InlineData("31 Марта: Gricha Electrov - исполнится 55", 8)]
    public void LinesTest(string input, int index)
    {
        string pathToInput = @"..\..\..\..\People.json";
        string pathToOutput = @"..\..\..\..\OfficeBirthdays.txt";
        List<Person> people = Birthdays.CreateBirthdayFile(pathToInput, pathToOutput);
        using FileStream stream = new FileStream(pathToOutput, FileMode.Open);
        using StreamReader reader = new StreamReader(stream);

        string temp = "";
        for(int i = 0; i < people.Count; i++){
            if(index - 1 == i){
                temp = reader.ReadLine()!;
                break;
            }
            reader.ReadLine();
        }
        Assert.Equal(input, temp);
    }
    
}