using System;

namespace NTestDataBuilder.Tests.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");

            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
