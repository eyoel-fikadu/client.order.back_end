using MLA.ClientOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.ValueObjects
{
    public class CrossJudiciaries : ValueObject
    {
        public string Judiciaries { get; set; }
        public CrossJudiciaries()
        {

        }
        public CrossJudiciaries(string judiciary)
        {
            this.Judiciaries = judiciary;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Judiciaries;
        }
    }
}
