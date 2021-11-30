using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Domain.ValueObjects
{
    public class CrossJudiciaries : ValueObject
    {
        public Lookups Judiciaries { get; set; } = new Lookups();
        public Guid JudiciariesId { get; set; }
        public CrossJudiciaries()
        {

        }
        public CrossJudiciaries(Lookups judiciary)
        {
            this.Judiciaries = judiciary;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Judiciaries;
        }
    }
}
