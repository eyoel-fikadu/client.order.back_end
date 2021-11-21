using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Lookup.Command.AddFirm
{
    public class AddJudCommand:IRequest<Guid>
    {
        public String Name { get; set; }
    }
}
