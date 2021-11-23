using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Features.Lookup.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Lookup.Query.GetLookups
{
    public class GetLookupQueriesHandler : IRequestHandler<GetLookupQueries, List<LookupsViewModel>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetLookupQueriesHandler> _logger;

        public GetLookupQueriesHandler(IApplicationDbContext context, IMapper mapper, ILogger<GetLookupQueriesHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<LookupsViewModel>> Handle(GetLookupQueries request, CancellationToken cancellationToken)
        {
            var lookups = await _context.Lookups.ToListAsync();
                
            var lkup = lookups.AsEnumerable().GroupBy(x => x.Type).ToList();
            List<LookupsViewModel> models = new List<LookupsViewModel>();
            lkup.ForEach(x =>
            {
                models.Add(new LookupsViewModel(x.Key, x.ToList()));
            });
            
            return models;
        }
    }
}
