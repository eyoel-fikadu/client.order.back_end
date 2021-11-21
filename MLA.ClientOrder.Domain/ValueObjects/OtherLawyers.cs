using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.ValueObjects
{
    public class OtherLawyers : ValueObject
    {
        public Guid OrderId;
        public Orders Order;

        public Guid LawyerId;
        public Lawyers Lawyer;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Order;
            yield return OrderId;
            yield return Lawyer;
            yield return LawyerId;
        }
    }
}
