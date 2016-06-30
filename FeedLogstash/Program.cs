using System;
using System.Configuration;

namespace FeedLogstash
{
    internal class Program
    {
        private static readonly int Timeout = int.Parse(ConfigurationManager.AppSettings["timeout"]);
        private static readonly int Repeat = int.Parse(ConfigurationManager.AppSettings["repeat"]);
        private static readonly int LogstashPort = int.Parse(ConfigurationManager.AppSettings["logstashPort"]);
        private static readonly string LogstashHost = ConfigurationManager.AppSettings["logstashHost"];

        private static void Main(string[] args)
        {
            try
            {
                var sender = new LogstashSender(LogstashHost, LogstashPort);

                for (var id = 1; id <= Repeat; id++)
                {
                    var log = new Log(id, DateTime.Now, "Test Message: " + id);

                    Console.WriteLine("Send: " + log);

                    sender.Push(log);
                    System.Threading.Thread.Sleep(TimeSpan.FromSeconds(Timeout));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Fatal error: " + e.Message);
                Console.ReadLine();
            }
        }
    }
}