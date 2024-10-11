using ESCMB.Application.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application;


namespace ESCMB.Application.UseCases.CustomerEntity.Queries.GetAllCustomerEntity
{
    public class GetAllCustomerEntityQuery : QueryRequest<QueryResult<CustomerEntityDto>>
    {
    }
}
