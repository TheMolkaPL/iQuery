using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public interface Ts3Events
    {
        void ClientJoin(ClientJoinEvent e);

        void ClientLeave(ClientLeaveEvent e);

        void TextMessage(TextMessageEvent e);

        void ClientMoved(ClientMovedEvent e);
    }
}
