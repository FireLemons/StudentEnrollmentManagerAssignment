using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    class RadiobuttonToGradStatus : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null && (((bool)value && (string)parameter == "grad") || (!(bool)value && (string)parameter == "undergrad"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                switch ((string)parameter)
                {
                    case "grad":
                        return true;
                    case "undergrad":
                        return false;
                    default:
                        return DependencyProperty.UnsetValue;
                }
            }

            return false;
        }
    }
}
