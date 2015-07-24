using Bizmonger.Patterns;
using Core;
using Entities;
using System.Windows.Input;

namespace ViewMenu
{
    public class Commands : ViewModelBase
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        public Commands()
        {
            Copy = new DelegateCommand(obj => { _messagebus.Publish(Messages.REQUEST_SET_CLIPBOARD, (obj as Content)?.Value); });
        }

        public ICommand Copy { get; private set; }
    }
}