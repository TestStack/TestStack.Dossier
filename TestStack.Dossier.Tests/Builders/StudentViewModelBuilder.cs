using System;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.Stubs.ViewModels;

namespace TestStack.Dossier.Tests.Builders
{
    public class StudentViewModelBuilder : TestDataBuilder<StudentViewModel, StudentViewModelBuilder>
    {
        public virtual StudentViewModelBuilder WithFirstName(string firstName)
        {
            return Set(x => x.FirstName, firstName);
        }

        public virtual StudentViewModelBuilder WithLastName(string lastName)
        {
            return Set(x => x.LastName, lastName);
        }

        public virtual StudentViewModelBuilder WhoEntrolledIn(DateTime enrollmentDate)
        {
            return Set(x => x.EnrollmentDate, enrollmentDate);
        }

        protected override StudentViewModel BuildObject()
        {
            return BuildUsing<AllPropertiesFactory>();
        }
    }
}
