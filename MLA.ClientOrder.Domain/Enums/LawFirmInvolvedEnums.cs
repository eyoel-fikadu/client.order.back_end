using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Domain.Enums
{
    public enum LawFirmInvolvedEnums
    {
        [Display(Name = "Law Firm Involved 1")]
        LawFirm1,
        [Display(Name = "Law Firm Involved 2")]
        LawFirm2
    }
}
