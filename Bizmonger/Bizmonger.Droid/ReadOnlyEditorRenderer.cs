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
            _messagebus.Subscribe("REQUEST_SET_CLIPBOARD", OnClipboardSet);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.FocusChange += ResponseToFocusChanged;
                this.Control.LongClick += (se, ev) => _messagebus.Publish(Messages.REQUEST_EDIT, this.Control.Text);

                this.Control.SetTextColor(global::Android.Graphics.Color.Black);
                this.Control.SetBackgroundColor(global::Android.Graphics.Color.LightGray);
                this.Control.InputType = Android.Text.InputTypes.Null;
                this.Control.SetTextSize(Android.Util.ComplexUnitType.Pt, 6);
                this.Control.LongClickable = true;
                this.Control.SetPadding(5,5,5,5);
            }
        }
    }
}