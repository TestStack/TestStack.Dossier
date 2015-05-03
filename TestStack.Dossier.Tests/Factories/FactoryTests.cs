using System;
using Shouldly;
using TestStack.Dossier.Factories;
using TestStack.Dossier.Tests.Stubs.Entities;
using TestStack.Dossier.Tests.Stubs.ViewModels;
using Xunit;

namespace TestStack.Dossier.Tests.Factories
{
    public class FactoryTests
    {
        [Fact]
        public void GivenAllPropertiesFactory_WhenBuilding_ThenAllPropertiesSet()
        {
            InstructorViewModel instructor = Builder<InstructorViewModel>.CreateNew(new AllPropertiesFactory());

            // ctor properties
            instructor.Id.ShouldNotBe(Guid.Empty);
            instructor.FirstName.ShouldNotBe(null);
            instructor.LastName.ShouldNotBe(null);

            // public properties
            instructor.Room.ShouldNotBe(null);
            instructor.NumberOfStudents.ShouldNotBe(0);

            // private properties
            instructor.Subject.ShouldNotBe(null);
            instructor.YearsAtSchool.ShouldNotBe(0);
        }

        [Fact]
        public void GivenAutoFixtureFactory_WhenBuilding_ThenOnlyConstructorAndPublicPropertiesSet()
        {
            InstructorViewModel instructor = Builder<InstructorViewModel>.CreateNew(new AutoFixtureFactory());

            // ctor properties
            instructor.Id.ShouldNotBe(Guid.Empty);
            instructor.FirstName.ShouldNotBe(null);
            instructor.LastName.ShouldNotBe(null);

            // public properties
            instructor.Room.ShouldNotBe(null);
            instructor.NumberOfStudents.ShouldNotBe(0);

            // private properties
            instructor.Subject.ShouldBe(null);
            instructor.YearsAtSchool.ShouldBe(0);
        }

        [Fact]
        public void GivenConstructorPropertiesFactory_WhenBuilding_ThenOnlyConstructorPropertiesSet()
        {
            InstructorViewModel instructor = Builder<InstructorViewModel>.CreateNew(new ConstructorFactory());

            // ctor properties
            instructor.Id.ShouldNotBe(Guid.Empty);
            instructor.FirstName.ShouldNotBe(null);
            instructor.LastName.ShouldNotBe(null);

            // public properties
            instructor.Room.ShouldBe(null);
            instructor.NumberOfStudents.ShouldBe(0);

            // private properties
            instructor.Subject.ShouldBe(null);
            instructor.YearsAtSchool.ShouldBe(0);
        }

        [Fact]
        public void GivenPublicPropertiesFactory_WhenBuilding_ThenOnlyConstructorAndPublicPropertiesSet()
        {
            InstructorViewModel instructor = Builder<InstructorViewModel>.CreateNew(new PublicPropertiesFactory());

            // ctor properties
            instructor.Id.ShouldNotBe(Guid.Empty);
            instructor.FirstName.ShouldNotBe(null);
            instructor.LastName.ShouldNotBe(null);
            
            // public properties
            instructor.Room.ShouldNotBe(null);
            instructor.NumberOfStudents.ShouldBeGreaterThan(0);

            // private properties
            instructor.Subject.ShouldBe(null);
            instructor.YearsAtSchool.ShouldBe(0);
        }
    }
}
