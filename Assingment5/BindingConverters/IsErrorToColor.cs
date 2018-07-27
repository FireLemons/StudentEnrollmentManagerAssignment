using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace Assingment5.BindingConverters
{
    /// <summary>
    ///     Converts the bool isError to a foreground color for feedback textblocks
    /// </summary>
    class IsErrorToColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? new SolidColorBrush(Colors.Firebrick) : new SolidColorBrush(Colors.White);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
