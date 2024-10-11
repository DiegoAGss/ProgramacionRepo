using ESCMB.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Infraestructure.Repositories.Sql;
using ESCMB.Application.Repositories.Sql;
using System.Linq.Expressions;

namespace ESCMB.Infraestructure.Repositories.Sql
{
    internal sealed class CustomerRepository(StoreDbContext context) : BaseRepository<Customer>(context), ICustomerEntityRepository
    {
        public Customer GetByCuilcuit(string cuilcuit)
        {
            cuilcuit = cuilcuit ?? throw new ArgumentNullException(nameof(cuilcuit));

            Expression<Func<Customer, bool>> expression = x => x.CuilCuit == cuilcuit;

            return Repository.AsQueryable().Where(expression).AsEnumerable().FirstOrDefault();
        }
    }
}
