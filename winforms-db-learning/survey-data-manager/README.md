# survey-data-manager

WinForms app for geodetic survey data — `Project`, `Terrain`, `Picket`, `Measurement`, `Equipment`, `Operator`, `Customer`, `Datum`, `User`, `SurveyLine` entities, wired up with `Microsoft.Extensions.DependencyInjection` and EF Core against SQLite (`app.db`).

`Entrance` is the login screen, `RecordsForm` is the main CRUD grid, `Analytics` is a read-only summary view. `Bootstrap/DatabaseInspector` checks the DB is reachable on startup and exits if not; `Bootstrap/FakeDictionaryBuilder`/`RealDictionaryBuilder` seed each entity's in-memory collections. Data access behind `IDbWorker`, with `FakeDbWorker`/`RealDbWorker` swappable via DI, same pattern as `dotnet-gidsik/2-Semester-2024/lab2`.

![Screenshot](docs/screenshot.png)

*(the `Entrance` login screen)*

![Screenshot](docs/screenshot-records.png)

*(`RecordsForm`, logged in as `admin` — the main CRUD grid)*

![Screenshot](docs/screenshot-analytics.png)

*(`Analytics`, logged in as `admin` — the read-only summary chart)*

**Tech stack:** C#, .NET 6.0, WinForms, EF Core, SQLite, DI
