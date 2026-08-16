# lab4 — People serialization + birthday reminders

Two projects: `BirthdayApp` (console entry) and `UnitTests` (xUnit).

`TxtToJson` parses `InputData.txt` (plain-text people records) into `Person` objects and serializes them to `People.json`. `PersonBinarySerializer` round-trips the same data to/from a hand-rolled binary format (`People.bin`). `Birthdays.CreateBirthdayFile` computes upcoming birthdays/ages from a people list and writes `OfficeBirthdays.txt`.

No screenshot here — the active `Program.cs` path only reads/writes files (`People.json` → `People.bin`), it doesn't print anything to the console.

**Tech stack:** C#, .NET 6.0, xUnit, `System.Text.Json`
