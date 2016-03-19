using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Command
{
    public class CommandError
    {
        private string response;
        private int id;
        private string message;

        public CommandError(string response)
        {
            this.response = response;          
        }

        public CommandError ParseResponse()
        {
            string[] responseTable = response.Split(' ');

            foreach (string parameters in responseTable)
            {
                string[] values = parameters.Split(new char[] { '=' }, 2);      
                if (values[0].Equals("id"))
                {
                    this.id = int.Parse(values[1]);
                }
                else if (values[0].Equals("msg"))
                {
                    this.message = values[1];
                }
            }
            return this;
        }

        public int GetID()
        {
            return this.id;
        }

        public string GetMessage()
        {
            return this.message;
        }
    }
}
