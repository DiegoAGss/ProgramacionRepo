using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.ApplicationServices
{
    public class CustomerEntityApplicationService(ICustomerEntityRepository context) : ICustomerApplicationService
    {
        private readonly ICustomerEntityRepository _context = context ?? throw new ArgumentNullException(nameof(context));

        public bool CustomerEntityExist(string value)
        {
            value = value ?? throw new ArgumentNullException(nameof(value));

            var response = _context.GetByCuilcuit(value);

            return response != null;
        }

    }
}
