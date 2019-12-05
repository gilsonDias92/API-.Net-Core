using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Threading.Tasks;
using Kardex.API.DataTransferObjects;

namespace Kardex.API.Validators.Rules.Card
{
    public class CardUserIdValidator : AbstractValidator<CardDTO>
    {
        public CardUserIdValidator()
        {
            RuleFor(c => c.UserId).NotNull().
                WithMessage("Usuário não pode ser nulo");

            RuleFor(c => c.UserId).NotEmpty().
                WithMessage("Card precisa pertencer a algum usuário");
        }
    }
}
