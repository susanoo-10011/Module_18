using Task_18._4._2;
using Task_18._4._2.Receiver;
using Task_18._4._2.Commands;
using AngleSharp;
using YoutubeExplode.Videos;
using System.Diagnostics.SymbolStore;

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

        await UserChoice(videoUrl);
    }

    public async static Task UserChoice(string videoUrl) // описание видео или скачивание в зависимости от выбора пользователя
    {
        Sender sender = new Sender();

        DescriptionActions();
        string userChoice = "";

        while (true)
        {
            Console.WriteLine("Ваше действие: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    IReceiver getDescription = new GetDescriptionReceiver(videoUrl);
                    sender.SetCommand(new GetDescriptionCommand(getDescription));
                    await sender.Run();
                    break;
                case "2":
                    IReceiver download = new DownloadVideReceiver(videoUrl);
                    sender.SetCommand(new DownloadVideoCommand(download));
                    await sender.Run();
                    break;

                default:
                    Console.WriteLine("Такого действия нет, повторите попытку!\n");
                    continue;
            }

            break;
        }
    }

    public static void DescriptionActions() //описание меню действий
    {
        Console.WriteLine("\nВыберите действие: ");
        Console.WriteLine("1 - запросить информацию о видео.");
        Console.WriteLine("2 - скачать видео.\n");
    }

    public static bool ValidateVideo(string videoUrl) //проверка на корректность ссылки
    {
        try
        {
            string videoId = VideoId.Parse(videoUrl);
            Console.WriteLine($"Найдено видео: {videoId}");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Видео с текущей ссылкой не найдено \"{videoUrl}\". Exception Message: {ex.Message}");
            return false;
        }
    }
}