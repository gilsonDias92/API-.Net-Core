using AutoMapper;
using FluentResults;
using Kardex.API.DataTransferObjects;
using Kardex.API.Interfaces.Services;
using Kardex.API.Models;
using Kardex.API.Validators.Rules.Card;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Services
{
    public class CardServices : ICardService
    {
        private readonly KardexContext _context;
        private readonly IMapper _mapper;

        public CardServices(KardexContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public Result<IEnumerable<CardDTO>> GetAll()
        {
            var cards = _context.Card
                .Select(_mapper.Map<Card, CardDTO>);

            if (cards == null)
            {
                Result error = Results.Fail("Não há cards para exibir.");
            }

            return Results.Ok(cards);
        }


        public Result<CardDTO> GetOne(int id)
        {
            var card = _context.Card.Find(id);

            if (card == null)
            {
                Result error = Results.Fail("Erro! Card inválido.");
                return error;
            }

            var cardDTO = _mapper.Map<Card, CardDTO>(card);
            return Results.Ok(cardDTO);
        }


        public Result Insert(CardDTO cardDTO)
        {
            var validationRules = new CardValidator();
            var validationResult = validationRules.Validate(cardDTO);

            if (!validationResult.IsValid)
            {
                string errors = null;

                foreach (var failure in validationResult.Errors)
                {
                    errors += "Propriedade: " + failure.PropertyName + ". Erro: " +
                        failure.ErrorMessage + " .";
                }
                return Results.Fail(errors);
            }

            var card = _mapper.Map<CardDTO, Card>(cardDTO);

            _context.Card.Add(card);
            _context.SaveChanges();
            cardDTO.Id = card.Id;

            return Results.Ok(card.Id);

        }


        public Result Update(int id, CardDTO cardDTO)
        {
            var cardInDb = _context.Card.Find(id);

            if (cardInDb == null)
            {
                Result error = Results.Fail("Card não encontrado");
                return error;
            }

            _mapper.Map(cardDTO, cardInDb);

            var contextUpdated = _context.SaveChanges();

            if (contextUpdated > 0)
            {
                return Results.Ok();
            }
            return Results.Fail("Ocorreu um erro na hora de salvar.");

        }

        public Result Delete(int id)
        {
            var card = _context.Card.Find(id);

            if (!CardExists(card.Id))
            {
                return Results.Fail("Card não encontrado.");
            }

            _context.Card.Remove(card);
            _context.SaveChanges();

            return Results.Ok();
        }

        private bool CardExists(int id)
        {
            return _context.Card.Any(e => e.Id == id);
        }


    }
}
