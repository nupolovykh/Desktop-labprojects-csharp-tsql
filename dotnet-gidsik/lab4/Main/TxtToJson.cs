using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Xml.Linq;
using System.Drawing;

namespace Main
{
    public static class TxtToJson
    {
        public static List<Person> PeopleTxtToJson(string inputFilePath, string outputFilePath)
        {
            using FileStream stream = new FileStream(inputFilePath, FileMode.Open);
            StreamReader reader = new StreamReader(stream);

            List<Person> people = new List<Person>();

            while (!reader.EndOfStream)
            {
                var p = new Person
                {
                    Id = Guid.Parse(reader.ReadLine()!),
                    Name = reader.ReadLine()!,
                    SurName = reader.ReadLine()!,
                    Age = int.Parse(reader.ReadLine()!),
                    Birthday = DateTime.Parse(reader.ReadLine()!),
                    IsAdmin = bool.Parse(reader.ReadLine()!),
                };
                people.Add(p);
            }

            FileStream stream1 = new FileStream(outputFilePath, FileMode.Create);
            JsonSerializer.Serialize(stream1, people, new JsonSerializerOptions() { WriteIndented = true });
            stream1.Close();

            return people;
        }
    }
}
