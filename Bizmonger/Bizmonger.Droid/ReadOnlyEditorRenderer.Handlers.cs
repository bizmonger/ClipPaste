using Android.Content;
using Entities;
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
                global::Android.Graphics.Color.LightGreen : global::Android.Graphics.Color.LightGray);

            if (this.Control.Text == clipboardData)
            {
                var clipboardManager = Forms.Context.GetSystemService(Context.ClipboardService) as ClipboardManager;
                var clip = global::Android.Content.ClipData.NewPlainText("text label", clipboardData);
                clipboardManager.PrimaryClip = clip;
            }
        }

        private void PromiseClipboardRequestResponse()
        {
            _messagebus.SubscribeFirstPublication(Messages.REQUEST_SET_CLIPBOARD, OnClipboardSet);
        }

        private void RequestContent()
        {
            this.Control.LongClick += (se, ev) =>
                _messagebus.Publish(Messages.REQUEST_CONTENT, this.Control.Text);
        }

        private void PromiseContentResponse()
        {
            _messagebus.Subscribe(Messages.REQUEST_CONTENT_RESPONSE, obj =>
                {
                    var content = obj as Content;

                    if (content.Value == this.Control.Text)
                    {
                        _messagebus.Publish(Messages.REQUEST_EDIT, obj);
                    }
                });
        }

        private void SetPresentation()
        {
            this.Control.SetTextColor(global::Android.Graphics.Color.Black);
            this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
            this.Control.InputType = Android.Text.InputTypes.Null;
            this.Control.SetTextSize(Android.Util.ComplexUnitType.Pt, 6);
            this.Control.LongClickable = true;
            this.Control.SetPadding(5, 5, 5, 5);
        }

        private void PromiseResponseToFocus()
        {
            this.Control.FocusChange += ResponseToFocusChanged;
        }
    }
}