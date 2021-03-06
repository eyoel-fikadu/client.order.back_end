using MLA.ClientOrder.Domain.Entities;
using System;

namespace MLA.ClientOrder.Application.View_Models
{
    public class ClientViewModel : BaseViewModel<Clients>
    {
        public string Client_name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string Industry_sector { get; set; }
        public string Contact_Person { get; set; }
        public string Contact_person_Email_Address { get; set; }
        public string Contact_person_Phone_Number { get; set; }
        public DateTime Registration_Date { get; set; }

        public ClientViewModel(Clients clients) : base(clients)
        {
            Client_name = clients.Client_name;
            Industry_sector = clients.Industry_sector;
            Contact_Person = clients.Contact_Person;
            Contact_person_Email_Address = clients.Contact_person_Email_Address;
            Contact_person_Phone_Number = clients.Contact_person_Phone_Number;
            Registration_Date = clients.Registration_Date;

            var addr = clients.Address;
            Address1 = addr.Address1;
            Address2 = addr.Address2;
            ZipCode = addr.ZipCode;
            Country = addr.Country;
            State = addr.State;
            City = addr.City;
        }
    }
}
