using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Query.GetAllClinetNonPaginated
{
    public class GetAllClientHandler : IRequestHandler<GetAllClientQuery, List<ClientViewModel>>
    {
        private readonly IApplicationDbContext context;

        public GetAllClientHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<ClientViewModel>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
        {
            var clients = await context.Clients.OrderBy(x => x.Client_name).ToListAsync();

            List<ClientViewModel> viewModels = new List<ClientViewModel>();
            clients.ForEach(x => viewModels.Add(new ClientViewModel(x)));
            return viewModels;
        }
    }
}
