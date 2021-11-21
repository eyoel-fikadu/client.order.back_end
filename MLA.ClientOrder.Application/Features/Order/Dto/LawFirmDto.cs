using AutoMapper;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Domain.Values;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Dto
{
    public class LawFirmDto : IMapTo<LawFirmInvolved>, IMapFrom<LawFirmInvolved>
    {
        public string LawFirm { get; set; }
        public string Role { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<LawFirmDto, LawFirmInvolved>();
            profile.CreateMap<List<LawFirmDto>, List<LawFirmInvolved>>();

            profile.CreateMap<LawFirmInvolved, LawFirmDto>();
            profile.CreateMap<List<LawFirmInvolved>, List<LawFirmDto>>();
        }

    }
}
