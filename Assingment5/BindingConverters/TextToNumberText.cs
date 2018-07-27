using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Assingment5.BindingConverters
{
    class TextToNumberText : IValueConverter
    {
        private string bindingProperty;
        private FeedbackMessageModel errorDisplay;

        public TextToNumberText(FeedbackMessageModel errorDisplay, string bindingProperty)
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
            string input = value.ToString();

            foreach(char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    errorDisplay.ErrorField = bindingProperty;
                    errorDisplay.IsError = true;
                    errorDisplay.Feedback = "Student ID can only be a number";
                    return DependencyProperty.UnsetValue;
                }
            }

            if (errorDisplay.IsError)
            {
                if(errorDisplay.ErrorField == bindingProperty)
                {
                    errorDisplay.ErrorField = null;
                }
                errorDisplay.ResetFeedback();
            }

            return value;
        }
    }
}
