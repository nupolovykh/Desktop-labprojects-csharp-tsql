namespace Main
{
    public static class PersonBinarySerializer
    {
        public static List<Person> Deserialize(string input)
        {
            List<Person> people = new List<Person>();
            using (TextReader reader = File.OpenText(input))
            {
                bool isReadingPerson = false;
                string? currentPropertyName = null;
                string? currentPropertyValue = null;

                while (reader.Peek() >= 0)
                {
                    string line = reader.ReadLine()!.Trim();

                    if (line.StartsWith("{") && !isReadingPerson)
                    {
                        isReadingPerson = true;
                        Person person = new Person();
                        people.Add(person);
                        continue;
                    }

                    if (isReadingPerson)
                    {
                        if (line.StartsWith("}"))
                        {
                            isReadingPerson = false;
                            currentPropertyName = null;
                            currentPropertyValue = null;
                        }
                        else
                        {
                            if (line.Contains(":"))
                            {
                                string[] parts = line.Split(':', 2);
                                currentPropertyName = parts[0].Trim().Trim('"'); // Remove leading/trailing whitespace and double quote
                                currentPropertyValue = parts[1].Trim().TrimEnd(',').Trim('"'); // Remove leading/trailing whitespace, comma, and double quote

                                // Assign the property value to the current Person object
                                if (currentPropertyName == "Id") people[people.Count - 1].Id = Guid.Parse(currentPropertyValue!);
                                else if (currentPropertyName == "Name") people[people.Count - 1].Name = currentPropertyValue;
                                else if (currentPropertyName == "SurName") people[people.Count - 1].SurName = currentPropertyValue;
                                else if (currentPropertyName == "Age") people[people.Count - 1].Age = int.Parse(currentPropertyValue);
                                else if (currentPropertyName == "Birthday") people[people.Count - 1].Birthday = DateTime.Parse(currentPropertyValue);
                                else if (currentPropertyName == "IsAdmin") people[people.Count - 1].IsAdmin = bool.Parse(currentPropertyValue);
                            }
                        }
                    }
                }
            }
            return people;
        }

        public static void Serialize(string path, List<Person> people)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
            {
                writer.Write('[');
                foreach (var person in people)
                {
                    writer.Write("NewPerson!!!");
                    writer.Write("Id:");
                    writer.Write(person.Id.ToString());
                    writer.Write("Name:");
                    writer.Write(person.Name!);
                    writer.Write("Surname:");
                    writer.Write(person.SurName!);
                    writer.Write("Birthday:");
                    writer.Write(person.Birthday.ToString());
                    writer.Write("IsAdmin:");
                    writer.Write(person.IsAdmin!);
                }
                writer.Write(']');
            }


            // using (TextWriter writer = new StreamWriter(@"..\tempt.txt"))
            // {
            //     writer.WriteLine('[');
            //     foreach (var person in people)
            //     {
            //         writer.WriteLine("{");
            //         writer.WriteLine(person.Id.ToString());
            //         writer.WriteLine(person.Name!);
            //         writer.WriteLine(person.SurName!);
            //         writer.WriteLine(person.Birthday.ToString());
            //         writer.WriteLine(person.IsAdmin!);
            //         writer.WriteLine("}");
            //     }
            //     writer.WriteLine(']');
            // }

        }
    }
}