using YoutubeExplode;

namespace Task_18._4._2.Receiver
{
    internal class GetDescriptionReceiver : IReceiver
    {
        string _url;
        public GetDescriptionReceiver(string url) 
        {
            _url = url;
        }
        public async Task Operation()
        {
            YoutubeClient youtube = new YoutubeClient();

            Console.WriteLine("\nОписание видео:\n");
            var video = youtube.Videos.GetAsync(_url).Result;
            var title = video.Title;
            var author = video.Author;
            var duration = video.Duration;

            Console.WriteLine($"Заголовок: {title}\nАвтор: {author}\nПродолжительность видео: {duration}");
        }
    }
}
