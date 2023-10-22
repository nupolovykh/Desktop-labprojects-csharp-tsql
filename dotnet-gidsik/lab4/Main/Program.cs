using System.Text.Json;
using Main;

//#1 task

// #dotnet run# use different start for finding path
// string pathToInput = @"..\InputData.txt";  //@"..\..\..\..\InputData.txt"
// string pathToOutput = @"..\People.json";   //@"..\..\..\..\People.json"
// TxtToJson.PeopleTxtToJson(pathToInput, pathToOutput);

//#2 task

string pathToInput = @"..\People.json";     ////@"..\..\..\..\People.json"
string pathToOutput = @"..\OfficeBirthdays.txt";
Birthdays.CreateBirthdayFile(pathToInput, pathToOutput);
