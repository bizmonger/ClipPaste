using System;
using System.Collections.Generic;

namespace Core
{
    public class Message
    {
        public Message(string from, IEnumerable<string> toList, string content) : this(from, content)
        {
            ToList = toList;
        }

        public Message(string from, string content)
        {
            From = from;
            Content = Content;
            Timestamp = DateTime.Now;
        }

        public string Content { get; }
        public string From { get; }
        public IEnumerable<string> ToList { get; }
        public DateTime Timestamp { get; }
    }
}