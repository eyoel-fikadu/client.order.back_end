using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.Values
{
    public class LawFirmInvolved : ValueObject
    {
        public Lookups LawFirm { get; set; }
        public string Role { get; set; }

        public LawFirmInvolved()
        {

        }
        public LawFirmInvolved(Lookups lawFirm, string role)
        {
            this.LawFirm = lawFirm;
            this.Role = role;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return LawFirm;
            yield return Role;
        }
    }
}
