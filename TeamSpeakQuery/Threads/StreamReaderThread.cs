using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TeamSpeakQueryAPI.Command;
using TeamSpeakQueryAPI.Event;
using TeamSpeakQueryAPI.Utils;

namespace TeamSpeakQueryAPI.Threads
{
    public class StreamReaderThread
    {
        private StreamReader reader;
        private TeamSpeakQuery query;
        private List<Command.Command> queueCommands;
        private bool running;
        private string lastResponse;

        public StreamReaderThread(TeamSpeakQuery query, StreamReader reader)
        {
            this.queueCommands = new List<Command.Command>();
            this.query = query;
            this.reader = reader;
            lastResponse = "";
        }

        public void Run()
        {
            while (running)
            {
                string response = reader.ReadLine();       
                try
                {   
                    if (response.Equals(""))
                    {
                        continue;
                    }

                    //this.WriteIn(response);     

                    if (response.StartsWith("error"))
                    {
                        if (response.Contains("id=3329") || response.Contains("id=3331"))
                        {
                            Console.WriteLine("Opss... Query has been banned for spam :(");
                            query.Disconnect();     
                            return;
                        }

                        lock (queueCommands)
                        {                             
                            var command = queueCommands[0];
                            command.SetCommandError(new CommandError(response).ParseResponse());
                            command.GotResponse();
                            queueCommands.RemoveAt(0);
                        }                
                    }
                    else if (response.StartsWith("notify") && query.GetEvents().Count != 0)
                    {
                        if (response.StartsWith("notifycliententerview"))
                        {
                            if (lastResponse.Equals(response))
                            {
                                continue;
                            }
                            lastResponse = response;

                            foreach (var listener in query.GetEvents())
                            {
                                listener.ClientJoin(new ClientJoinEvent(ParseResponse(response)[0]));
                            }
                        }
                        else if (response.StartsWith("notifyclientleftview"))
                        {
                            if (lastResponse.Equals(response))
                            {
                                continue;
                            }
                            lastResponse = response;

                            foreach (var listener in query.GetEvents())
                            {
                                listener.ClientLeave(new ClientLeaveEvent(ParseResponse(response)[0]));
                            }
                        }
                        else if (response.StartsWith("notifytextmessage"))
                        {
                            foreach (var listener in query.GetEvents())
                            {
                                listener.TextMessage(new TextMessageEvent(ParseResponse(response)[0]));
                            }
                        }
                        else if (response.StartsWith("notifyclientmoved"))
                        {
                            if (lastResponse.Equals(response))
                            {
                                continue;
                            }
                            lastResponse = response;

                            foreach (var listener in query.GetEvents())
                            {
                                listener.ClientMoved(new ClientMovedEvent(ParseResponse(response)[0]));
                            }
                        }
                    }
                    else
                    {
                        var command = queueCommands[0];
                        command.SetResponse(this.ParseResponse(response));
                        command.SetRawResponse(response);
                    } 
                }
                catch (Exception ex)
                {                             
                    Console.WriteLine("StreamReaderThread error...");
                    Console.WriteLine(" > " + response);
                    var color = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error code: " + ex);
                    Console.ForegroundColor = color;
                } 
            }
        }

        private void isRepeated()
        {

        }

        public List<Command.Command> GetQueue()
        {
            return queueCommands;
        }

        public List<CommandResponse> ParseResponse(string rawResponse)
        {
            List<CommandResponse> response = new List<CommandResponse>();
            string[] list = rawResponse.Split('|');
            foreach (var response2 in list)
            {
                CommandResponse commandResponse = new CommandResponse();
                response.Add(commandResponse);
                string[] responseTable = response2.Split(' ');                     

                foreach (string parameters in responseTable)
                {    
                    string[] values = parameters.Split(new char[] { '=' }, 2);

                    if (!commandResponse.ContainsKey(values[0]))
                    {
                        if (values.Length == 1)
                        {
                            commandResponse.Add(values[0], "");
                        }
                        else
                        {
                            commandResponse.Add(values[0], CommandEncoding.decode(values[1]));
                        }
                    } 
                }
            }

            return response;
        }

        private void WriteIn(string text)
        {                                     
            lock (Console.Out)
            {
                var color = Console.ForegroundColor;
                Trace.Write("in");
                Console.ForegroundColor = ConsoleColor.Green;
                Trace.Write(" <- ");
                Console.ForegroundColor = color;
                Trace.WriteLine(text);      
            }
        }
                                                            
        public void AddCommand(Command.Command command)
        {                                                            
            this.queueCommands.Add(command);        
        }

        public void SetRunning(bool running)
        {
            this.running = running;
        }
    }
}
