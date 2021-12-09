using MLA.ClientOrder.Domain.Common;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Lawyers : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

    }
}
