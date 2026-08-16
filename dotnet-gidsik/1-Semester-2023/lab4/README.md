# lab4 — People serialization + birthday reminders

Two projects: `BirthdayApp` (console entry) and `UnitTests` (xUnit).

`TxtToJson` parses `InputData.txt` (plain-text people records) into `Person` objects and serializes them to `People.json`. `PersonBinarySerializer` round-trips the same data to/from a hand-rolled binary format (`People.bin`). `Birthdays.CreateBirthdayFile` computes upcoming birthdays/ages from a people list and writes `OfficeBirthdays.txt`.

**Tech stack:** C#, .NET 6.0, xUnit, `System.Text.Json`
