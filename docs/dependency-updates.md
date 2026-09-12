# Dependency updates

Updates land on `deps` without a human and reach `main` through one reviewed
pull request. Built for a repository nobody is watching.

```
Dependabot ─▶ PR ─▶ CI ──green on this exact commit──▶ squash-merged into deps
                                                              │
                                          promotion PR (CI runs on the result)
                                                              │
                                                       ◀ human merges ▶
                                                              ▼
                                                             main
                                                              │
                                        deps re-cut from main ┘
```

Both automation workflows are byte for byte the ones running in
`QA-web-labprojects-python`, `Smart-Plan-Mortgage-Calculator`,
`Marketplace-coursework-wpf-mvvm` and `MyDuoCards-coursework-aspnet-mvc`. The
first of those carries the design rationale in its own
`docs/dependency-updates.md` and the porting checklist in
`docs/porting-the-dependency-pipeline.md`. Only what is specific here is below.

## Branch contract

`main` is written by humans. `deps` is bot-only and **disposable** — it is reset
from `main` after every promotion, never merged into. That works because every
commit on it is a bot commit and every bot commit is regenerable: reset the
branch and Dependabot raises the same bumps again. The guard in
`deps-promote.yml` keeps the assumption true — one non-bot commit on `deps` and
the workflow resets nothing and turns the run red.

`deps` was cut from `security-features-main`, which held one Dependabot merge
with no route into `main`. `security-features-main` is now dead.

## Three things this repository needed that the others did not

**1. The `paths:` filter excluded the automation workflows.** `ci.yml` only ran
when a change touched the lab directories or `.github/workflows/ci.yml`. A
Dependabot pull request bumping an action inside `dependabot-auto-merge.yml` or
`deps-promote.yml` therefore produced **no CI run at all** — and the gate reads
CI's conclusion, so it would have waited forever and the sweep would have gone
red at fourteen days for a pull request that could never turn green. The filter
now matches `.github/workflows/**`.

**2. `publish-screenshots` commits back to the branch it ran on.** Under a human
name, to `${{ github.head_ref || github.ref_name }}`. On `deps` that is exactly
the commit the promotion's guard refuses to reset. The job is skipped when the
target is `deps` or the pull request is Dependabot's; everywhere else it behaves
as before. Loosening the guard instead would have removed the only thing
protecting the branch contract.

**3. The EntityFrameworkCore packages are grouped and capped at 7.x.** Nine
projects pin `Microsoft.EntityFrameworkCore` alongside `Sqlite`, `SqlServer` or
`Design` at one version, and those carry ranges on each other: bumping one alone
leaves the rest below what it demands and the restore breaks — every pull
request in the queue the same way. That was measured in
`Marketplace-coursework-wpf-mvvm`, which has the identical shape.

The cap is a target-framework fact. Every project holding EF Core here targets
`net6.0`, most of them `net6.0-windows`, and pins 6.x. EF Core 7 still ships
`net6.0` assets; **EF Core 8 requires `net8.0`** and cannot restore on any of
them however it is grouped. So `6 → 7` stays available and 8 and above are held
back. `Microsoft.Extensions` is deliberately not capped — its 8.x and 9.x still
ship `netstandard2.0` and restore fine on `net6.0`.

Remove the cap when the projects are retargeted, not before.

## Repository settings this depends on

1. **Secrets and variables → Actions**: `DEPS_PAT`. Without it both automation
   workflows fail immediately with 401.
2. **Actions → General → Workflow permissions**: *Allow GitHub Actions to create
   and approve pull requests* — ticked.
3. **General → Pull Requests**: squash merging enabled.
4. **Advanced Security → Dependabot alerts**: enabled.
5. **Branch protection on `main`**: require a pull request, and tick *Do not
   allow bypassing the above settings*.

## Running it by hand

```
Actions → Dependency promotion → Run workflow
Actions → Dependency auto-merge → Run workflow
```
