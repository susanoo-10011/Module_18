using Task_18._4._2;
using Task_18._4._2.Receiver;
using Task_18._4._2.Commands;

class Program
{
    static async Task  Main()
    {
        Console.Write("Вставьте ссылку на видео: ");
        var videoUrl = Console.ReadLine();

        Sender sender = new Sender();

        IReceiver getDescription = new GetDescriptionReceiver(videoUrl);
        sender.SetCommand(new GetDescriptionCommand(getDescription));
        await sender.Run();

        Console.WriteLine();

        IReceiver download = new DownloadVideReceiver(videoUrl);
         sender.SetCommand(new DownloadVideoCommand(download));
        await sender.Run();

    }
}