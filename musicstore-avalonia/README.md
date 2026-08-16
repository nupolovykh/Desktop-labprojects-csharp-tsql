# Music Store App

## Official tutorial of from https://docs.avaloniaui.net/docs/tutorials/music-store-app/

In this tutorial i will repeat a desktop app based on the idea of a music store. The app is highly graphical - it presents images of album covers, 
and uses semi-transparent 'acrylic' blurred window backgrounds to give a very up-to-date look. By the end of the tutorial, i will be able search 
the iTunes online list of albums, and select albums for my own list.

![Screenshot](docs/screenshot.png)

*(this checkout's default/empty state — the library is genuinely empty until you search and buy an album, there's no persistence between launches)*

## Structure

MVVM: `Models/Album`, `ViewModels/MusicStoreViewModel` + `AlbumViewModel` + `MainWindowViewModel`, `Views/MusicStoreView` + `AlbumView` + `MainWindow`. `MusicStoreViewModel` queries the [iTunes Search API](https://performance-partners.apple.com/search-api) for albums and exposes them as `AlbumViewModel`s; selecting one shows its artwork and details via `AlbumView`.

**Tech stack:** C#, .NET 8.0, Avalonia UI, MVVM
