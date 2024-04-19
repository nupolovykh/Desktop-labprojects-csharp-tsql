using System.Text.Json;
using Main;

//#1 task

// #dotnet run# use different start for finding path
//@"..\..\..\..\InputData.txt"          //@"..\People.json"
//@"..\..\..\..\People.json"            //@"..\People.json"
//@"..\..\..\..\OfficeBirthdays.txt"    //@"..\OfficeBirthdays.txt"
//@"..\..\..\..\People.bin"             //@"..\People.bin"


// string pathToInput = @"..\InputData.txt";
// string pathToOutput = @"..\People.json";
// TxtToJson.PeopleTxtToJson(pathToInput, pathToOutput);

//#2 task

// string pathToInput = @"..\People.json";
// string pathToOutput = @"..\OfficeBirthdays.txt";
// Birthdays.CreateBirthdayFile(pathToInput, pathToOutput);

//#3 task

//string pathToInput = @"..\People.json";
//string pathToOutput = @"..\People.bin";
string pathToInput = @"..\..\..\..\People.json";
string pathToOutput = @"..\..\..\..\People.bin";
List<Person> people = PersonBinarySerializer.Deserialize(pathToInput);
PersonBinarySerializer.Serialize(pathToOutput, people);
