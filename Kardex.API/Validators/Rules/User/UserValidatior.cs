using FluentValidation;
using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Validators.Rules.User
{
    public class UserValidator : AbstractValidator<UserDTO>
    {
        public UserValidator()
        {
            Include(new UserNameValidationRules());
            Include(new UserEmailValidationRules());
            Include(new UserPasswordValidationRules());
        }
    }
}
