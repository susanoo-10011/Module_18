using Task_18._4._2;
using Task_18._4._2.Receiver;
using Task_18._4._2.Commands;
using AngleSharp;
using YoutubeExplode.Videos;

class Program
{
    static async Task Main()
    {

        Console.Write("Вставьте ссылку на видео: ");
        var videoUrl = Console.ReadLine();

        while (!ValidateVideo(videoUrl))
        {
            Console.Write("\nСсылка недействительна, повторите попытку: ");
            videoUrl = Console.ReadLine();
        } 

        Sender sender = new Sender();

        IReceiver getDescription = new GetDescriptionReceiver(videoUrl);
        sender.SetCommand(new GetDescriptionCommand(getDescription));
        await sender.Run();

        Console.WriteLine();

        IReceiver download = new DownloadVideReceiver(videoUrl);
        sender.SetCommand(new DownloadVideoCommand(download));
        await sender.Run();
    }

    public static bool ValidateVideo(string videoUrl)
    {
        try
        {
            string videoId = VideoId.Parse(videoUrl);
            Console.WriteLine($"Found video: {videoId}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Видео с текущей ссылкой не найдено \"{videoUrl}\". Exception Message: {ex.Message}");
            return false;
        }
    }
}