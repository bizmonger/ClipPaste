﻿using Bizmonger.Patterns;
using Xamarin.Forms;

namespace ViewMenu.Behaviors
{
    public class LabelDisplayBehavior : Behavior<Label>
    {
        #region Members
        MessageBus _messageBus = MessageBus.Instance;
        Label _label = null;
        #endregion

        protected override void OnAttachedTo(Label label)
        {
            _label = label;

            _messageBus.Subscribe(Messages.REQUEST_SET_CLIPBOARD, OnClipboardSet);
        }
        
        protected override void OnDetachingFrom(Label bindable)
        {
        }

        #region Helpers
        private void OnClipboardSet(object obj)
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
        #endregion
    }
}