using Bizmonger.Patterns;
using System.Windows.Input;

namespace ViewMenu
{
    public partial class ViewModel
    {
        public ViewModel()
        {
            CreateQuote = new DelegateCommand((obj) => _messagebus.Publish(Messages.REQUEST_CREATE_QUOTE));
            SearchCustomers = new DelegateCommand((obj) => _messagebus.Publish(Messages.REQUEST_SEARCH_CUSTOMERS));
            ViewServices = new DelegateCommand((obj) => _messagebus.Publish(Messages.REQUEST_SERVICES));
            ViewMaterials = new DelegateCommand((obj) => _messagebus.Publish(Messages.REQUEST_MATERIALS));
        }

        public ICommand CreateQuote { get; private set; }
        public ICommand SearchCustomers { get; private set; }
        public ICommand ViewServices { get; private set; }
        public ICommand ViewMaterials { get; private set; }
    }
}