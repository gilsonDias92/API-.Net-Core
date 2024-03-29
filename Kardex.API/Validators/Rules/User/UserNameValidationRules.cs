﻿using FluentValidation;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators.Rules.User
{
    public class UserNameValidationRules : AbstractValidator<UserDTO>
    {
        public UserNameValidationRules()
        {
            RuleFor(user => user.Name).NotEmpty()
                .WithMessage("Nome não pode ser vazio. -FLUENT");

            RuleFor(user => user.Name).MaximumLength(50).
                WithMessage("Nome deve ter no máximo 50 caracteres. -FLUENT");
        }
    }
}
