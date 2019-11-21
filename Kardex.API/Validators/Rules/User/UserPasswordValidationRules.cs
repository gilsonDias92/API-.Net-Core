using FluentValidation;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators.Rules.User
{
    public class UserPasswordValidationRules : AbstractValidator<UserDTO>
    {
        public UserPasswordValidationRules()
        {
            RuleFor(user => user.Password).NotEmpty().
                WithMessage("Nome não pode ser vazio FLUENT.");

            RuleFor(user => user.Password).Length(6, 20).
                WithMessage("Senha deve conter de 6 a 20 caracteres. -fluent");
        }
    }
}
