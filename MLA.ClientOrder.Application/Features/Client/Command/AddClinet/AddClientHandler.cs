using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Command.AddClinet
{
    public class AddClientHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddClientHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address1, request.Address2, request.City, request.State, request.Country, request.ZipCode);
            var client = new Clients(request.Client_name, request.Industry_sector, request.Contact_Person, request.Contact_person_Email_Address, request.Contact_person_Phone_Number, request.Registration_Date);
            client.Address = address;
            _context.Clients.Add(client);

            await _context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }
}
