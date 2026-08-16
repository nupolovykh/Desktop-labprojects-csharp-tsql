# C# / T-SQL Desktop Development

[![CI](https://github.com/nupolovykh/Desktop-labprojects-csharp-tsql/actions/workflows/ci.yml/badge.svg)](https://github.com/nupolovykh/Desktop-labprojects-csharp-tsql/actions/workflows/ci.yml)

Merged repository covering C# desktop development work: an Avalonia MVVM tutorial app, .NET semester coursework, and WinForms/Entity Framework database learning exercises. Each sub-project keeps its own git history (see the merge commits in the root log for where each history was grafted in).

## Sub-projects

### [`musicstore-avalonia/`](musicstore-avalonia)

A desktop music-store app built from the [official Avalonia tutorial](https://docs.avaloniaui.net/docs/tutorials/music-store-app/): searches the iTunes album catalog and displays results with acrylic blurred backgrounds. MVVM architecture (`Models/`, `ViewModels/`, `Views/`).

**Tech stack:** C#, Avalonia UI, MVVM

### [`dotnet-gidsik/`](dotnet-gidsik)
> ⏹️ **Archived Coursework** — university .NET labs

Two semesters of C# .NET coursework:
- [`1-Semester-2023/`](dotnet-gidsik/1-Semester-2023) — 6 console-app labs (OOP, generics, serialization, design patterns, threading)
- [`2-Semester-2024/`](dotnet-gidsik/2-Semester-2024) — 8 WinForms/WPF labs (custom controls, EF Core, DI, MVVM)

See each folder's README for the lab-by-lab index.

**Tech stack:** C#, .NET 6.0, WinForms, WPF, EF Core, xUnit

### [`winforms-db-learning/survey-data-manager/`](winforms-db-learning/survey-data-manager)
> ⏹️ **Archived Coursework** — WinForms + database learning

WinForms app for geodetic survey data — `Project`, `Terrain`, `Picket`, `Measurement`, `Equipment`, `Operator`, `Customer`, `Datum`, `User`, `SurveyLine` entities, wired up with DI and EF Core against SQLite. `Entrance` is the login screen, `RecordsForm` is the main CRUD grid, `Analytics` is a read-only summary view.

**Tech stack:** C#, WinForms, EF Core, SQLite, DI

## CI

`.github/workflows/ci.yml` builds every project on every push/PR: portable (net6.0/net8.0, non-Windows) projects on `ubuntu-latest`, WinForms/WPF (`net6.0-windows`) projects on `windows-latest`, and the one legacy .NET Framework 4.8 project (`sql-table-browser`) via classic MSBuild, non-blocking.
