﻿using System;
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
       
        public DownloadVideoCommand(IReceiver downloadVideo) 
        {
            _downloadVideo = downloadVideo;
            
        }
        public async override Task Run()
        {
            await _downloadVideo.Operation();
        }
    }
}
