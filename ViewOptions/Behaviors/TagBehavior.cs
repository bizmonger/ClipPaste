using System.Diagnostics;
using Xamarin.Forms;

namespace ViewMenu.Behaviors
{
    public class TagBehavior
    {
        public static readonly BindableProperty TagProperty = BindableProperty.CreateAttached<TagBehavior, object>(
               @object => TagBehavior.GetTag(@object),
               null, /* default value */
               BindingMode.OneWay,
               null,
               (bo, old, @new) => TagBehavior.OnTagChanged(bo, old, @new),
               null,
               null);

        public static object GetTag(BindableObject bindableObject)
        {
            return (string)bindableObject.GetValue(TagBehavior.TagProperty);
        }

        public static void SetTag(BindableObject bindingObject, object value)
        {
            bindingObject.SetValue(TagBehavior.TagProperty, value);
        }

        public static void OnTagChanged(BindableObject bindableObject, object oldValue, object newValue)
        {
            //var label = bindableObject as View;
            //var tag = TagBehavior.GetTag(label);

            //if (tag != null)
            //{
            //    Debug.WriteLine("TODO - Handle tag's value change event");
            //}
        }
    }
}