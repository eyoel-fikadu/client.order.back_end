using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Features.Layer.Dto;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Layer.Query
{
    public class GetAllLawyersCommand : IRequest<List<LawyersDto>>
    {

    }

    public class GetAllLawyersHandler : IRequestHandler<GetAllLawyersCommand, List<LawyersDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper mapper;

        public GetAllLawyersHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<List<LawyersDto>> Handle(GetAllLawyersCommand request, CancellationToken cancellationToken)
        {
            var lawyers = await _context.Layers.ToListAsync();
            return mapper.Map<List<LawyersDto>>(lawyers);
        }
    }

}
