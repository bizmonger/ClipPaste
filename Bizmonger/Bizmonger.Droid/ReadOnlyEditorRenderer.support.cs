using Android.Content;
using Entities;
using Xamarin.Forms;
using Bizmonger.Patterns;

namespace Bizmonger.Droid
{
    public partial class ReadOnlyEditorRenderer
    {
        MessageBus _messagebus = MessageBus.Instance;

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

            if (this.Control.Text == clipboardData)
            {
                var clipboardManager = Forms.Context.GetSystemService(Context.ClipboardService) as ClipboardManager;
                var clip = global::Android.Content.ClipData.NewPlainText("text label", clipboardData);
                clipboardManager.PrimaryClip = clip;

                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightGreen);
            }
            else
            {
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
            }
        }

        private void PromiseClipboardRequestResponse()
        {
            _messagebus.Subscribe(Messages.REQUEST_SET_CLIPBOARD, OnClipboardSet);
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