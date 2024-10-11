using Core.Application.Repositories;
using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.Repositories.Sql
{
    public interface ICustomerEntityRepository : ISqlRepository<Customer>
    {
        Customer GetByCuilcuit(string cuilcuit);
 
    }
}
