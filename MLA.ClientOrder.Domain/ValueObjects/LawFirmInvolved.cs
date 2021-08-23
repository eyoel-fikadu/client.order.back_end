using MLA.ClientOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.Values
{
    public class LawFirmInvolved : ValueObject
    {
        public string LawFirm { get; set; }
        public string Role { get; set; }

        public LawFirmInvolved()
        {

        }
        public LawFirmInvolved(string lawFirm, string role)
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
