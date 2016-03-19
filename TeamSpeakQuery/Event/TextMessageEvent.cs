using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public class TextMessageEvent : Event
    {
        public TextMessageEvent(Dictionary<string, string> map) : base(map) { }

        public int GetTargetmode()
        {
            return int.Parse(this.GetMap()["targetmode"]);
        }

        public string GetMsg()
        {
            return this.GetMap()["msg"];
        }

        public int GetInvokerid()
        {
            return int.Parse(this.GetMap()["invokerid"]);
        }

        public string GetInvokername()
        {
            return this.GetMap()["invokername"];
        }

        public string GetInvokeruid()
        {
            return this.GetMap()["invokeruid"];
        }     

        public int GetTarget()
        {
            return int.Parse(this.GetMap()["target"]);
        }
    }

    public enum Targetmode : int
    {
        PRIVATE_MESSAGE = 1,
        CHANNEL = 2,
        GLOBAL_MESSAGE = 3
    }
}
