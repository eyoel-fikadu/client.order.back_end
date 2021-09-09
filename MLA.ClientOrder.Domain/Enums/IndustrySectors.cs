using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.Enums
{
    public enum IndustrySectors
    {
        [Display(Name = "Industry Sector 1")]
        Industry1,
        [Display(Name = "Industry Sector 2")]
        Industry2
    }
}
