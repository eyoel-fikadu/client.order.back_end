using MLA.ClientOrder.Domain.Common;

namespace MLA.ClientOrder.Domain.Entities
{
    public class UserDetails : AuditableEntity
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
