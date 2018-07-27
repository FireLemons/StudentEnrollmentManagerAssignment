using System;

namespace Assingment5
{
    class Course
    {
        private string name;
        private uint number,
                     creditHours;
        private double gpa;

        public Course(uint creditHours, double gpa, string name, uint number)
        {
            Update(creditHours, gpa, name, number);
        }

        public uint CreditHours
        {
            get => creditHours;
        }

        public double GPA
        {
            get => gpa;
        }

        public string Name
        {
            get => name;
        }

        public uint Number
        {
            get => number;
        }

        public void Update(uint creditHours, double gpa, string name, uint number)
        {
            this.creditHours = creditHours;
            this.gpa = gpa;
            this.name = name ?? throw new ArgumentNullException("name", "Course name cannot be null");
            this.number = number;
        }

        public override string ToString()
        {
            return String.Format(
                "Name         = {0}\n" +
                "Number       = {1}\n" +
                "Credit Hours = {2}\n" +
                "GPA          = {3}",
            name, number, creditHours, gpa);
        }
    }
}
