using System;
using System.Globalization;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    /// <summary>
    ///     Class to help bind an enum to a set of radio buttons
    ///     code made with help from https://www.codeproject.com/Tips/720497/Binding-Radio-Buttons-to-a-Single-Property
    /// </summary>
    class RadiobuttonToGender : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(true) ? parameter : Binding.DoNothing;
        }
    }
}
