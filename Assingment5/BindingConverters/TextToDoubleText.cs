using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    class TextToDoubleText : IValueConverter
    {
        private string bindingProperty;
        private FeedbackMessageModel errorDisplay;

        public TextToDoubleText(FeedbackMessageModel errorDisplay, string bindingProperty)
        {
            this.bindingProperty = bindingProperty;
            this.errorDisplay = errorDisplay;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value == null) ? DependencyProperty.UnsetValue : value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                double conversion = Double.Parse((string)value);

                if (conversion < 0 || conversion > 4)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (errorDisplay.IsError)
                {
                    if (errorDisplay.ErrorField == bindingProperty)
                    {
                        errorDisplay.ErrorField = null;
                    }
                    errorDisplay.ResetFeedback();
                }

                return value;
            } catch (Exception)
            {
                errorDisplay.ErrorField = bindingProperty;
                errorDisplay.IsError = true;
                errorDisplay.Feedback = "Could not convert text into a number between 0 and 4.0 inclusive";
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
