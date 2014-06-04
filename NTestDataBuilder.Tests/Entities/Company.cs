namespace NTestDataBuilder.Tests.Entities
{
    public class Company
    {
        protected Company() { }

        public Company(string name, int employeeCount)
        {
            Name = name;
            EmployeeCount = employeeCount;
        }

        public virtual string Name { get; private set; }
        public int EmployeeCount { get; private set; }
    }
}
