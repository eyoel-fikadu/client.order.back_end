using MediatR;
using System;

namespace MLA.ClientOrder.Application.Features.Client.Command
{
    public class AddClientCommand : IRequest<Guid>
    {
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

    }
}
