using AngleSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using YoutubeExplode;
using YoutubeExplode.Converter;
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
        public async Task Operation()
        {
            Console.WriteLine("Ввведите путь сохранения видеоролика");
            string path = Console.ReadLine();
            Console.WriteLine("Скачивание начато");

            var youtube = new YoutubeClient();
            var video = await youtube.Videos.GetAsync(_url);
            var streamManifest = await youtube.Videos.Streams.GetManifestAsync(video.Id);
            var streamInfo = streamManifest.GetMuxedStreams().GetWithHighestVideoQuality();

            if (streamInfo != null)
            {
                var fileName = $"{video.Title}.{streamInfo.Container}";
                var filePath = Path.Combine(path, fileName);

                await youtube.Videos.Streams.DownloadAsync(streamInfo, filePath);
            }

            Console.WriteLine("Скачивание завершено!");
        }

        
    }
}
