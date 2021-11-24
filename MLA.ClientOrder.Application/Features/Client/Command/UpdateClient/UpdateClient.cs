using AutoMapper;
using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Application.Common.Exceptions;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Command
{
    public class UpdateClient
    {
        public class UpdateClinetCommand : IRequest
        {
            public Guid guid { get; set; }
            public string Client_name { get; set; }
            public string Address2 { get; set; }
            public string Address1 { get; set; }
            public string State { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string ZipCode { get; set; }
            public string Industry_sector { get; set; }
            public string Contact_Person { get; set; }
            public string Contact_person_Email_Address { get; set; }
            public string Contact_person_Phone_Number { get; set; }
            public DateTime Registration_Date { get; set; }
            public bool isActive { get; set; }
        }

        public class UpdateClinetCommandHandler : IRequestHandler<UpdateClinetCommand>
        {
            private readonly IApplicationDbContext _context;
            private readonly IMapper _mapper;

            public UpdateClinetCommandHandler(IApplicationDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(UpdateClinetCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Clients.FindAsync(request.guid);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Clients), request.guid);
                }

                _mapper.Map(request, entity);
                entity.Address = new Address(request.Address1, request.Address2, request.City, request.State, request.Country, request.ZipCode);

                _context.Clients.Update(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
