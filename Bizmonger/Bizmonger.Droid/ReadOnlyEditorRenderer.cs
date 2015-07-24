using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Bizmonger.Droid;
using CustomControls;
using Bizmonger.Patterns;

[assembly: ExportRenderer(typeof(ReadOnlyEditor), typeof(ReadOnlyEditorRenderer))]
namespace Bizmonger.Droid
{
    public partial class ReadOnlyEditorRenderer : EditorRenderer
    {
        #region Members
        MessageBus _messagebus = MessageBus.Instance;
        #endregion

        public ReadOnlyEditorRenderer()
        {
            PromiseClipboardRequestResponse();
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                PromiseContentResponse();
                RequestContent();

                PromiseResponseToFocus();
                SetPresentation();
            }
        }
    }
}