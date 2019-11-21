using FluentValidation;
using Kardex.API.DataTransferObjects;

namespace Kardex.API.Validators.Rules.User
{
    public class UserEmailValidationRules : AbstractValidator<UserDTO>
    {
        public UserEmailValidationRules()
        {
            RuleFor(user => user.Email).NotEmpty().
                WithMessage("O campo e-mail não pode ser vazio. -FLUENT");

            RuleFor(user => user.Email)
                .EmailAddress()
                .Matches(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")
                .WithMessage("Formato de e-mail inválido. -FLUENT");
        }
    }
}
