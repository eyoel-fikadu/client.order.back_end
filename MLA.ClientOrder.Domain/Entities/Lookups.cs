using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Lookups: AuditableEntity
    {
        public String Name { get; set; }
        public LookupEnums Type { get; set; }
    }
}
