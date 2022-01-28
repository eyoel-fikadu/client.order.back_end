using MLA.ClientOrder.Domain.Common;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Lawyers : AuditableEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }

    }
}
