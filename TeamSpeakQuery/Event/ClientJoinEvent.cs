using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamSpeakQueryAPI.Event
{
    public class ClientJoinEvent : Event
    {
        public ClientJoinEvent(Dictionary<string, string> map) : base(map) { }

        public string GetCfid()
        {
            return this.GetMap()["cfid"];
        }

        public string GetCtid()
        {
            return this.GetMap()["ctid"];
        }

        public int GetReasonid()
        {
            return int.Parse(this.GetMap()["reasonid"]);
        }

        public string GetClid()
        {
            return this.GetMap()["clid"];
        }

        public string GetClientUniqueIdentifier()
        {
            return this.GetMap()["client_unique_identifier"];
        }

        public string GetClientNickname()
        {
            return this.GetMap()["client_nickname"];
        }

        public string GetClientInputMuted()
        {
            return this.GetMap()["client_input_muted"];
        }

        public string GetClientOutputMuted()
        {
            return this.GetMap()["client_output_muted"];
        }

        public string GetClientOutputonlyMuted()
        {
            return this.GetMap()["client_outputonly_muted"];
        }

        public string GetClientInputHardware()
        {
            return this.GetMap()["client_input_hardware"];
        }

        public string GetClientOutputHardware()
        {
            return this.GetMap()["client_output_hardware"];
        }

        public string GetClientMetaData()
        {
            return this.GetMap()["client_meta_data"];      
        }

        public string IsRecording()
        {
            return this.GetMap()["client_is_recording"];
        }

        public string GetClientDatabaseId()
        {
            return this.GetMap()["client_database_id"];
        }

        public string GetClientChannelGroupId()
        {
            return this.GetMap()["client_channel_group_id"];
        }

        public string GetClientServergroups()
        {
            return this.GetMap()["client_servergroups"];
        }

        public string GetClientAway()
        {
            return this.GetMap()["client_away"];
        }

        public string GetClientAwayMessage()
        {
            return this.GetMap()["client_away_message"];
        }

        public string GetClientType()
        {
            return this.GetMap()["client_type"];
        }

        public string GetClientFlagAvatar()
        {
            return this.GetMap()["client_flag_avatar"];
        }

        public string GetClientTalkPower()
        {
            return this.GetMap()["client_talk_power"];
        }

        public string GetClientTalkRequest()
        {
            return this.GetMap()["client_talk_request"];
        }

        public string GetClientTalkRequestMsg()
        {
            return this.GetMap()["client_talk_request_msg"];
        }

        public string GetClientDescription()
        {
            return this.GetMap()["client_description"];
        }

        public string GetClientIsTalker()
        {
            return this.GetMap()["client_is_talker"];
        }

        public string GetClientIsPrioritySpeaker()
        {
            return this.GetMap()["client_is_priority_speaker"];
        }

        public string GetClientUnreadMessages()
        {
            return this.GetMap()["client_unread_messages"];
        }

        public string GetClientNicknamePhonetic()
        {
            return this.GetMap()["client_nickname_phonetic"];
        }

        public string GetClientNeededServerqueryViewPower()
        {
            return this.GetMap()["client_needed_serverquery_view_power"];
        }

        public string GetClientIconId()
        {
            return this.GetMap()["client_icon_id"];
        }

        public string GetClientIsChannelCommander()
        {
            return this.GetMap()["client_is_channel_commander"];
        }

        public string GetClientCountry()
        {
            return this.GetMap()["client_country"];
        }

        public string GetClientChannelGroupInheritedChannelId()
        {
            return this.GetMap()["client_channel_group_inherited_channel_id"];
        }

        public string GetClientBadges()
        {
            return this.GetMap()["client_badges"];
        }
    }
}
