using System;

namespace NTestDataBuilder.Tests.Entities
{
    public class Customer
    {
        protected Customer() {}

        public Customer(string firstName, string lastName, int yearJoined)
        {
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");

            FirstName = firstName;
            LastName = lastName;
            YearJoined = yearJoined;
        }

        public int CustomerForHowManyYears(DateTime since)
        {
            if (since.Year < YearJoined)
                throw new ArgumentException("Date must be on year or after year that customer joined.", "since");
            return since.Year - YearJoined;
        }

        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual int YearJoined { get; private set; }
    }
}
