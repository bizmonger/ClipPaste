using Android.Content;
using Xamarin.Forms;

namespace Bizmonger.Droid
{
    public partial class ReadOnlyEditorRenderer
    {
        private void ResponseToFocusChanged(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightBlue);
                _messagebus.Publish("CONTENT_SELECTED", this.Control.Text);
            }
            else
            {
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
            }
        }

        private void OnClipboardSet(object obj)
        {
            var clipboardData = obj as string;

            this.Control.SetBackgroundColor(this.Control.Text == clipboardData ?
                global::Android.Graphics.Color.LightGreen : global::Android.Graphics.Color.White);

            if (this.Control.Text == clipboardData)
            {
                var clipboardManager = Forms.Context.GetSystemService(Context.ClipboardService) as ClipboardManager;
                var clip = global::Android.Content.ClipData.NewPlainText("text label", clipboardData);
                clipboardManager.PrimaryClip = clip;
            }
        }
    }
}