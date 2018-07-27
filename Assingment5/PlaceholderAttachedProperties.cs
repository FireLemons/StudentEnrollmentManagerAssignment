using System;
using System.Windows;

namespace Assingment5
{
    /// <summary>
    ///     Holds placeholder text for reuse of input with placeholder style
    /// </summary>
    class PlaceholderAttachedProperties : DependencyObject
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached("Placeholder", typeof(String), typeof(PlaceholderAttachedProperties), new UIPropertyMetadata(null));

        public static String GetPlaceholder(DependencyObject obj)
        {
            return (String)obj.GetValue(PlaceholderProperty);
        }

        public static void SetPlaceholder(DependencyObject obj, String value)
        {
            obj.SetValue(PlaceholderProperty, value);
        }
    }
}
