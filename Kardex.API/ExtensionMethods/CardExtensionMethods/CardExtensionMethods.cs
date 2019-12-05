using Kardex.API.Contracts.Requests.Create;
using Kardex.API.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.ExtensionMethods.CardExtensionMethods
{
    public static class CardExtensionMethods
    {
        public static CardDTO ConvertCreateContactToCardDTO(this CardCreateRequest cardContract)
        {
            var cardDTO = new CardDTO
            {
                Title = cardContract.Title,
                DateAdded = cardContract.DateAdded,
                Content = cardContract.Content,
                CardListId = cardContract.CardListId,
                Visible = true,
                Lables = cardContract.Lables,
                UserId = cardContract.UserId
            };

            return cardDTO;
        }
    }
}
