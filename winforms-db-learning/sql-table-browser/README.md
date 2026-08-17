# sql-table-browser

First-semester WinForms + database exercise. `Entry` picks a preset ("home database" / "collegue database") and connects via `System.Data.SqlClient` with integrated security; `Main` lists every table in the connected database in a combo box and shows the selected table's rows in a `DataGridView`.

The connection presets are hardcoded to the original author's own machine (`Server=MIZANTROP`) — this only runs as-is against a local SQL Server instance with those exact database names.

The one project in this repo still targeting classic .NET Framework 4.8 rather than modern .NET — no `.sln`, built directly from the `.csproj` via MSBuild.

**Tech stack:** C#, .NET Framework 4.8, WinForms, `System.Data.SqlClient`
