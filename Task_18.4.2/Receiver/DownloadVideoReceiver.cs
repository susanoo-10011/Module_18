
using YoutubeExplode;
using YoutubeExplode.Videos;
using YoutubeExplode.Videos.Streams;

namespace Task_18._4._2.Receiver
{
    internal class DownloadVideReceiver : IReceiver
    {
        string _url;
        public DownloadVideReceiver(string url)
        {
            _url = url;
        }

        public static string CheckingTheDirectory() // проверка существования директории
        {
            Console.WriteLine("Введите путь сохранения видеоролика:");
            string path = Console.ReadLine();

            while(!Directory.Exists(path))
            {
                Console.WriteLine("\nУказанной директории не существует. Повторите попытку:  ");
                path = Console.ReadLine();
            }

            return path;
        }
        public async Task Operation()
        {
            try
            {
                var path = CheckingTheDirectory();
                Console.WriteLine("\nСкачивание начато\n");

                var youtube = new YoutubeClient();
                var video = await youtube.Videos.GetAsync(_url);
                var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
                var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

                if (streamInfo != null)
                {
                    var invalidChars = Path.GetInvalidFileNameChars();

                    var fileName = new string(video.Title.Select(c => invalidChars.Contains(c) ? '_' : c).ToArray()); //заменяет недопустимые символы в названии файла на '_'. 
                    var fileExtension = streamInfo.Container;

                    fileName = $"{fileName}.{streamInfo.Container}";
                    var filePath = Path.Combine(path, fileName);

                    await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);

                    Console.WriteLine($"Видео сохранено по пути: {filePath}");
                }
                else
                {
                    Console.WriteLine("\nНе удалось получить информацию о потоке видео.");
                }

                Console.WriteLine("\nСкачивание завершено");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка: {ex.Message}");
            }
        }
    }
}
