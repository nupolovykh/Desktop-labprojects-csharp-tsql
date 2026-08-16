# lab7 — Role-based auth (full MVVM)

One project: `Lab7` — WPF MVVM, EF Core (SQLite).

`User`/`Role` entities (role-based access), password hashing via `PasswordHasher` (MD5), and an `IAuthorization` service (`Login`/`SignIn`/`LogOut`/`CurrentUser`). MVVM throughout: `LoginViewModel`/`RegisViewModel`/`UserListViewModel`/`UsersInfoViewModel` bind to `Login`/`Regis`/`UsersListView`/`UserInfoView`, navigation goes through `IViewsManager`, and commands are `DelegateCommand` (`ICommand` wrapping a delegate) rather than code-behind event handlers.

**Tech stack:** C#, .NET 6.0, WPF, MVVM, EF Core, SQLite
