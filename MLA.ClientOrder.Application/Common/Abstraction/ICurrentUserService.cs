using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Common.Abstraction
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        Guid UserGuidId { get; }
    }
}
