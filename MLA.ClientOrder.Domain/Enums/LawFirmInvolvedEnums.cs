using System.ComponentModel.DataAnnotations;

namespace MLA.ClientOrder.Domain.Enums
{
    public enum LawFirmInvolvedEnums
    {
        [Display(Name = "DLA piper LLP")]
        DLA,
        [Display(Name = "Bowmans")]
        BOWMANS,
        [Display(Name = "Baker And Mckenzie")]
        BAKER,
        [Display(Name = "Anje Law Firm")]
        ANJE,
        [Display(Name = "FM Legal")]
        FM,
        [Display(Name = "JunHe LLP")]
        JUNHE
    }
}
