# code-first-existing-db-sample

The classic Microsoft EF Code-First-to-an-existing-database tutorial: `Blog`/`Post` entities, `BlogContext : DbContext` against SQL Server. Console app — creates a blog, saves it, lists all blogs. `queries/CreateBlogsAndPosts.sql` has the matching `CREATE TABLE` script for the two tables.

Needs a real SQL Server instance (`Server=.\;Database=BlogDb;Trusted_Connection=True;...` in `BlogContext.OnConfiguring`) — not runnable without one.

**Tech stack:** C#, .NET 6.0, console, EF Core, SQL Server
