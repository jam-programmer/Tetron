using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Common.Behaviors
{
    public class ValidateCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
            where TRequest : IRequest<TResponse>
    {

        #region Constracture
        // a collection of all validation classes in project
        // https://stackoverflow.com/questions/63216905/unable-to-resolve-fluent-validation-using-mediatr-without-structuremap
        private readonly IEnumerable<IValidator<TRequest>> _validators;


        public ValidateCommandBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;

        }
        #endregion

        public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            // validate our commands in these lines of linq expression
            // what we did here ? we found our validation class related 
            // to our command - we have command on method parameter-
            // then in this linq expression we found the spcific validator 
            // for our command then we keep validation our model to find any error
            var errors = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(a => a != null)
                .ToList();

            if (errors.Any()) // if we have any kind of error
            {
                #region append all errors into an instance of string builder

                StringBuilder errorBuilder = new();
                errorBuilder.AppendLine("Invalid command, reasons: ");

                bool modelError = false;

                foreach (var error in errors)
                {
                    if (!string.IsNullOrEmpty(error.PropertyName))
                    {
                        modelError = true;
                    }

                    errorBuilder.AppendLine(error.ErrorMessage);
                }



                #endregion

                if (modelError)
                {
                    throw new ValidationException(errorBuilder.ToString());
                }
                else
                {
                    throw new ArgumentException(errorBuilder.ToString());
                }



                // throw errors as exception

            }
            else
            {
                //_logger.LogInformation($"Validation of the model was done successfully : {typeof(TRequest)}");
            }

            // In any case we will continue next operation
            return next();
        }




    }
}
