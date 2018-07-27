using System;

namespace Assingment5
{
    class GraduateStudent : Student
    {
        public GraduateStudent(string id, string fName, string lName, int age, Gender gender) : base(id, fName, lName, age, gender)
        {
        }

        public override string ToString()
        {
            return base.ToString() + "\nGraduate";
        }

        protected override void CheckCourse(uint courseNum)
        {
            if (courseNum < 5000 || courseNum > 9999)
            {
                throw new ArgumentOutOfRangeException("courseNum", "Graduate students can only enroll in courses numbered 5000 to 9999 inclusive.");
            }
        }
    }
}
