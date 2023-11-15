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
        
        public GetDescriptionCommand(IReceiver getDescription)
        {
            _getDescription = getDescription;
            
        }
        public async override Task Run()
        {
            await _getDescription.Operation();
        }
    }
}
