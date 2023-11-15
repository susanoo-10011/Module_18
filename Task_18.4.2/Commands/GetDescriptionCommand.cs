using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_18._4._2.Receiver;

namespace Task_18._4._2.Commands
{
    internal class GetDescriptionCommand : Command
    {
        IReceiver _getDescription;
        string _videoUrl;
        string _outputFilePath;
        public GetDescriptionCommand(IReceiver getDescription, string videoUrl, string outputFilePath)
        {
            _getDescription = getDescription;
            _videoUrl = videoUrl;
            _outputFilePath = outputFilePath;
        }
        public async override void Run()
        {
            await _getDescription.Operation();
        }
    }
}
