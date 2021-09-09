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
    public class LawyersDto : IMapFrom<Lawyers>, IMapTo<Lawyers>
    {
        public Guid id { get; set; } 
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string role { get; set; }

        public void Mappings(Profile profile)
        {
            profile.CreateMap<LawyersDto, Lawyers>();
            profile.CreateMap<List<LawyersDto>, List<Lawyers>>();

            profile.CreateMap<Lawyers, LawyersDto>();
            profile.CreateMap<List<Lawyers>, List<LawyersDto>>();
        }
    }
}
