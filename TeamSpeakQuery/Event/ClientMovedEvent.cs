using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public class ClientMovedEvent : Event
    {
        public ClientMovedEvent(Dictionary<string, string> map) : base(map) { }

        public int GetCtid()
        {
            return int.Parse(this.GetMap()["ctid"]);
        }

        public int GetClid()
        {
            return int.Parse(this.GetMap()["clid"]);
        }                                                

        public int GetReasonID()
        {
            return int.Parse(this.GetMap()["reasonid"]);
        }  
    }
}
