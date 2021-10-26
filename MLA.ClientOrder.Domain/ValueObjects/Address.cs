using MLA.ClientOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.ValueObjects
{
    public class Address : ValueObject
    {
        public String Address1 { get; private set; }
        public String Address2 { get; private set; }
        public String City { get; private set; }
        public String State { get; private set; }
        public String Country { get; private set; }
        public String ZipCode { get; private set; }

        public Address() { }

        public Address(string address1, string address2, string city, string state, string country, string zipCode)
        {
            Address1 = address1;
            Address2 = address2;
            City = city;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Address2;
            yield return Address1;
            yield return City;
            yield return State;
            yield return Country;
            yield return ZipCode;
        }
    }
}
