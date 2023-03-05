namespace MusicHub;

using System;
using System.Text;
using System.Globalization;
using Microsoft.EntityFrameworkCore;

using Data;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        var result = ExportSongsAboveDuration(context, 4);

        Console.WriteLine(result);
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albums = context.Albums
            .Where(a => a.ProducerId == producerId)
            .Include(a => a.Songs)
            .Select(a => new
        {
            a.Name,
            ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture),
            ProducerName = a.Producer!.Name,
            a.Price,
            Songs = a.Songs
                .Select(s => new
                {
                    s.Name, 
                    s.Price, 
                    WriterName = s.Writer.Name
                })
                .OrderByDescending(s => s.Name)
                .ThenBy(s => s.WriterName).ToList()
        })
            .ToList().OrderByDescending(a => a.Price).ToList();

        var sb = new StringBuilder();

        albums.ForEach(album =>
        {
            sb.AppendLine($"-AlbumName: {album.Name}")
                .AppendLine($"-ReleaseDate: {album.ReleaseDate}")
                 .AppendLine($"-ProducerName: {album.ProducerName}")
                  .AppendLine("-Songs:");

            int count = 1;

            album.Songs.ForEach(song =>
            {
                sb.AppendLine($"---#{count}")
                    .AppendLine($"---SongName: {song.Name}")
                     .AppendLine($"---Price: {song.Price:f2}")
                      .AppendLine($"---Writer: {song.WriterName}");

                count++;
            });

            sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
        });

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        var songs = context.Songs
            .ToList()
            .Where(s => s.Duration.TotalSeconds > duration)
            .Select(s => new
            {
                s.Name,
                Performers = s.SongPerformers.Select(sp => $"{sp.Performer.FirstName} {sp.Performer.LastName}").OrderBy(p => p).ToList(),
                WriterName = s.Writer.Name,
                AlbumProducer = s.Album!.Producer!.Name,
                Duration = s.Duration.ToString("c")
            }).OrderBy(s => s.Name).ThenBy(s => s.WriterName).ToList();

        var sb = new StringBuilder();

        int count = 1;

        songs.ForEach(song =>
        {
            sb.AppendLine($"-Song #{count}")
                .AppendLine($"---SongName: {song.Name}")
                  .AppendLine($"---Writer: {song.WriterName}");

            song.Performers.ForEach(name =>
            { 
                sb.AppendLine($"---Performer: {name}");
            });

            sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}")
               .AppendLine($"---Duration: {song.Duration}");

            count++;
        });

        return sb.ToString().TrimEnd();
    }
}