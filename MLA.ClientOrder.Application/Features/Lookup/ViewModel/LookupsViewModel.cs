using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Lookup.ViewModel
{
    public class LookupsViewModel
    {
        public LookupEnums type { get; set; }
        public List<LookupVm> Values { get; set; }

        public LookupsViewModel(LookupEnums type,List<Lookups> lookups)
        {
            this.type = type;
            Values = new List<LookupVm>();
            lookups.ForEach(x =>
            {
                Values.Add(new LookupVm() { id = x.Id, value = x.Name });
            });
        }
    }

    public class LookupVm
    {
        public Guid id { get; set; }
        public string value { get; set; }
    }
}
