using System;
using System.ComponentModel;

namespace Assingment5
{
    /// <summary>
    ///     Class nessessary to bind strings to the display
    /// </summary>
    class FeedbackMessageModel : INotifyPropertyChanged
    {
        private bool isError;
        private string errorField, 
                       feedbackMessage;

        public FeedbackMessageModel()
        {
            ResetFeedback();
            PropertyChanged += FeedbackModel_PropertyChanged;
        }

        public bool IsError
        {
            get => isError;
            set
            {
                isError = value;
                NotifyPropertyChanged("IsError");
            }
        }

        public string ErrorField
        {
            get => errorField;
            set {
                if(errorField != value)
                {
                    errorField = value;
                    NotifyPropertyChanged("ErrorField");
                }
            }
        }

        public string Feedback
        {
            get => feedbackMessage;
            set
            {
                if (feedbackMessage != value)
                {
                    feedbackMessage = value;
                    NotifyPropertyChanged("Feedback");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        ///     Changes the feedback textbox's color to be red and displays a message
        /// </summary>
        /// <param name="s">The message to be displayed</param>
        public void DisplayError(string s)
        {
            IsError = true;
            Feedback = s;
        }

        /// <summary>
        ///     Changes the feedback textbox's color to be white and displays a message
        /// </summary>
        /// <param name="s">The message to be displayed</param>
        public void DisplayMessage(string s)
        {
            IsError = false;
            Feedback = s;
        }

        /// <summary>
        ///     Clears the feedback textbox
        /// </summary>
        public void ResetFeedback()
        {
            IsError = false;
            Feedback = "";
        }

        /// <summary>
        ///     Re-enables the add/edit button after the user changes the field that caused the error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FeedbackModel_PropertyChanged(Object sender, PropertyChangedEventArgs e)
        {
            if (!(e.PropertyName == "ErrorField" || e.PropertyName == "IsError" || e.PropertyName == "Feedback"))
            {
                if (ErrorField != null && e.PropertyName == ErrorField)
                {
                    ErrorField = null;
                    ResetFeedback();
                }
            }
        }

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}