using MediatR;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;

namespace MLA.ClientOrder.Application.Features.Client.Query.GetAllClient
{
    public class GetAllClientPaginatedCommand : IRequest<PaginatedList<ClientViewModel>>
    {
        public int ListId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
