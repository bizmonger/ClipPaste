using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Bizmonger.Droid;
using CustomControls;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace Bizmonger.Droid
{
    public class CustomEditorRenderer : EditorRenderer
    {
        public CustomEditorRenderer() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.SetTextColor(global::Android.Graphics.Color.Black);
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightYellow);
                this.Control.SetPadding(30, 5, 30, 5);
            }
        }
    }
}