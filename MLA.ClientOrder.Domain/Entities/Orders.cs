using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.ValueObjects;
using MLA.ClientOrder.Domain.Values;
using System;
using System.Collections.Generic;


namespace MLA.ClientOrder.Domain.Entities
{
    public class Orders : AuditableEntity
    {
        public Clients Client { get; set; }
        public string IdustrySector { get; set; }
        public Layers LeadLayer { get; set; }
        public List<Layers> OtherLayers { get; set; }
        public bool IsLawFirmInvolved { get; set; }
        public bool CroossJudiciaryExistt { get; set; }
        public List<LawFirmInvolved> LawFirmInvolved { get; set; }
        public List<CrossJudiciaries> CrossJudiciaries { get; set; }
        public string TransactionType { get; set; }
        public string TransactionDescription { get; set; }
        public string MatterDescription { get; set; }
        public double TransactionValue { get; set; }
        public bool IsConfidential { get; set; }
        public string ProjectStatus { get; set; }
        public string Remark { get; set; }
        public DateTime CompletedDate { get; set; }
        public DateTime StartedDate { get; set; }
    }
}
