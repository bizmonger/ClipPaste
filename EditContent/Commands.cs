using Bizmonger.Patterns;
using Core;
using System.Windows.Input;

namespace EditContent
{
    public partial class Commands : ViewModelBase
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        public Commands()
        {
            Cancel = new DelegateCommand(obj => _messagebus.Publish(Messages.REQUEST_PREVIOUS_VIEW, obj));
            Save = new DelegateCommand(OnSave);
        }
        
        public ICommand Cancel { get; private set; }
        public ICommand Save { get; private set; }
    }
}