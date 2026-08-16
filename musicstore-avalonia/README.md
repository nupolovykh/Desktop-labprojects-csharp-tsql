# Music Store App

## Official tutorial of from https://docs.avaloniaui.net/docs/tutorials/music-store-app/

In this tutorial i will repeat a desktop app based on the idea of a music store. The app is highly graphical - it presents images of album covers, 
and uses semi-transparent 'acrylic' blurred window backgrounds to give a very up-to-date look. By the end of the tutorial, i will be able search 
the iTunes online list of albums, and select albums for my own list.

<p align="center">
  <img width="900" height="471" src="https://docs.avaloniaui.net/assets/images/image-20210310184538120-6cb6d8ac692816f0943e3f86b08d252a.png">
</p>

*(screenshot from the official tutorial, not this checkout)*

## Structure

MVVM: `Models/Album`, `ViewModels/MusicStoreViewModel` + `AlbumViewModel` + `MainWindowViewModel`, `Views/MusicStoreView` + `AlbumView` + `MainWindow`. `MusicStoreViewModel` queries the [iTunes Search API](https://performance-partners.apple.com/search-api) for albums and exposes them as `AlbumViewModel`s; selecting one shows its artwork and details via `AlbumView`.

**Tech stack:** C#, .NET 8.0, Avalonia UI, MVVM
