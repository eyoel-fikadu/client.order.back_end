using AutoMapper;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Client.Dto
{
    public class ClientDto : IMapFrom<Clients>
    {
        public Guid id { get; set; }
        public string clinet_name { get; set; }
        public string Industry_sector { get; set; }

        public void Mappings(Profile profile)
        {
            profile.CreateMap<List<Clients>, List<ClientDto>>();
            profile.CreateMap<Clients, ClientDto>();
        }

        public ClientDto()
        {

        }
        public ClientDto(Clients client)
        {
            if (client == null) return;
            id = client.Id;
            clinet_name = client.Client_name;
        }
    }
}
