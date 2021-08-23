using MLA.ClientOrder.Application.Common.Abstraction;
using System;

namespace MLA.OrderManagement.Infrustructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
