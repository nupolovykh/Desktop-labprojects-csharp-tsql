# materials-products-inventory

WinForms app for a small materials/products catalog — `Material` (Plastic/Wood/Silver/Gold) and `Product` (Beads/Amulet/Necklace/Ring), each material×product combo priced. `AppDbContext` wipes and recreates its SQLite database with seed data on every startup (`EnsureDeleted()` + `EnsureCreated()`), so it always runs standalone with no setup.

`MainForm` is the entry point; `MaterialsDataGridForm`/`ProductsDataGridForm` are read-only grids; `ProductsCustomForm` + the custom `ProductView` control show a single product in detail. Data access behind `IDbWorker`/`DbWorker`, DI-wired in `Program.cs`.

**Tech stack:** C#, .NET 6.0, WinForms, EF Core, SQLite, DI
