using Bizmonger.Patterns;
using Core;
using System.Windows.Input;

namespace EditContent
{
    public partial class Commands : ViewModelBase
    {
        public Commands()
        {
            Save = new DelegateCommand(OnSave);
        }
        
        public ICommand Save { get; private set; }
    }
}