using AutoMapper;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Layer.Dto
{
    public class LayersDto : IMapFrom<Layers>, IMapTo<Layers>
    {
        public Guid guid { get; set; } 
        public string firstName { get; set; }
        public string lastName { get; set; }

        public void Mappings(Profile profile)
        {
            profile.CreateMap<LayersDto, Layers>();
            profile.CreateMap<List<LayersDto>, List<Layers>>();

            profile.CreateMap<Layers, LayersDto>();
            profile.CreateMap<List<Layers>, List<LayersDto>>();
        }
    }
}
