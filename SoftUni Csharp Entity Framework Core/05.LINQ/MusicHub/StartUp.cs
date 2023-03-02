namespace MusicHub;

using System;
using System.Text;

using Data;

public class StartUp
{
    public static void Main()
    {
        MusicHubDbContext context =
            new MusicHubDbContext();

        var result = ExportAlbumsInfo(context, 9);

        Console.WriteLine(result);
    }

    public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
    {
        var albums = context.Albums
            .Where(a => a.ProducerId == producerId)
            .Select(a => new
        {
            a.Name,
            ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
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
            sb.AppendLine($"-AlbumName: {album.Name}");
            sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
            sb.AppendLine($"-ProducerName: {album.ProducerName}");
            sb.AppendLine("-Songs:");

            int count = 1;

            album.Songs.ForEach(song =>
            {
                sb.AppendLine($"---#{count}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Price: {song.Price:f2}");
                sb.AppendLine($"---Writer: {song.Name}");

                count++;
            });

            sb.AppendLine($"-AlbumPrice: {album.Price:f2}");
        });

        return sb.ToString().TrimEnd();
    }

    public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
    {
        throw new NotImplementedException();
    }
}