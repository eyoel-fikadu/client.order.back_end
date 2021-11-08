using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using MLA.ClientOrder.Application.Common.Exceptions;
using System;
using System.Collections.Generic;

namespace MLA.OrderManagement.Infrustructure.Identity
{
    public class IdentityException : Exception
    {
        public IdentityException(List<IdentityError> errors)
        {
            List<ValidationFailure> failures = new List<ValidationFailure>();
            errors.ForEach(x =>
            {
                ValidationFailure validationFailure = new ValidationFailure(x.Code, x.Description);
                failures.Add(validationFailure);
            });
            throw new ValidationException(failures);
        }
    }
}
