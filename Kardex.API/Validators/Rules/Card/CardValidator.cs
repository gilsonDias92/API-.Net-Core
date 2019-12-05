using System;
using System.Collections.Generic;
using FluentValidation;
using System.Linq;
using System.Threading.Tasks;
using Kardex.API.DataTransferObjects;

namespace Kardex.API.Validators.Rules.Card
{
    public class CardValidator : AbstractValidator<CardDTO>
    {
        public CardValidator()
        {
            Include(new CardUserIdValidator());
            Include(new CardCardListValidator());

        }
    }
}
