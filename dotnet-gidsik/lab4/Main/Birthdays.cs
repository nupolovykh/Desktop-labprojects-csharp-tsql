using Main;
using System.Text.Json;

namespace Main
{
    public static class Birthdays
    {
        public static void CreateBirthdayFile(string input, string output){
            using StreamReader reader = new StreamReader(input);
            string jsonStr = reader.ReadToEnd();

            List<Person> people = JsonSerializer.Deserialize<List<Person>>(jsonStr)!;

            //List<Person> birthDaySort = new List<Person>(people);
            foreach (var person in people){
                DateTime fixtionBirthday = person.Birthday.AddYears(1000 - person.Birthday.Year);
                person.Birthday = fixtionBirthday;
            }
            QSort(people, 0 , people.Count - 1);

            Dictionary<int, string> mounth = new Dictionary<int, string>(){
                {1, "Января"},
                {2, "Февраля"},
                {3, "Марта"},
                {4, "Апреля"},
                {5, "Мая"},
                {6, "Июня"},
                {7, "Июля"},
                {8, "Августа"},
                {9, "Сентября"},
                {10, "Октября"},
                {11, "Ноября"},
                {12, "Декабря"}
            };
            
            using FileStream stream = new FileStream(output, FileMode.Create);
            StreamWriter writer = new StreamWriter(stream);

            DateTime currentTime = DateTime.Now;
            foreach (var person in people)
            {
                DateTime currentBirthday = person.Birthday.AddYears(currentTime.Year - person.Birthday.Year);
                person.Birthday = currentBirthday;
                //Console.WriteLine(person.Birthday);

                if(currentBirthday > currentTime){
                    writer.WriteLine($"{person.Birthday.Day} {mounth[person.Birthday.Month]}: {person.Name} {person.SurName} - исполнится {person.Age + 1}");
                }
                else writer.WriteLine($"{person.Birthday.Day} {mounth[person.Birthday.Month]}: {person.Name} {person.SurName} - исполнится {person.Age}");
            }
            writer.Dispose();
        }

        private static void QSort(List<Person> people, int start, int end)
        {
            if(start > end) return;
            int pivot = Partition(people, start, end);
            QSort(people, start, pivot - 1);
            QSort(people, pivot + 1, end);
        }

        private static int Partition(List<Person> people, int start, int end)
        {
            DateTime pivot = people[end].Birthday;
            int i = start - 1;
            for (int j = start; j <= end - 1; j++)
            {
                if (people[j].Birthday < pivot)
                {
                    i++;
                    Swap(people, i, j);
                }
            }
            Swap(people, i + 1, end);
            return (i + 1);
        }

        private static void Swap(List<Person> people, int i, int j)
        {
            Person temp  = people[j];
            people[j] = people[i];
            people[i] = temp;
        }
    }
}
