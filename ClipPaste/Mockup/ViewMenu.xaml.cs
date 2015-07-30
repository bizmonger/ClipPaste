using System.Windows;
using System.Windows.Controls;
using ViewMenu;

namespace Mockup
{
    /// <summary>
    /// Interaction logic for ViewMenu.xaml
    /// </summary>
    public partial class ViewMenu : Window
    {
        #region Members
        ViewModel _viewModel = null;
        #endregion
        public ViewMenu()
        {
            InitializeComponent();
            _viewModel = this.DataContext as ViewModel;
        }

        void OnTextBoxLoaded(object sender, RoutedEventArgs e)
        {
            var textbox = e.Source as TextBox;
            textbox.GotFocus += (se, ev) =>
                {
                    _viewModel.SelectedContent.Value = textbox.Text;
                    _viewModel.CopyMade = false;
                };
        }
    }
}