using System;
using System.Collections.Generic;

namespace Assingment5
{
    class Student : Person
    {
        private string id;
        private List<Course> courses;

        public Student(string id, string fName, string lName, int age, Gender gender)
        {
            this.ID = id ?? throw new ArgumentNullException("id, Id cannot be null");
            this.FirstName = fName ?? throw new ArgumentNullException("fName", "First name cannot be null");
            this.LastName = lName ?? throw new ArgumentNullException("fName", "Last name cannot be null");
            this.Age = age;
            this.Gender = gender;

            courses = new List<Course>();
        }

        public string ID
        {
            get => id;
            set => id = value;
        }

        public List<Course> Courses
        {
            get => courses;
            set => courses = value;
        }

        public void AddCourse(Course course)
        {
            CheckCourse(course.Number);
            Courses.Add(course);
        }

        public void DropCourse(int index)
        {
            Courses.RemoveAt(index);
        }

        public void EditCourse(double gpa, int index, string courseName, uint courseNum, uint courseHours)
        {
            CheckCourse(courseNum);
            Courses[index].Update(courseHours, gpa, courseName, courseNum);
        }

        public override string ToString()
        {
            return String.Format(
                "Name = {0} {1}\n" +
                "ID = {2}\n" +
                "Gender = {3}\n" +
                "Age = {4}",
            FirstName, LastName, ID, Gender, Age);
        }

        protected virtual void CheckCourse(uint courseNum)
        {
        }
    }
}
