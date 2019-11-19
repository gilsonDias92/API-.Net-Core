using FluentValidation;
using Kardex.API.Contracts.Requests.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators.Rules.User
{
    public class UserEmailValidationRules : AbstractValidator<UserCreateRequest>
    {
        public UserEmailValidationRules()
        {
            RuleFor(user => user.Email).NotEmpty().
                WithMessage("O campo e-mail não pode ser vazio.");

            RuleFor(user => user.Email).EmailAddress().
                WithMessage("Formato de e-mail inválido.");

        }
    }
}
