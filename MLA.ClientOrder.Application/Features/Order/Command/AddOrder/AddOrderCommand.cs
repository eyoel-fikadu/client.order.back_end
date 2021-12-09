using AutoMapper;
using MediatR;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Application.Features.Order.Dto;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Order.Command
{
    public class AddOrderCommand : IRequest<Guid>, IMapTo<Orders>
    {
        public string IdustrySector { get; set; }
        public Guid LeadLayerId { get; set; }
        public Guid ClientId { get; set; }
        public string OrderId { get; set; }
        public List<Guid> OtherLayers { get; set; }
        public bool IsLawFirmInvolved { get; set; }
        public bool CroossJudiciaryExistt { get; set; }
        public List<LawFirmDto> LawFirmInvolved { get; set; }
        public List<Guid> CrossJudiciaries { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public string MatterDescription { get; set; }
        public double TransactionValue { get; set; }
        public bool IsConfidential { get; set; }
        public string ProjectStatus { get; set; }
        public string Remark { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? CompletedDate { get; set; }
        public DateTime StartedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AddOrderCommand, Orders>()
                .ForMember(d => d.CrossJudiciaries, opt => opt.Ignore())
                .ForMember(d => d.LeadLayer, opt => opt.Ignore())
                .ForMember(d => d.AdditionalLawyers, opt => opt.Ignore())
                .ForMember(d => d.LawFirmInvolved, opt => opt.Ignore());
        }
    }
}
