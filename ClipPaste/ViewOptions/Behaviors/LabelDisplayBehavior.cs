using Mediation;
using Xamarin.Forms;

namespace ViewMenu.Behaviors
{
    public partial class LabelDisplayBehavior : Behavior<Label>
    {
        protected override void OnAttachedTo(Label label)
        {
            _label = label;
            _messageBus.Subscribe(Messages.REQUEST_SET_CLIPBOARD, OnClipboardSet);
        }
        
        protected override void OnDetachingFrom(Label bindable)
        {
        }
    }
}