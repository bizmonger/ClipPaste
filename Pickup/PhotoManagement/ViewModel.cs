using Bizmonger.Patterns;
using UILogic;
using Xamarin.Forms;

namespace PhotoManagement
{
    public partial class ViewModel : ViewModelBase
    {
        public ViewModel()
        {
            TakePictureCommand = new DelegateCommand(async obj => await TakePicture());
            SelectPictureCommand = new DelegateCommand(async obj => await SelectPicture());
        }

        ImageSource _imageSource = null;
        public ImageSource ImageSource
        {
            get { return _imageSource; }
            set
            {
                if (_imageSource != value)
                {
                    _imageSource = value;
                    OnPropertyChanged();
                }
            }
        }

        DelegateCommand _takePictureCommand = null;
        public DelegateCommand TakePictureCommand
        {
            get { return _takePictureCommand; }

            set
            {
                if (_takePictureCommand != value)
                {
                    _takePictureCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        DelegateCommand _selectPictureCommand = null;
        public DelegateCommand SelectPictureCommand
        {
            get { return _selectPictureCommand; }
            set
            {
                if (_selectPictureCommand != value)
                {
                    _selectPictureCommand = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}