using System;

namespace TestStack.Dossier.Tests.Stubs.ViewModels
{
    public class InstructorViewModel
    {
        public InstructorViewModel(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public int Id { get; private set; }

        public string LastName { get; private set; }
        public string FirstName { get; private set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime JoinDate { get; set; }

        public Grade Grade { get; set; }
    }
}
