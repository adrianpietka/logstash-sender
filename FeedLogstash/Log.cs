using System;
using Newtonsoft.Json;

namespace FeedLogstash
{
    class Log
    {
        public readonly int Id;
        public readonly DateTime DateTime;
        public readonly string Message;

        public Log(int id, DateTime dateTime, string message)
        {
            Id = id;
            DateTime = dateTime;
            Message = message;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
