using System;
using System.Globalization;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    /// <summary>
    ///     Scales dimensions of wpf UI elements by a percentage
    ///     Code sourced from
    ///     https://stackoverflow.com/questions/717299/wpf-setting-the-width-and-height-as-a-percentage-value/717358#717358
    /// </summary>
    class PercentageToWidth : IValueConverter
    {
        /// <summary>
        ///     Scales a dimension of a wpf UI element by a percentage
        /// </summary>
        /// <param name="value">Original unscaled dimension value</param>
        /// <param name="targetType"></param>
        /// <param name="parameter">Percentage of scaling</param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) * System.Convert.ToDouble(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return System.Convert.ToDouble(value) / System.Convert.ToDouble(parameter);
        }
    }
}
