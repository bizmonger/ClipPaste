using Bizmonger.Patterns;
using Core;
using Mediation;
using Entities;
using System.Windows.Input;

namespace ViewMenu
{
    public partial class Commands : ViewModelBase
    {
        public Commands()
        {
            Copy = new DelegateCommand(obj => { _messagebus.Publish(Messages.REQUEST_SET_CLIPBOARD, (obj as Content)?.Value); });
        }

        public ICommand Copy { get; private set; }
    }
}