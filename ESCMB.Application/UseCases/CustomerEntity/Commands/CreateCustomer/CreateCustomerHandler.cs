    using Core.Application;
using ESCMB.Application.ApplicationServices;
using ESCMB.Application.DomainEvents;
using ESCMB.Application.Exceptions;
using ESCMB.Application.Repositories.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Application.UseCases.CustomerEntity.Commands.CreateCustomer
{
    internal class CreateCustomerHandler : IRequestCommandHandler<CreateCustomerCommand, string>
    {
        private readonly ICommandQueryBus domainBus;

        private readonly ICustomerEntityRepository customerRepository;

        private readonly ICustomerApplicationService customerApplicationservice;
        public CreateCustomerHandler(ICommandQueryBus commandQueryBus, ICustomerEntityRepository customerEntityRepository, ICustomerApplicationService customerApplication)
        {
            domainBus = commandQueryBus?? throw new ArgumentNullException(nameof(commandQueryBus));
            customerRepository = customerEntityRepository ?? throw new ArgumentNullException(nameof(customerEntityRepository));
            customerApplicationservice = customerApplication ?? throw new ArgumentNullException(nameof(customerApplication));

        }

        public async Task<string> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer customer = new(request.CuilCuit, request.DocumentNumber,request.Email, request.FirstName, request.LastName);

            if (!customer.IsValid()) throw new InvalidEntityDataException(customer.GetErrors());

            if (customerApplicationservice.CustomerEntityExist(customer.CuilCuit)) throw new EntityDoesExistException();

            try
            {
                string createdId = await customerRepository.AddOneAsync(customer);

                await domainBus.Publish(customer.To<CustomerCreated>(), cancellationToken);

                return createdId;
            }
            catch (Exception ex)
            {
                throw new BussinessException(Constants.PROCESS_EXECUTION_EXCEPTION, ex.InnerException);
            }
        }
    }

    }

