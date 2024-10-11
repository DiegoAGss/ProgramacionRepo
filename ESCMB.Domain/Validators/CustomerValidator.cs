using Core.Domain.Validators;
using ESCMB.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESCMB.Domain.Validators
{
    /// <summary>
    /// Ejemplo de validador de entidad Dummy
    /// Todo validador de entidad de dominio debe heredar de <see cref="EntityValidator{TEntity}"/>
    /// Donde TEntity es del tipo <see cref="Core.Domain.Entities.DomainEntity{TEntity, TValidator}"/>
    /// </summary>
    public class CustomerValidator : EntityValidator<Customer>
    {
        public CustomerValidator()
        {
            //Las reglas de negocio deben ir definidas aca
            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.CuilCuit).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.CuilCuit).Length(11).WithMessage("Debe tener 11 digitos");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.DocumentNumber).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.DocumentNumber).Length(8).WithMessage("Debe tener 8 digitos");
            RuleFor(x => x.FirstName).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
            RuleFor(x => x.LastName).NotNull().NotEmpty().WithMessage(Constants.NOTNULL_OR_EMPTY);
        }
    }
}
