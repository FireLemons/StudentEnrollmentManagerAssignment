using System;
using System.ComponentModel;

namespace Assingment5.ModelClasses
{
    class StudentModel : FeedbackMessageModel
    {

        private bool? isGrad;
        private bool isEdit;
        private int? age;
        private string id,
                       firstName,
                       lastName;
        private Gender? gender;

        public StudentModel()
        {
            firstName = "";
            lastName = "";
        }
        
        public bool IsEdit
        {
            get => isEdit;
            set
            {
                if(isEdit != value)
                {
                    isEdit = value;
                    NotifyPropertyChanged("IsEdit");
                }
            }
        }

        public bool? IsGrad
        {
            get => isGrad;
            set
            {
                if (isGrad != value)
                {
                    isGrad = value;
                    NotifyPropertyChanged("IsGrad");
                }
            }
        }

        public int? Age
        {
            get => age;
            set
            {
                if (age != value)
                {
                    age = value;
                    NotifyPropertyChanged("Age");
                }
            }
        }

        public string ID
        {
            get => id;
            set
            {
                if (id != value)
                {
                    id = value;
                    NotifyPropertyChanged("ID");
                }
            }
        }

        public string FirstName
        {
            get => firstName;
            set
            {
                if (firstName != value)
                {
                    firstName = value;
                    NotifyPropertyChanged("FirstName");
                }
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                if (lastName != value)
                {
                    lastName = value;
                    NotifyPropertyChanged("LastName");
                }
            }
        }

        public Gender? Gender
        {
            get => gender;
            set
            {
                if (gender != value)
                {
                    gender = value;
                    NotifyPropertyChanged("Gender");
                }
            }
        }

        public void CancelEdit()
        {
            IsEdit = false;
            Clear();
        }

        /// <summary>
        ///     Clears the student form and 
        /// </summary>
        public void Clear()
        {
            IsGrad = null;

            Age = null;
            NotifyPropertyChanged("Age");

            ID = "";
            FirstName = "";
            LastName = "";

            Gender = null;

            base.ResetFeedback();
        }
        
        private void ErrorCheckFields()
        {
            if (firstName == null || firstName.Length == 0)
            {
                ErrorField = "FirstName";

                return;
            }

            if (lastName == null || lastName.Length == 0)
            {
                ErrorField = "LastName";

                return;
            }

            if (id == null || id.Length == 0)
            {
                ErrorField = "ID";

                return;
            }

            if (age == null)
            {
                ErrorField = "Age";

                return;
            }

            if (Gender == null)
            {
                ErrorField = "Gender";

                return;
            }

            if (isGrad == null)
            {
                ErrorField = "IsGrad";
            }
        }

        public void Update(Student s)
        {
            if(s is GraduateStudent)
            {
                IsGrad = true;
            }
            else if (s is UndergraduateStudent)
            {
                IsGrad = false;
            }
            else
            {
                IsGrad = null;
            }

            Age       = s.Age;
            ID        = s.ID;
            FirstName = s.FirstName;
            LastName  = s.LastName;
            Gender    = s.Gender;
        }

        /// <summary>
        ///     Converts the model to an object of the appropriate subclass of Student
        /// </summary>
        /// <returns>
        ///     If isGrad is true a GraduateStudent object
        ///     If isGrad is false an UndergraduateStudent object 
        /// </returns>
        public Student GetStudent()
        {
            ErrorCheckFields();
            switch (ErrorField)
            {
                case null:
                    break;
                case "FirstName":
                    throw new NullReferenceException("Student's first name required");
                case "LastName":
                    throw new NullReferenceException("Student's last name required");
                case "ID":
                    throw new NullReferenceException("Student's ID of student required");
                case "Age":
                    throw new NullReferenceException("Student's age required");
                case "Gender":
                    throw new NullReferenceException("Student's gender must be selected");
                case "IsGrad":
                    throw new NullReferenceException("Student's graduate level must be selected");
            }

            if (isGrad.Value)
            {
                return new GraduateStudent(id, firstName, lastName, age.Value, Gender.Value);
            }
            else
            {
                return new UndergraduateStudent(id, firstName, lastName, age.Value, Gender.Value);
            }
        }
    }
}