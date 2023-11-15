using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_18._4._2.Receiver;

namespace Task_18._4._2.Commands
{
    internal class DownloadVideoCommand : Command
    {
        IReceiver _downloadVideo;
        string _videoUrl;
        string _outputFilePath;
        public DownloadVideoCommand(IReceiver downloadVideo, string videoUrl, string outputFilePath) 
        {
            _downloadVideo = downloadVideo;
            _videoUrl = videoUrl;
            _outputFilePath = outputFilePath;
        }
        public async override void Run()
        {
            await _downloadVideo.Operation();
        }
    }
}
