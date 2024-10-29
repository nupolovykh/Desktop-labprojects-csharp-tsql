using System.Text.Json;
using System.Data;
using System.Transactions;
using Main;
using Microsoft.VisualStudio.TestPlatform.Common.DataCollection;

namespace UnitTests;

public class UnitTestThird
{
    [Fact]
    public void TestSerialize(){
        string pathInputJson = @"..\..\..\..\People.json";
        string pathInputBin = @"..\..\..\..\People.bin";
        bool answer = true;

        using StreamReader readerJson = new StreamReader(pathInputJson);
        string Alljson = readerJson.ReadToEnd();
        List<Person> peopleDefault = JsonSerializer.Deserialize<List<Person>>(Alljson)!;

        List<Person> peopleBin = new List<Person>();
        Person ?person = null;

        using (BinaryReader reader = new BinaryReader(File.OpenRead(pathInputBin)))
        {
            reader.ReadChar();
            while(reader.PeekChar() != ']'){
                string currentString = reader.ReadString();
                if(currentString == "NewPerson!!!"){
                    if(person != null) peopleBin.Add(person);
                    person = new Person();
                    continue;
                }
                else if(currentString == "Id:") person!.Id = Guid.Parse(reader.ReadString());
                else if(currentString == "Name:") person!.Name = reader.ReadString();
                else if(currentString == "Surname:") person!.SurName = reader.ReadString();
                else if(currentString == "Age:") person!.Age = reader.ReadInt32();
                else if(currentString == "Birthday:"){
                    // {
                    //     int year, month, day, hour, minute, second, millisecond;
                    //     DateTimeKind kind;
                    //     year = reader.ReadInt32();
                    //     month = reader.ReadInt32();
                    //     day = reader.ReadInt32();
                    //     hour = reader.ReadInt32();
                    //     minute = reader.ReadInt32();
                    //     second = reader.ReadInt32();
                    //     millisecond = reader.ReadInt32();
                    //     kind = (DateTimeKind)reader.ReadInt32();
                    //     DateTime currentBirthday = new DateTime(year, month, day, hour, minute, second, millisecond, kind);
                    //     person!.Birthday = currentBirthday;
                    // }
                    person!.Birthday = DateTime.Parse(reader.ReadString()); // :)
                }
                else if(currentString == "IsAdmin:") person!.IsAdmin = reader.ReadBoolean();
            }
            reader.ReadChar();
            peopleBin.Add(person!);
        }

        

        for(int i = 0; i < peopleDefault.Count; i++){
            if(peopleDefault[i].Id != peopleBin[i].Id)
                answer = false;
            else if(peopleDefault[i].Name != peopleBin[i].Name)
                answer = false;
            else if(peopleDefault[i].SurName != peopleBin[i].SurName)
                answer = false;
            else if(peopleDefault[i].Age != peopleBin[i].Age)
                answer = false;
            else if(peopleDefault[i].Birthday.ToString() != peopleBin[i].Birthday.ToString())
                answer = false;
            else if(peopleDefault[i].IsAdmin != peopleBin[i].IsAdmin)
                answer = false;
            if(!answer) break;
        }
        Assert.Equal(true!, answer);
    }

    [Fact]
    public void TestDeserialize(){
        string pathInput = @"..\..\..\..\People.json";
        bool answer = true;

        using StreamReader reader = new StreamReader(pathInput);
        string Alljson = reader.ReadToEnd();
        List<Person> peopleDefault = JsonSerializer.Deserialize<List<Person>>(Alljson)!;

        List<Person> peopleTest = PersonBinarySerializer.Deserialize(pathInput);

        for(int i = 0; i < peopleDefault.Count; i++){
            if(peopleDefault[i].Id != peopleTest[i].Id) answer = false;
            else if(peopleDefault[i].Name != peopleTest[i].Name) answer = false;
            else if(peopleDefault[i].SurName != peopleTest[i].SurName) answer = false;
            else if(peopleDefault[i].Age != peopleTest[i].Age) answer = false;
            else if(peopleDefault[i].Birthday != peopleTest[i].Birthday) answer = false;
            else if(peopleDefault[i].IsAdmin != peopleTest[i].IsAdmin) answer = false;
            if(!answer) break;
        }
        Assert.Equal(true!, answer);
    }
}
