using System;

namespace Assingment5
{
    class UndergraduateStudent : Student
    {
        public UndergraduateStudent(string id, string fName, string lName, int age, Gender gender) : base(id, fName, lName, age, gender)
        {

        }

        public override string ToString()
        {
            return base.ToString() + "\nUndergraduate";
        }

        protected override void CheckCourse(uint courseNum)
        {
            if (courseNum < 1000 || courseNum > 4999)
            {
                throw new ArgumentOutOfRangeException("courseNum", "Undergrads can only enroll in courses numbered 1000 to 4999 inclusive.");
            }
        }
    }
}
