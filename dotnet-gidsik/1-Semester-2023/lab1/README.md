# lab1 — Console app + geometric figures library

Two projects: `AreaConsoleApp` (console entry point) and `figures` (class library).

`figures` defines `IHaveArea` and three shapes implementing it — `Circle`, `Rectangle`, `Triangle` — each computing its own area. `AreaConsoleApp` builds a `List<IHaveArea>` of all three and sums their areas via `ListArea`. Also includes `BracketChecker`, an unrelated bracket-matching validator (`(){}[]`) using a `Stack<char>`.

**Tech stack:** C#, .NET 6.0, console
