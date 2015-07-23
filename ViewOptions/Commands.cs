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
            Edit = new DelegateCommand(obj =>_messagebus.Publish(Messages.REQUEST_EDIT, obj as Content));
        }

        public ICommand Edit { get; private set; }
    }
}