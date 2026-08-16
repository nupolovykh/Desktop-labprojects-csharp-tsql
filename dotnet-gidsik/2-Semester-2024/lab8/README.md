# lab8 — Dropbox file explorer (MVVM)

One project: `Lab8` — WPF MVVM, Dropbox API.

`LoginView`/`LoginViewModel` handle the Dropbox OAuth flow; `ExplorerView`/`ExplorerViewModel` list and browse `FileModel` entries through an `IDropBoxGateway`, implemented by `DropBoxFullRequests`/`DropBoxSnapshot` against the real Dropbox API. Custom `FolderControl`, value converters (`BackgroundColorConverter`, `BorderColorConverter`, `SubtractConverter`) for the file-tree UI, navigation via `IMVVMNavigationService`, commands via `DelegateCommand`.

Needs a Dropbox app key/secret in `appsettings.json` to actually connect. The values currently committed there are redacted placeholders (`***REMOVED-...***`) — a real key/secret pair was originally committed and was scrubbed from git history; drop in your own to run this. See `curl.txt` for example API calls (also redacted).

![Screenshot](docs/screenshot.png)

*(the login/auth-key screen — the app needs a Dropbox key to get past it, see above)*

**Tech stack:** C#, .NET 6.0, WPF, MVVM, Dropbox API
