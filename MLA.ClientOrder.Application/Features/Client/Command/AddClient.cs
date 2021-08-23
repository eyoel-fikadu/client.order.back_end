using FluentValidation;
using MediatR;
using MLA.ClientOrder.Application.Common.Abstraction;
using MLA.ClientOrder.Domain.Entities;
using MLA.ClientOrder.Domain.ValueObjects;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Command
{
    public class AddClientCommand : IRequest<Guid>
    {
        public string Client_ID { get; set; }
        public string Client_name { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Industry_sector { get; set; }
        public string Contact_Person { get; set; }
        public string Contact_person_Email_Address { get; set; }
        public string Contact_person_Phone_Number { get; set; }
        public DateTime Registration_Date { get; set; }

    }

    public class AddClientHandler : IRequestHandler<AddClientCommand, Guid>
    {
        private readonly IApplicationDbContext _context;

        public AddClientHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddClientCommand request, CancellationToken cancellationToken)
        {
            var address = new Address(request.Address, request.City, request.State, request.Country, request.ZipCode);
            var client = new Clients(request.Client_ID, request.Client_name, request.Industry_sector, request.Contact_Person, request.Contact_person_Email_Address, request.Contact_person_Phone_Number, request.Registration_Date);
            client.Address = address;
            _context.Clients.Add(client);

            await _context.SaveChangesAsync(cancellationToken);

            return client.Id;
        }
    }

    public class AddClientValidator : AbstractValidator<AddClientCommand>
    {

    }
}
