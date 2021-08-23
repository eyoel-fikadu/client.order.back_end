using AutoMapper;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Dto
{
    public class ClientDto : IMapFrom<Clients>
    {
        public Guid id { get; set; }
        public string client_id { get; set; }
        public string clinet_name { get; set; }

        public void Mappings(Profile profile)
        {
            profile.CreateMap<List<Clients>, List<ClientDto>>();
        }
    }
}
