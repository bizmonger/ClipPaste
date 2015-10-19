using System.Collections.Generic;
using static Bizmonger.Patterns.MessageBus;
using static Mediation.Messages;

namespace Core
{
    public class LocationMessageAgent : LocationAgent
    {
        public LocationMessageAgent()
        {
            Subscribe(REQUEST_MESSAGE_SERVER_RESPONSE, obj => _messageServer = obj as IMessageServer);
            Publish(REQUEST_MESSAGE_SERVER);
        }
        protected IMessageServer _messageServer = null;

        public void Send(Message message)
        {
            _messageServer.SendMessage(message);
        }

        public List<Message> Messages { get; } = new List<Message>();
    }
}