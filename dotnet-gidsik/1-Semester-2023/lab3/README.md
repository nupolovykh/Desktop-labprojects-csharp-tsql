# lab3 — Generic locking interface over a small banking/diary domain

Two projects: `LockableEntities` (class library) and `ConsoleApp` (console entry).

`LockableEntities` defines a generic `ILocker<T>` interface (`LockEdit`/`LockRead`/`UnLock`) implemented by both `BankAccount` and `PersonalDiary`. `Person` owns an `Account`, which holds a collection of each. `ConsoleApp` demonstrates locking a `BankAccount`'s balance mid-edit and catching the resulting `ValueIsLockedException` in a try/catch/finally block.

**Tech stack:** C#, .NET 6.0, console
