using Core;
using static Bizmonger.Patterns.MessageBus;

namespace Tests
{
    public class MockMessageServer : IMessageServer
    {
        static MockMessageServer _instance;

        MockMessageServer() { }

        public static MockMessageServer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MockMessageServer();
                }

                return _instance;
            }
        }
        public void SendMessage(Message message)
        {
            foreach (var toId in message.ToList)
            {
                Publish(toId, message);
            }
        }
    }
}