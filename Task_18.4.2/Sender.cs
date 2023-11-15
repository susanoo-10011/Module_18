﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_18._4._2.Commands;

namespace Task_18._4._2
{
    internal class Sender
    {
        Command _command;
        public async void SetCommand(Command command)
        {
            _command = command;
        }

        public async Task Run()
        {
            await _command.Run();
        }
        
    }
}
