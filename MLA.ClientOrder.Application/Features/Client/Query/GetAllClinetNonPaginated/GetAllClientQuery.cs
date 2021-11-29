using MediatR;
using MLA.ClientOrder.Application.View_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Client.Query.GetAllClinetNonPaginated
{
    public class GetAllClientQuery : IRequest<List<ClientViewModel>>
    {

    }
}
