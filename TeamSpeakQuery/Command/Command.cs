using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Command
{
    public class Command
    {
        public delegate void ResponseEventHandler(ResponseEvent _args);
        public event ResponseEventHandler OnResponse;      
        private string command;
        private string rawResponse;
        private CommandError error;
        private List<CommandResponse> response;    

        public Command(string command)
        {
            this.command = command;
        }

        public void GotResponse()
        {
            if (OnResponse != null)
                OnResponse(new ResponseEvent(this));
        }                                               

        public string GetRawResponse()
        {
            return rawResponse;
        }

        public void SetRawResponse(string rawResponse)
        {
            this.rawResponse = rawResponse;
        }
        
        public string GetCommand()
        {
            return command;
        }
        
        public List<CommandResponse> GetResponse()
        {
            return response;
        }

        public void SetResponse(List<CommandResponse> response)
        {
            this.response = response;
        }  

        public CommandError GetCommandError()
        {
            return error;
        }                                 

        public void SetCommandError(CommandError error)
        {
            this.error = error;
        }                                     
    }
}
