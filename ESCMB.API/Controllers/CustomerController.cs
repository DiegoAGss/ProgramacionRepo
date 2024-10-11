using Core.Application;
using ESCMB.Application.UseCases.CustomerEntity.Commands.CreateCustomer;
using ESCMB.Application.UseCases.CustomerEntity.Queries.GetAllCustomerEntity;
using ESCMB.Application.UseCases.DummyEntity.Commands.CreateDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Commands.DeleteDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Commands.UpdateDummyEntity;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetAllDummyEntities;
using ESCMB.Application.UseCases.DummyEntity.Queries.GetDummyEntityBy;
using Microsoft.AspNetCore.Mvc;

namespace ESCMB.API.Controllers
{
    public class CustomerController(ICommandQueryBus commandQueryBus) : BaseController
    {
        private readonly ICommandQueryBus _commandQueryBus = commandQueryBus ?? throw new ArgumentNullException(nameof(commandQueryBus));

        [HttpGet("api/v1/[Controller]")]
        public async Task<IActionResult> GetAll(uint pageIndex = 1, uint pageSize = 10)
        {
            var entities = await _commandQueryBus.Send(new GetAllCustomerEntityQuery() { PageIndex = pageIndex, PageSize = pageSize });

            return Ok(entities);
        }

        [HttpPost("api/v1/[Controller]")]
        public async Task<IActionResult> Create(CreateCustomerCommand command)
        {
            if (command is null) return BadRequest();

            var id = await _commandQueryBus.Send(command);

            return Created($"api/[Controller]/{id}", new { Id = id });
        }

    }
}
