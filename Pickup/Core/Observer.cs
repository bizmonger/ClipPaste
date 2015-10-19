using static Bizmonger.Patterns.MessageBus;

namespace Core
{
    public class Observer : LocationMessageAgent
    {
        public Observer()
        {
            Id = "message_to_observer";
            Subscribe(Id, obj => Messages.Add(obj as Message));
        }
    }
}