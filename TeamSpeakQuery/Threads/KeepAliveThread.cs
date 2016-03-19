using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Threads
{
    public class KeepAliveThread
    {
        private TeamSpeakQuery query;

        public KeepAliveThread(TeamSpeakQuery query)
        {
            this.query = query;
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1 * 60 * 1000);
                query.Send("whoami");
            }
        }
    }
}
