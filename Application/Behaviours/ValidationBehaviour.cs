using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Application.Behaviours
{
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatators;

        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validatators)
        {
            _validatators = validatators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validatators.Any())
            {

                var context = new ValidationContext<TRequest>(request);

                var validationResults = await Task.WhenAll(_validatators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                {
                    // Construye una excepción personalizada para las fallas de validación
                    var validationException = new ValidationException("La solicitud no pasó la validación.", failures);

                    // Puedes agregar detalles adicionales a la excepción si es necesario
                    validationException.Data["Failures"] = failures;

                    throw validationException;
                }
            }

            return await next();
        }
    }
}
