namespace Assingment5
{
    abstract class Person
    {
        private string firstName;
        private string lastName;
        private Gender gender;
        private int age;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
            }
        }

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
            }
        }

        public Gender Gender
        {
            get => gender;
            set
            {
                gender = value;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                age = value;
            }
        }
    }
}