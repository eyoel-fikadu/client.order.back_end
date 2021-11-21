using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.ValueObjects;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Lawyers : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }

        public List<OtherLawyers> OtherLayers { get; set; }
    }
}
