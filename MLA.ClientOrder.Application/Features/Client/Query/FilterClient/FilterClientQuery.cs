using MediatR;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Client.Query.FilterClient
{
    public class FilterClientQuery : IRequest<List<ClientViewModel>>
    {
        public string Country { get; set; }
        public string State { get; set; }
        public bool IsActive { get; set; }
    }
}
