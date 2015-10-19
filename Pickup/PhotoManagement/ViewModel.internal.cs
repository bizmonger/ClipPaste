using System.Diagnostics;
using System.Threading.Tasks;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services.Media;
using Xamarin.Forms;

namespace PhotoManagement
{
    public partial class ViewModel
    {
        IMediaPicker _mediaPicker = null;
        readonly TaskScheduler _scheduler = TaskScheduler.FromCurrentSynchronizationContext();

        void Setup()
        {
            if (_mediaPicker != null) return;

            var device = Resolver.Resolve<IDevice>();

            _mediaPicker = DependencyService.Get<IMediaPicker>();
            //RM: hack for working on windows phone? 
            if (_mediaPicker == null) _mediaPicker = device.MediaPicker;
        }

        async Task TakePicture()
        {
            Setup();

            ImageSource = null;

            await _mediaPicker.TakePhotoAsync(new CameraMediaStorageOptions { DefaultCamera = CameraDevice.Front, MaxPixelDimension = 400 }).ContinueWith(t =>
            {
                if (t.IsFaulted) { var s = t.Exception.InnerException.ToString(); }

                else if (t.IsCanceled) { var canceled = true; }

                else
                {
                    var mediaFile = t.Result;
                    ImageSource = ImageSource.FromStream(() => mediaFile.Source);

                    return mediaFile;
                }

                return null;
            }, _scheduler);
        }

        async Task SelectPicture()
        {
            Setup();

            ImageSource = null;
            try
            {
                var mediaFile = await _mediaPicker.SelectPhotoAsync(new CameraMediaStorageOptions
                {
                    DefaultCamera = CameraDevice.Front,
                    MaxPixelDimension = 400
                });

                ImageSource = ImageSource.FromStream(() => mediaFile.Source);
            }

            catch (System.Exception ex) { Debug.WriteLine(ex.Message); }
        }
    }
}
