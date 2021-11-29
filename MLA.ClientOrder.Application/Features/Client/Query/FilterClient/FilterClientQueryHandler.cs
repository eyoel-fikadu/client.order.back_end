using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Application.View_Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Query.FilterClient
{
    public class FilterClientQueryHandler : IRequestHandler<FilterClientQuery, List<ClientViewModel>>
    {
        private readonly IApplicationDbContext context;

        public FilterClientQueryHandler(IApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<List<ClientViewModel>> Handle(FilterClientQuery request, CancellationToken cancellationToken)
        {
            var clients = await context.Clients
                 .Where(x =>
                    (string.IsNullOrEmpty(request.Country) || x.Address.Country.Trim() == request.Country.Trim())
                    && (string.IsNullOrEmpty(request.State) || x.Address.State.Trim() == request.State.Trim())
                )
                 .OrderBy(x => x.Client_name).ToListAsync();

            List<ClientViewModel> viewModels = new List<ClientViewModel>();
            clients.ForEach(x => viewModels.Add(new ClientViewModel(x)));
            return viewModels;
        }
    }
}
