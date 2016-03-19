using iHelp.List;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace TeamSpeakQueryAPI.Threads
{
    public class StreamWriterThread
    {                                     
        private TeamSpeakQuery query;
        private StreamWriter writer;
        private SizeQueue<Command.Command> queue;
        private bool running;        

        public StreamWriterThread(TeamSpeakQuery query, StreamWriter writer)
        {
            this.queue = new SizeQueue<Command.Command>(1024);
            this.query = query;
            this.writer = writer; 
        }

        public void Run()
        {       
            while (running)
            {            
                this.Send(queue.Dequeue());
            }   
        }                                                          
                                                           
        private void Send(Command.Command command)
        {
            try
            {     
                writer.WriteLine(command.GetCommand());
                query.GetStreamReaderThread().AddCommand(command);
                writer.Flush();                           
                //this.WriteOut(command.GetCommand());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }    
        }                           

        private void WriteOut(string text)
        {                           
            lock (Console.Out)
            {
                var color = Console.ForegroundColor;
                Trace.Write("out");
                Console.ForegroundColor = ConsoleColor.Red;
                Trace.Write(" -> ");
                Console.ForegroundColor = color;
                Trace.WriteLine(text); 
            }
        }

        public StreamWriter GetStreamWriter()
        {
            return writer;
        }

        public SizeQueue<Command.Command> GetQueue()
        {
            return queue;
        }

        public void SetRunning(bool running)
        {
            this.running = running;
        }
    }            
}
