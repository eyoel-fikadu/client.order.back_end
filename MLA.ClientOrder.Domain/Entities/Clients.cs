using MLA.ClientOrder.Domain.Common;
using MLA.ClientOrder.Domain.ValueObjects;
using System;

namespace MLA.ClientOrder.Domain.Entities
{
    public class Clients : AuditableEntity 
    {
        public Clients(string client_name, string industry_sector, string contact_Person, string contact_person_Email_Address, string contact_person_Phone_Number, DateTime registration_Date, bool isActive)
        {
            Client_name = client_name;
            Industry_sector = industry_sector;
            Contact_Person = contact_Person;
            Contact_person_Email_Address = contact_person_Email_Address;
            Contact_person_Phone_Number = contact_person_Phone_Number;
            Registration_Date = registration_Date;
            IsActive = isActive;
        }

        public string Client_name { get; set; }
        public string Industry_sector { get; set; }
        public string Contact_Person { get; set; }
        public string Contact_person_Email_Address { get; set; }
        public string Contact_person_Phone_Number { get; set; }
        public DateTime Registration_Date { get; set; }
        public virtual Address Address { get; set; }

    }
}
