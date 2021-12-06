using System;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface IDateTime
    {
        DateTime Now { get; }
    }
}
