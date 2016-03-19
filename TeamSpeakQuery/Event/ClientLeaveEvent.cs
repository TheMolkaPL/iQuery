using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public class ClientLeaveEvent : Event
    {
        public ClientLeaveEvent(Dictionary<string, string> map) : base(map) { }

        public string GetCfid()
        {
            return this.GetMap()["cfid"];
        }

        public int GetCtid()
        {
            return int.Parse(this.GetMap()["ctid"]);
        }

        public int GetClid()
        {
            return int.Parse(this.GetMap()["clid"]);
        }  
    }
}
