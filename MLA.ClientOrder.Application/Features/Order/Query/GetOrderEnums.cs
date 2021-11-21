using MediatR;
using MLA.ClientOrder.Application.Model;
using MLA.ClientOrder.Common.Extesntions;
using MLA.ClientOrder.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MLA.ClientOrder.Application.Features.Order.Query
{
    public class GetOrderEnums : IRequest<List<EnumResponseModel>>
    {

    }

    public class GetOrderEnumHandler : IRequestHandler<GetOrderEnums, List<EnumResponseModel>>
    {
        public Task<List<EnumResponseModel>> Handle(GetOrderEnums request, CancellationToken cancellationToken)
        {
            List<EnumResponseModel> enums = new List<EnumResponseModel>();
            enums.Add(new EnumResponseModel()
            {
                enumKey = nameof(CrossJudiciariesEnums),
                enums = EnumExtension.GetList<CrossJudiciariesEnums>()
            });

            enums.Add(new EnumResponseModel()
            {
                enumKey = nameof(LawFirmInvolvedEnums),
                enums = EnumExtension.GetList<LawFirmInvolvedEnums>()
            });

            enums.Add(new EnumResponseModel()
            {
                enumKey = nameof(IndustrySectorsEnums),
                enums = EnumExtension.GetList<IndustrySectorsEnums>()
            });

            return Task.FromResult(enums);
        }
    }
}
