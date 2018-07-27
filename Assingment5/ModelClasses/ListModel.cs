using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Assingment5.ModelClasses
{
    class ListModel : INotifyPropertyChanged
    {
        private Course      selectedCourse;
        private CourseModel courseModel;
        private Student      selectedStudent;
        private StudentModel studentModel;
        private ObservableCollection<Course> courseList;
        private ObservableCollection<Student> studentList;

        public ListModel(StudentModel studentModel, CourseModel courseModel)
        {
            this.courseModel = courseModel;
            this.studentModel = studentModel;
            courseList = new ObservableCollection<Course>();
            studentList = new ObservableCollection<Student>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                if (selectedStudent != value)
                {
                    selectedStudent = value;

                    if (selectedStudent != null)
                    {
                        studentModel.Update(selectedStudent);
                        courseList.Clear();

                        foreach (Course c in value.Courses)
                        {
                            courseList.Add(c);
                        }
                    }

                    courseModel.IsEdit = false;
                    studentModel.IsEdit = false;
                }
            }
        }

        public Course SelectedCourse
        {
            get => selectedCourse;
            set
            {
                if (selectedCourse != value)
                {
                    selectedCourse = value;
                    
                    if (value != null)
                    {
                        courseModel.Update(selectedCourse);
                    }
                    
                    courseModel.IsEdit = false;
                }
            }
        }

        public ObservableCollection<Course> CourseList
        {
            get => courseList;
        }

        public ObservableCollection<Student> StudentList
        {
            get => studentList;
        }

        public void RemoveCourse(Course c)
        {
            if (c.Equals(SelectedCourse))
            {
                SelectedCourse = null;
            }

            courseList.Remove(c);
            courseModel.IsEdit = false;
            courseModel.DisplayMessage("Course Deleted");
        }

        public void RemoveStudent(Student s)
        {
            if (s.Equals(SelectedStudent))
            {
                SelectedStudent = null;
                CourseList.Clear();
            }

            studentList.Remove(s);
            studentModel.IsEdit = false;
            studentModel.DisplayMessage("Student Deleted");
        }

        public void SetCourse(Course c)
        {
            if (courseModel.IsEdit)
            {
                Course newCourse = new Course(c.CreditHours, c.GPA, c.Name, c.Number);
                courseList[courseList.IndexOf(selectedCourse)] = newCourse;
                courseModel.DisplayMessage("Edited Course");

                courseModel.IsEdit = false;
            }
            else
            {
                if (selectedStudent == null)
                {
                    throw new NullReferenceException("No student is selected to add the course to");
                }

                selectedStudent.AddCourse(c);
                courseList.Add(c);

                courseModel.Clear();
                courseModel.DisplayMessage("Added Course");
            }
        }

        public void SetStudent(Student s)
        {
            if (studentModel.IsEdit)
            {
                Student newStudent;

                if (studentModel.IsGrad.Value)
                {
                    newStudent = new GraduateStudent(s.ID, s.FirstName, s.LastName, s.Age, s.Gender);
                }
                else
                {
                    newStudent = new UndergraduateStudent(s.ID, s.FirstName, s.LastName, s.Age, s.Gender);
                }

                newStudent.Courses = selectedStudent.Courses;

                studentList[studentList.IndexOf(selectedStudent)] = newStudent;
                studentModel.DisplayMessage("Edited Student");

                studentModel.IsEdit = false;
            }
            else
            {
                studentList.Add(s);

                studentModel.Clear();
                studentModel.DisplayMessage("Added Student");
            }
        }

        public void ToggleEditCourse(Course c)
        {
            SelectedCourse = c;
            courseModel.Update(c);
            courseModel.IsEdit = true;
        }

        public void ToggleEditStudent(Student s)
        {
            SelectedStudent = s;
            studentModel.Update(s);
            studentModel.IsEdit = true;
        }

        public void NotifyPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}