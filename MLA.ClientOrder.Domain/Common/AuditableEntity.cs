using System;

namespace MLA.ClientOrder.Domain.Common
{
    public abstract class AuditableEntity
    {
        public Guid Id { get; set; }
        public bool IsActive { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Guid? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
    }
}
