using System.Text.Json;

namespace UnitTests;
using Main;

public class UnitTestFirst
{
    [Fact]
    public void TestTxtToJson()
    {
        string pathToInput = @"..\..\..\..\InputData.txt";
        string pathToOutput = @"..\..\..\..\People.json";   

        List<Person> txtPeople = TxtToJson.PeopleTxtToJson(pathToInput, pathToOutput);
        string jsonString = File.ReadAllText(pathToOutput);
        List<Person> jsonPeople = JsonSerializer.Deserialize<List<Person>>(jsonString)!;
        
        for(int i = 0; i < jsonPeople.Count; i++){
            if(txtPeople[i].Id != jsonPeople[i].Id)
                Assert.Equal(true, false);
                break;
        }
        Assert.Equal(true, true);
    } 
    
}