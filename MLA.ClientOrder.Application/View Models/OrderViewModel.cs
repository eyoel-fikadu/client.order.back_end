using AutoMapper;
using MLA.ClientOrder.Application.Features.Client.Dto;
using MLA.ClientOrder.Application.Features.Layer.Dto;
using MLA.ClientOrder.Application.Features.Lookup.ViewModel;
using MLA.ClientOrder.Application.Features.Order.Dto;
using MLA.ClientOrder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MLA.ClientOrder.Application.View_Models
{
    public class OrderViewModel : BaseViewModel<Orders>
    {
        public string IdustrySector { get; set; }
        public string OrderId { get; set; }
        public ClientDto ClientDto { get; set; }
        public LawyersDto LeadLayer { get; set; }
        public List<LawyersDto> OtherLayers { get; set; }
        public bool IsLawFirmInvolved { get; set; }
        public bool CroossJudiciaryExistt { get; set; }
        public List<LawFirmDto> LawFirmInvolved { get; set; }
        public List<LookupVm> CrossJudiciaries { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public string MatterDescription { get; set; }
        public double TransactionValue { get; set; }
        public bool IsConfidential { get; set; }
        public string Currency { get; set; }
        public bool IsTransaction { get; set; }
        public string ProjectStatus { get; set; }
        public string Remark { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime StartedDate { get; set; }


        public OrderViewModel(Orders orders, IMapper mapper, List<Lookups> mapValues, List<Lawyers> lawyers) : base(orders)
        {
            this.LawFirmInvolved = orders.LawFirmInvolved?
                .Select(x => new LawFirmDto(new LookupVm() 
                { 
                    id = x.LawFirmId, 
                    value = mapValues.FirstOrDefault(y => y.Id == x.LawFirmId)?.Name
                }, x.Role))
                .ToList();
            this.CrossJudiciaries = orders.CrossJudiciaries?
                .Select(x => new LookupVm() 
                { 
                    id = x.JudiciariesId,
                    value = mapValues.FirstOrDefault(y => y.Id == x.JudiciariesId)?.Name
                })
                .ToList();
            this.OtherLayers = orders.AdditionalLawyers?
                .Select(x => new LawyersDto(x.LawyersId, lawyers.FirstOrDefault(y => y.Id == x.LawyersId)))
                .ToList();
            this.LeadLayer = mapper.Map<LawyersDto>(orders.LeadLayer);
            
            this.ClientDto = new ClientDto(orders.Client);
        }
    }
}
