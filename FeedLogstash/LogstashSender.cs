using SimpleTCP;

namespace FeedLogstash
{
    class LogstashSender
    {
        private readonly SimpleTcpClient _client;

        public LogstashSender(string host, int port)
        {
            _client = new SimpleTcpClient().Connect(host, port);
        }

        ~LogstashSender()
        {
            _client?.Disconnect();
        }

        public void Push(Log log)
        {
            _client.Write(log + "\n");
        }
    }
}