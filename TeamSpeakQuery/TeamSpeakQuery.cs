using System;                 
using System.Collections.Generic;   
using System.IO;
using System.Net.Sockets;
using System.Threading;
using TeamSpeakQueryAPI.Command;
using TeamSpeakQueryAPI.Event;
using TeamSpeakQueryAPI.Threads;

namespace TeamSpeakQueryAPI
{
    public class TeamSpeakQuery
    {
        private TcpClient client;                     
        private StreamReaderThread streamReaderThread;
        private StreamWriterThread streamWriterThread;
        private List<Ts3Events> events;
        private List<Thread> threads;     

        public TeamSpeakQuery()
        {                                                       
            this.threads = new List<Thread>();
            this.events = new List<Ts3Events>();
            Console.WriteLine("TeamSpeakQuery enabled... Created by filippop1");
        }

        public void Connect(string host, int port)
        {                                                                    
            client = new TcpClient(host, port);
            StreamWriter writer = new StreamWriter(client.GetStream());
            StreamReader reader = new StreamReader(client.GetStream());

            reader.ReadLine();
            reader.ReadLine();    // welcome message
            reader.ReadLine();


            streamReaderThread = new StreamReaderThread(this, reader);
            streamReaderThread.SetRunning(true);
            threads.Add(new Thread(new ThreadStart(streamReaderThread.Run)));

            streamWriterThread = new StreamWriterThread(this, writer);
            streamWriterThread.SetRunning(true);
            threads.Add(new Thread(new ThreadStart(streamWriterThread.Run)));          

            threads.Add(new Thread(new ThreadStart(new KeepAliveThread(this).Run)));     
                 
            foreach (var thread in threads)
            {
                thread.Start();
            }
        }  
        
        public void Disconnect()
        {
            Send("logout");
            Send("exit");
            foreach (var thread in threads)
            {
                thread.Interrupt();
            }                
            client.Close();   
        }

        public void RegisterQueryListeners()
        {                              
            Send("servernotifyregister event=server");
            Send("servernotifyregister event=textserver");
            Send("servernotifyregister event=textchannel");
            Send("servernotifyregister event=textprivate");
            Send("servernotifyregister event=channel id=0");
        }

        public void UnregisterQueryListeners()
        {                                  
            Send("servernotifyunregister");
        }

        public void RegisterListener(Ts3Events events)
        {
            this.events.Add(events);
        }

        public void UnregisterListener(Ts3Events events)
        {
            this.events.Remove(events);
        }

        private readonly object syncLock = new object();

        public Command.Command Send(string command) => Send(command, null);

        public Command.Command Send(string command, params Parameter[] parameters) => Send(command, parameters, null);

        public Command.Command Send(string command, Parameter[] parameters, string[] options)
        {                 
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command += " " + parameter.GetKey() + "=" + parameter.GetValue();
                }
            }

            if (options != null)
            {
                foreach (var option in options)
                {
                    command += " -" + option;
                }
            }

            Command.Command command2 = new Command.Command(command);
                             
            streamWriterThread.GetQueue().Enqueue(command2); 

            return command2;
        }                                              

        public StreamWriterThread GetStreamWriterThread()
        {
            return streamWriterThread;
        }

        public StreamReaderThread GetStreamReaderThread()
        {
            return streamReaderThread;
        }

        public List<Ts3Events> GetEvents()
        {
            return events;
        }  
    }
}
