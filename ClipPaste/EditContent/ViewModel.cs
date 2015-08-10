using Core;
using Mediation;
using Entities;

namespace EditContent
{
    public partial class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            _messagebus.Subscribe(Messages.REQUEST_REFRESH_CONTENT, obj => { Content = obj as Content; });
            _messagebus.Subscribe(Messages.REQUEST_LOAD_EDITOR, obj => { Content = obj as Content; });
        }

        public string PreviousContent { get; set; }

        Content _content = new Content();
        public Content Content
        {
            get { return _content; }
            set
            {
                if (value != _content)
                {
                    _content = value;
                    CanSave = true;
                    OnPropertyChanged();
                }
            }
        }
        public bool CanSave { get; set; }
    }
}