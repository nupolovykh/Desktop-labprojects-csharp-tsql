# Music Store App

## Official tutorial from https://docs.avaloniaui.net/docs/tutorials/music-store-app/

A desktop app built from the official Avalonia tutorial, based on the idea of a music store. The app is highly graphical - it presents images of album covers,
and uses semi-transparent 'acrylic' blurred window backgrounds to give a very up-to-date look. It can search
the iTunes online list of albums, and select albums for a personal list.

![Screenshot](docs/screenshot.png)

## Structure

MVVM: `Models/Album`, `ViewModels/MusicStoreViewModel` + `AlbumViewModel` + `MainWindowViewModel`, `Views/MusicStoreView` + `AlbumView` + `MainWindow`. `MusicStoreViewModel` queries the [iTunes Search API](https://performance-partners.apple.com/search-api) for albums and exposes them as `AlbumViewModel`s; selecting one shows its artwork and details via `AlbumView`.

**Tech stack:** C#, .NET 8.0, Avalonia UI, MVVM
