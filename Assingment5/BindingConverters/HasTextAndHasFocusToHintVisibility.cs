using System;
using System.Windows;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    /// <summary>
    ///     Contains script to determine whether hint should be displayed
    ///     https://code.msdn.microsoft.com/windowsapps/How-to-add-a-hint-text-to-ed66a3c6
    /// </summary>
    public class HasTextAndHasFocusToHintVisibility : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Always test MultiValueConverter inputs for non-null 
            // (to avoid crash bugs for views in the designer) 
            if (values[0] is bool && values[1] is bool)
            {
                bool hasText = !(bool)values[0],
                     hasFocus = (bool)values[1];

                if (hasFocus || hasText)
                {
                    return Visibility.Collapsed;
                }
            }
            return Visibility.Visible;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}