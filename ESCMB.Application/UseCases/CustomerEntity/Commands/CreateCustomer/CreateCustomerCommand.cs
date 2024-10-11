using Core.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.CustomerEntity.Commands.CreateCustomer
{
    public class CreateCustomerCommand : IRequestCommand<string>
    {
        [Required]
        public string CuilCuit { get;  set; }
        [Required]
        public string DocumentNumber { get;  set; }
        [Required]
        public string Email { get;  set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}
