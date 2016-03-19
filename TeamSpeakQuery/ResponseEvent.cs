using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamSpeakQueryAPI.Command;

namespace TeamSpeakQueryAPI
{
    public class ResponseEvent : EventArgs
    {                                              
        private Command.Command command;

        public ResponseEvent(Command.Command command)
        {                              
            this.command = command;
        }

        public Command.Command GetCommand()
        {
            return command;
        }  
    }
}
