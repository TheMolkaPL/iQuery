using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public class Event
    {
        private Dictionary<string, string> map;

        public Event(Dictionary<string, string> map)
        {
            this.map = map;
        }

        public Dictionary<string, string> GetMap()
        {
            return map;
        }
    }
}
