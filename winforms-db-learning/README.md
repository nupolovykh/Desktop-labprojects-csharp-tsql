# WinForms + Database Learning

Four independent WinForms/Entity Framework exercises — not a numbered lab sequence, each folder is a standalone app with its own domain, database, and DB provider. Two run standalone out of the box (self-contained SQLite, no setup needed); two need a real SQL Server instance and won't run as-is outside the original author's machine.

### [`survey-data-manager/`](survey-data-manager) — runs standalone (SQLite)
WinForms app for geodetic survey data — `Project`, `Terrain`, `Picket`, `Measurement`, `Equipment`, `Operator`, `Customer`, `Datum`, `User`, `SurveyLine` entities, wired up with `Microsoft.Extensions.DependencyInjection` and EF Core against a self-contained SQLite database (`app.db`). `Entrance` is the login screen, `RecordsForm` is the main CRUD grid, `Analytics` is a read-only summary view. Data access sits behind `IDbWorker`, with `FakeDbWorker`/`RealDbWorker` swappable via DI.

### [`materials-products-inventory/`](materials-products-inventory) — runs standalone (SQLite)
WinForms app for a small materials/products catalog — `Material` (Plastic/Wood/Silver/Gold) x `Product` (Beads/Amulet/Necklace/Ring) combos, each priced. `AppDbContext` wipes and recreates its SQLite database with seed data on every startup (`EnsureDeleted()` + `EnsureCreated()`), so it always runs standalone with no setup. `MainForm` is the entry point; `MaterialsDataGridForm`/`ProductsDataGridForm` are read-only grids; `ProductsCustomForm` + the custom `ProductView` control show a single product in detail.

### [`code-first-existing-db-sample/`](code-first-existing-db-sample) — needs SQL Server
The classic Microsoft EF Code-First-to-an-existing-database tutorial: `Blog`/`Post` entities, `BlogContext : DbContext` against SQL Server (console app — creates a blog, saves it, lists all blogs). `queries/CreateBlogsAndPosts.sql` has the matching `CREATE TABLE` script. Not runnable without a real SQL Server instance reachable at the hardcoded connection string in `BlogContext.OnConfiguring`.

### [`sql-table-browser/`](sql-table-browser) — needs SQL Server, legacy .NET Framework
First-semester WinForms + database exercise. `Entry` picks a preset ("home database" / "collegue database") and connects via `System.Data.SqlClient` with integrated security; `Main` lists every table in the connected database in a combo box and shows the selected table's rows in a `DataGridView`. The connection presets are hardcoded to the original author's own machine (`Server=MIZANTROP`), and it's the one project in this repo still targeting classic .NET Framework 4.8 rather than modern .NET (no `.sln`, built directly from the `.csproj` via MSBuild).

**Tech stack:** C#, WinForms, Entity Framework Core / EF6, SQLite, SQL Server, DI
