using Assingment5.BindingConverters;
using Assingment5.ModelClasses;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Assingment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CourseModel courseModel;
        private StudentModel studentModel;
        private ListModel listModel;
        private TextBox studentFirstNameInput,
                        studentLastNameInput,
                        studentIdInput,
                        studentAgeInput,

                        courseNameInput,
                        courseNumInput,
                        courseHoursInput,
                        courseGpaInput;

        public MainWindow()
        {
            InitializeComponent();
            
            courseModel  = new CourseModel();
            studentModel = new StudentModel();
            listModel = new ListModel(studentModel, courseModel);

            try
            {
                AssignInput();
                BindAll();
            } catch (Exception ex)
            {
                studentModel.DisplayError(ex.Message);
            }
        }

        /// <summary>
        ///     Assigns various TextBoxes nested in templates to usable variables
        /// </summary>
        private void AssignInput()
        {
            studentFirstNameInput = GetInput(StudentFirstName) ?? throw new NullReferenceException("Could not find text input for student first name");
            studentLastNameInput  = GetInput(StudentLastName)  ?? throw new NullReferenceException("Could not find text input for student last name");
            studentIdInput        = GetInput(StudentID)        ?? throw new NullReferenceException("Could not find text input for student ID");
            studentAgeInput       = GetInput(StudentAge)       ?? throw new NullReferenceException("Could not find text input for student age");

            courseNameInput       = GetInput(CourseName)       ?? throw new NullReferenceException("Could not find text input for course name");
            courseNumInput        = GetInput(CourseNumber)     ?? throw new NullReferenceException("Could not find text input for course number");
            courseHoursInput      = GetInput(CourseHours)      ?? throw new NullReferenceException("Could not find text input for course credit hours");
            courseGpaInput        = GetInput(CourseGPA)        ?? throw new NullReferenceException("Could not find text input for course gpa");
        }

        /// <summary>
        ///     Attaches all bindings
        /// </summary>
        private void BindAll()
        {
            //Bind Forms
            StudentForm.DataContext = studentModel;
            CourseForm.DataContext = courseModel;
            //Bind student list and course list to listbox
            StudentList.DataContext = listModel;
            CourseList.DataContext = listModel;

            BindTextInputs();
        }

        /// <summary>
        ///     Sets the binding for all the text based inputs
        /// </summary>
        private void BindTextInputs()
        {
            BindTextInput(studentFirstNameInput, "FirstName",   studentModel);
            BindTextInput(studentLastNameInput,  "LastName",    studentModel);
            BindTextInput(studentIdInput,        "ID",          studentModel, BindingPropertyType.NumericalString);
            BindTextInput(studentAgeInput,       "Age",         studentModel, BindingPropertyType.Integer);

            BindTextInput(courseGpaInput,        "GPA",         courseModel,  BindingPropertyType.Double);
            BindTextInput(courseNameInput,       "Name",        courseModel);
            BindTextInput(courseNumInput,        "Number",      courseModel,  BindingPropertyType.Integer);
            BindTextInput(courseHoursInput,      "CreditHours", courseModel,  BindingPropertyType.Integer);
        }

        /// <summary>
        ///     Binds a single property to a TextBox
        /// </summary>
        /// <param name="textBox">The TextBox to be bound to the model</param>
        /// <param name="property">The property in the model that corresponds to the TextBox</param>
        /// <param name="model">The model to be bound to the TextBox</param>
        /// <param name="type">Type of the property being bound</param>
        /// <param name="errorDisplay">Model bound to the error display for the text input</param>
        private void BindTextInput(TextBox textBox, string property, object model, BindingPropertyType type = BindingPropertyType.String)
        {
            Binding b = new Binding(property)
            {
                Source = model,
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };

            switch (type)
            {
                case BindingPropertyType.Double:
                    b.Converter = new TextToDoubleText((FeedbackMessageModel)model, property);
                    break;
                case BindingPropertyType.Integer:
                    b.Converter = new TextToInt((FeedbackMessageModel)model, property);
                    break;
                case BindingPropertyType.NumericalString:
                    b.Converter = new TextToNumberText((FeedbackMessageModel)model, property);
                    break;
                default:
                    //no converter necessary 
                    break;
            }

            textBox.SetBinding(TextBox.TextProperty, b);
        }

        /// <summary>
        ///     Resets all form elements for courses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearCourseForm(object sender, RoutedEventArgs e)
        {
            if (courseModel.IsEdit)
            {
                courseModel.CancelEdit();
            }
            else
            {
                courseModel.Clear();
            }
        }

        /// <summary>
        ///     Resets all input elements for students
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearStudentForm(object sender, RoutedEventArgs e)
        {
            if (studentModel.IsEdit)
            {
                studentModel.CancelEdit();
            }
            else
            {
                studentModel.Clear();
            }
        }

        /// <summary>
        ///     Deletes a course from the course list when the delete button is pressed
        ///     code taken from https://timdams.com/2011/02/08/adding-buttons-to-databound-listbox-items-in-wpf/
        /// </summary>
        /// <param name="sender">The button pressed corresponding to the entry to be deleted</param>
        /// <param name="e"></param>
        private void DeleteCourse(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Course course)
            {
                listModel.RemoveCourse(course);
            }
        }

        /// <summary>
        ///     Deletes a student from the student list when the delete button is pressed
        ///     https://timdams.com/2011/02/08/adding-buttons-to-databound-listbox-items-in-wpf/
        /// </summary>
        /// <param name="sender">The button pressed corresponding to the entry to be deleted</param>
        /// <param name="e"></param>
        private void DeleteStudent(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Student deleted)
            {
                listModel.RemoveStudent(deleted);
            }
        }

        private void EditCourse(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Course editing)
            {
                listModel.ToggleEditCourse(editing);
            }
        }

        private void EditStudent(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is Student editing)
            {
                listModel.ToggleEditStudent(editing);
            }
        }

        /// <summary>
        ///     Appends a new course to the list of courses if the course form is filled out correctly
        /// </summary>
        /// <param name="sender">The "Add Course" button</param>
        /// <param name="e"></param>
        private void SetCourse(object sender, RoutedEventArgs e)
        {
            try
            {
                listModel.SetCourse(courseModel.GetCourse());
            }
            catch (Exception ex)
            {
                courseModel.DisplayError(ex.Message);
            }
        }

        /// <summary>
        ///     Appends a new student to the studentlist if the student form is filled out correctly
        /// </summary>
        /// <param name="sender">The "Add Student" button</param>
        /// <param name="e"></param>
        private void SetStudent(object sender, RoutedEventArgs e)
        {
            try
            {
                listModel.SetStudent(studentModel.GetStudent());
            }
            catch (Exception ex)
            {
                studentModel.DisplayError(ex.Message);
            }
        }

        /// <summary>
        ///     gets a TextBox object from an instance of the PlaceHolderInput template
        /// </summary>
        /// <param name="placeHolderUIElement">The PlaceHolderInput template containing the textbox</param>
        /// <returns>
        ///     A TextBox object representing the text input within the template
        ///     null on failure
        /// </returns>
        private TextBox GetInput(ContentControl placeHolderUIElement)
        {
            placeHolderUIElement.ApplyTemplate();
            return (TextBox)placeHolderUIElement.Template.FindName("Input", placeHolderUIElement);
        }
    }
}