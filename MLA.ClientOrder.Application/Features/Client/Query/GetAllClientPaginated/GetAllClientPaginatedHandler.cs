using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Mappings;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Query.GetAllClient
{
    public class GetAllClientPaginatedHandler : IRequestHandler<GetAllClientPaginatedCommand, PaginatedList<ClientViewModel>>
    {
        private readonly IApplicationDbContext context;

        public GetAllClientPaginatedHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<PaginatedList<ClientViewModel>> Handle(GetAllClientPaginatedCommand request, CancellationToken cancellationToken)
        {
            var clients = await context.Clients
                .OrderByDescending(x => x.Registration_Date)
                .PaginatedListAsync(request.PageNumber, request.PageSize);

            List<ClientViewModel> viewModels = new List<ClientViewModel>();
            clients.Items.ForEach(x => viewModels.Add(new ClientViewModel(x)));

            return new PaginatedList<ClientViewModel>(viewModels, clients.TotalCount, clients.PageIndex, request.PageSize);
        }
    }

}
