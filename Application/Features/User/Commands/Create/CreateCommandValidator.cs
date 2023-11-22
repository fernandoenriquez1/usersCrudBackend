using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.User.Commands.Create
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator() {

            RuleFor(p => p.Name)
               .NotEmpty().WithMessage("El Nombre es requerido.")
               .NotNull().WithMessage("El Nombre es requerido.")
               .MaximumLength(50).WithMessage("El nombre no debe exceder los 50 caracteres.");


            RuleFor(p => p.PaternalSurname)
               .NotEmpty().WithMessage("El Apellido paterno es requerido.")
               .NotNull().WithMessage("El Apellido paterno es requerido.")
               .MaximumLength(50).WithMessage("El apellido no debe exceder los 50 caracteres.");

            RuleFor(p => p.CellphoneNumber)
              .NotEmpty().WithMessage("El teléfono es requerido.")
              .NotNull().WithMessage("El teléfono es requerido.")
              .MaximumLength(12).WithMessage("El teléfono no debe exceder los 12 caracteres.");

            RuleFor(p => p.Email)
             .NotEmpty().WithMessage("El correo electrónico es requerido.")
             .NotNull().WithMessage("El  correo electrónico es requerido.")
             .MaximumLength(100).WithMessage("El  correo electrónico no debe exceder los 100 caracteres.");
        }
    }
}
