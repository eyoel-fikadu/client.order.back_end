using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.ValueObjects
{
    public class AdditionalLawyers : ValueObject
    {
        public Lawyers Lawyers { get; set; } = new Lawyers();
        public Guid LawyersId { get; set; }
        public AdditionalLawyers()
        {

        }
        public AdditionalLawyers(Lawyers lawyers)
        {
            this.Lawyers = lawyers;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Lawyers;
        }
    }
}
