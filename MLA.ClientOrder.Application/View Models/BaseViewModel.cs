using MLA.ClientOrder.Domain.Common;
using System;

namespace MLA.ClientOrder.Application.View_Models
{
    public abstract class BaseViewModel<T> where T : AuditableEntity
    {
        public BaseViewModel(T entity)
        {
            Id = entity.Id;
            CreatedDate = entity.CreatedDate;
            IsActive = entity.IsActive;
            CreatedByUser = entity.CreatedBy;
        }
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public bool IsActive { get; protected set; }
        public Guid CreatedByUser { get; protected set; }
    }
}
