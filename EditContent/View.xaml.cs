using Entities;
using Xamarin.Forms;

namespace EditContent
{
    public partial class View : ContentPage
    {
        ViewModel _viewModel = null;

        public View()
        {
            InitializeComponent();
        }

        public View(Content content)
        {
            InitializeComponent();

            _viewModel = this.Resources["ViewModel"] as ViewModel;
            _viewModel.Content = content;
        }
    }
}