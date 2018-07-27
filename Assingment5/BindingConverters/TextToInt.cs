using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    class TextToInt : IValueConverter
    {
        private string bindingProperty;
        private FeedbackMessageModel errorDisplay;

        public TextToInt(FeedbackMessageModel errorDisplay, string bindingProperty)
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
                int result = int.Parse((string)value);

                if (errorDisplay.IsError)
                {
                    if(errorDisplay.ErrorField == bindingProperty)
                    {
                        errorDisplay.ErrorField = null;
                    }
                    errorDisplay.ResetFeedback();
                }

                return result;
            }
            catch (Exception)
            {
                errorDisplay.ErrorField = bindingProperty;
                errorDisplay.IsError = true;
                errorDisplay.Feedback = "Could not convert text into a positive integer";
                return DependencyProperty.UnsetValue;
            }
        }
    }
}
