using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStack.Dossier.Tests.TestHelpers.Objects.Entities
{
    public class Address
    {
        protected Address() { }

        public Address(string identifier, int streetNo, string streetName, string suburb, string city, string postCode)
        {
            Identifier = identifier;
            StreetNo = streetNo;
            StreetName = streetName;
            Suburb = suburb;
            City = city;
            PostCode = postCode;
        }

        public string Identifier { get; private set; }
        public virtual int StreetNo { get; private set; }
        public string StreetName { get; private set; }
        public string Suburb { get; private set; }
        public string City { get; private set; }
        public string PostCode { get; private set; }
    }
}
