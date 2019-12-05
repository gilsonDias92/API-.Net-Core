using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Kardex.API.DataTransferObjects;

namespace Kardex.API.Validators.Rules.Card
{
    public class CardCardListValidator : AbstractValidator<CardDTO>
    {
        public CardCardListValidator()
        {
            RuleFor(c => c.CardListId).NotNull()
                .WithMessage("Card List não pode ser nulo");

            RuleFor(c => c.CardListId).NotEmpty()
                .WithMessage("Card List não pode ser vazio");

            RuleFor(c => c.CardListId).GreaterThan(0)
                .WithMessage("Id inválido");
        }

    }
}
