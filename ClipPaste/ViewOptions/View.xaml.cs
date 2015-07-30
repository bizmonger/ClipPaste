using Bizmonger.Patterns;
using CustomControls;
using DataAccessMediator;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ViewMenu
{
    public partial class View : ContentPage
    {
        #region Members
        ViewModel _viewModel = null;
        MessageBus _messageBus = MessageBus.Instance;
        Dictionary<ReadOnlyEditor, Label> _editorToLabel = new Dictionary<ReadOnlyEditor, Label>();
        #endregion

        public View()
        {
            InitializeComponent();

            _viewModel = this.BindingContext as ViewModel;

            _editorToLabel.Add(textBox1, label1);
            _editorToLabel.Add(textBox2, label2);
            _editorToLabel.Add(textBox3, label3);
            _editorToLabel.Add(textBox4, label4);

            // TODO Optimize matching entry to only be executed once.
            _messageBus.Subscribe(Messages.REQUEST_MATCHING_ENTRY, OnRequestMatchingEntry);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessageBus.Instance.Subscribe(Messages.REPOSITORY_RESPONSE, obj =>
                    _messageBus.Publish(Messages.REQUEST_LOAD_CONTENT, obj as IRepository));

            _messageBus.Publish(Messages.REQUEST_REPOSITORY, DataAccessType.Integration);
        }

        #region Helpers
        void OnRequestMatchingEntry(object obj)
        {
            var text = obj as string;

            foreach (var entry in _editorToLabel.Keys)
            {
                if (entry.Text == text)
                {
                    var matchingLabel = _editorToLabel[entry];
                    _messageBus.Publish(Messages.REQUEST_MATCHING_ENTRY_RESPONSE, matchingLabel);
                    break;
                }
            }
        }
        #endregion
    }
}