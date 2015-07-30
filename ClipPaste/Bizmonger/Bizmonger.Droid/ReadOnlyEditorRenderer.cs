using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Bizmonger.Droid;
using CustomControls;

[assembly: ExportRenderer(typeof(ReadOnlyEditor), typeof(ReadOnlyEditorRenderer))]
namespace Bizmonger.Droid
{
    public partial class ReadOnlyEditorRenderer : EditorRenderer
    {
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