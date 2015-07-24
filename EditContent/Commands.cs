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
            Save = new DelegateCommand(OnSave);
        }
        
        public ICommand Save { get; private set; }
    }
}