using Core.Application;
using ESCMB.Application.DataTransferObjects;
using ESCMB.Application.Repositories.Sql;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.CustomerEntity.Queries.GetAllCustomerEntity 
{
    internal class GetAllCustomerEntityHandler(ICustomerEntityRepository context) : IRequestQueryHandler<GetAllCustomerEntityQuery, QueryResult<CustomerEntityDto>>
    {
        private readonly ICustomerEntityRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<QueryResult<CustomerEntityDto>> Handle(GetAllCustomerEntityQuery request, CancellationToken cancellationToken)
        {
            IList<Domain.Entities.Customer> entities = await _context.FindAllAsync();

            return new QueryResult<CustomerEntityDto>(entities.To<CustomerEntityDto>(), entities.Count, request.PageIndex, request.PageSize);
        }
    }
}
