using AutoMapper;
using MLA.ClientOrder.Application.Features.Client.Dto;
using MLA.ClientOrder.Application.Features.Layer.Dto;
using MLA.ClientOrder.Application.Features.Order.Dto;
using MLA.ClientOrder.Domain.Entities;
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
        public List<string> CrossJudiciaries { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public string MatterDescription { get; set; }
        public double TransactionValue { get; set; }
        public bool IsConfidential { get; set; }
        public string ProjectStatus { get; set; }
        public string Remark { get; set; }
        public string CompletedDate { get; set; }
        public string StartedDate { get; set; }


        public OrderViewModel(Orders orders, IMapper mapper) : base(orders)
        {
            this.LawFirmInvolved = mapper.Map<List<LawFirmDto>>(orders.LawFirmInvolved);
            this.CrossJudiciaries = orders.CrossJudiciaries.Select(x => x.Judiciaries).ToList();
            this.LeadLayer = mapper.Map<LawyersDto>(orders.LeadLayer);
            this.OtherLayers = mapper.Map<List<LawyersDto>>(orders.OtherLawyers.Select(x => x.Lawyer).ToList());
            this.ClientDto = new ClientDto(orders.Client);
        }
    }
}
