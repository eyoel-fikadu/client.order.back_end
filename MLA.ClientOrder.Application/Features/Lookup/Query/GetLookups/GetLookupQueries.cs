using MediatR;
using MLA.ClientOrder.Application.Features.Lookup.ViewModel;
using System.Collections.Generic;

namespace MLA.ClientOrder.Application.Features.Lookup.Query
{
    public class GetLookupQueries : IRequest<List<LookupsViewModel>>
    {
    }
}
