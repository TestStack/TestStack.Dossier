using System;

namespace TestStack.Dossier.Tests.Stubs.ViewModels
{
    public class InstructorViewModel
    {
        public InstructorViewModel(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; private set; }

        public string LastName { get; set; }
        public string FirstName { get; private set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Room{ get; set; }

        public string Subject{ get; private set; }
        public int YearsAtSchool { get; private set; }
        public int NumberOfStudents { get; set; }
    }
}
