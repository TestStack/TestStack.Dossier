using System;

namespace TestStack.Dossier.Tests.Entities
{
    public class Customer
    {
        protected Customer() {}

        public Customer(string identifier, string firstName, string lastName, int yearJoined, CustomerClass customerClass)
        {
            if (string.IsNullOrEmpty(identifier))
                throw new ArgumentNullException("identifier");
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentNullException("firstName");
            if (string.IsNullOrEmpty(lastName))
                throw new ArgumentNullException("lastName");

            Identifier = identifier;
            FirstName = firstName;
            LastName = lastName;
            YearJoined = yearJoined;
            CustomerClass = customerClass;
        }

        public virtual int CustomerForHowManyYears(DateTime since)
        {
            if (since.Year < YearJoined)
                throw new ArgumentException("Date must be on year or after year that customer joined.", "since");
            return since.Year - YearJoined;
        }

        public virtual string Identifier { get; private set; }
        public virtual string FirstName { get; private set; }
        public virtual string LastName { get; private set; }
        public virtual int YearJoined { get; private set; }
        public virtual CustomerClass CustomerClass { get; private set; }
    }
}
