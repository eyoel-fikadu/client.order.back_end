﻿using MLA.ClientOrder.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Layers : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
