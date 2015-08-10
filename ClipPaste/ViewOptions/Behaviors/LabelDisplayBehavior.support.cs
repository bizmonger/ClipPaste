using Bizmonger.Patterns;
using Mediation;
using Xamarin.Forms;

namespace ViewMenu.Behaviors
{
    public partial class LabelDisplayBehavior
    {
        MessageBus _messageBus = MessageBus.Instance;
        Label _label = null;

        void OnClipboardSet(object obj)
        {
            var clipboardData = obj as string;

            _label.IsVisible = false;

            _messageBus.SubscribeFirstPublication(Messages.REQUEST_MATCHING_ENTRY_RESPONSE, arg =>
                {
                    var label = arg as Label;

                    if (label == _label)
                    {
                        label.IsVisible = true;
                    }
                });

            _messageBus.Publish(Messages.REQUEST_MATCHING_ENTRY, clipboardData);
        }
    }
}