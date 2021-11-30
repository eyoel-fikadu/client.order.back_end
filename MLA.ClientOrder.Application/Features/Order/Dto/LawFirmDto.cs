using AutoMapper;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Application.Features.Lookup.ViewModel;
using MLA.ClientOrder.Domain.Values;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Dto
{
    public class LawFirmDto : IMapTo<LawFirmInvolved>, IMapFrom<LawFirmInvolved>
    {
        public LookupVm LawFirm { get; set; }
        public string Role { get; set; }

        public LawFirmDto()
        {
        }

        public LawFirmDto(LookupVm lawFirm, string role)
        {
            LawFirm = lawFirm;
            Role = role;
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LawFirmDto, LawFirmInvolved>();
            profile.CreateMap<List<LawFirmDto>, List<LawFirmInvolved>>();

            profile.CreateMap<LawFirmInvolved, LawFirmDto>();
            profile.CreateMap<List<LawFirmInvolved>, List<LawFirmDto>>();
        }

    }
}
