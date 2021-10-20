# lyrics-downloader
This app is in console-mode only.
## How it works?
It simply make an API call for this link: https://api.lyrics.ovh/v1/{Artist}/{Title}
With the artist name and the title of the artist.
## How to download a lyrics
LyricsDownloader.exe {artist} {title}
## Important
If the artist or the title is splitted in multiple words, you must use a quote (e.g LyricsDownloader.exe "Some Artist" "Some Title").
In case of the lyrics are not found, an error 404 is returned.
## Issue
Sometimes when you have successfully downloaded a lyrics, the characters inside the text file is not encoded the way they should.
I think it depend of the lyrics in the song.
