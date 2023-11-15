using Task_18._4._2;
using Task_18._4._2.Receiver;
using Task_18._4._2.Commands;

class Program
{
    static void  Main()
    {
        var videoUrl = "https://youtu.be/O_Bwo2X4glo?si=SYgRTpFrYgShLy57";
        var puth = "C:\\Users\\Egor\\Desktop\\videooo";

        Sender sender = new Sender();

        IReceiver getDescription = new GetDescriptionReceiver(videoUrl);
        sender.SetCommand(new GetDescriptionCommand(getDescription, videoUrl, puth));
        sender.Run();

        Console.WriteLine();

        IReceiver download = new DownloadVideReceiver(videoUrl);
        sender.SetCommand(new DownloadVideoCommand(download, videoUrl, puth));
        sender.Run();

    }
}