using System;
using System.ComponentModel;

namespace Assingment5.ModelClasses
{
    class CourseModel : FeedbackMessageModel
    {
        private bool isEdit;
        private string name,
                       gpa;
        private uint? number,
                     creditHours;

        public CourseModel()
        {
            name = "";
        }

        public bool IsEdit
        {
            get => isEdit;
            set
            {
                if (isEdit != value)
                {
                    isEdit = value;
                    NotifyPropertyChanged("IsEdit");
                }
            }
        }

        public string GPA
        {
            get => gpa;
            set
            {
                if (gpa != value)
                {
                    gpa = value;
                    NotifyPropertyChanged("GPA");
                }
            }
        }

        public string Name
        {
            get => name;
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public uint? Number
        {
            get => number;
            set
            {
                if (number != value)
                {
                    number = value;
                    NotifyPropertyChanged("Number");
                }
            }
        }
        
        public uint? CreditHours
        {
            get => creditHours;
            set
            {
                if (creditHours != value)
                {
                    creditHours = value;
                    NotifyPropertyChanged("CreditHours");
                }
            }
        }

        public void CancelEdit()
        {
            IsEdit = false;
            Clear();
        }

        public void Clear()
        {
            GPA = null;
            NotifyPropertyChanged("GPA");

            Name = "";

            Number = null;
            NotifyPropertyChanged("Number");

            CreditHours = null;
            NotifyPropertyChanged("CreditHours");

            base.ResetFeedback();
        }

        public void ErrorCheckFields()
        {
            if(name == null || name.Length == 0)
            {
                ErrorField = "Name";

                return;
            }

            if (number == null)
            {
                ErrorField = "Number";

                return;
            }

            if(creditHours == null)
            {
                ErrorField = "CreditHours";

                return;
            }

            if (gpa == null || gpa.Length == 0)
            {
                ErrorField = "GPA";

                return;
            }
        }

        /// <summary>
        ///     Updates this model's properties to match the properties of the course
        /// </summary>
        /// <param name="course">The course to copy properties from</param>
        public void Update(Course course)
        {
            ResetFeedback();

            GPA = course.GPA.ToString();
            Name = course.Name;
            Number = course.Number;
            CreditHours = course.CreditHours;
        }

        public Course GetCourse()
        {
            ErrorCheckFields();

            switch (ErrorField)
            {
                case "Name":
                    throw new NullReferenceException("Course name required");
                case "Number":
                    throw new NullReferenceException("Course number required");
                case "CreditHours":
                    throw new NullReferenceException("Course credit hours required");
                case "GPA":
                    throw new NullReferenceException("Student's GPA in course required");
            }

            return new Course(creditHours.Value, Double.Parse(gpa), name, number.Value);
        }
    }
}