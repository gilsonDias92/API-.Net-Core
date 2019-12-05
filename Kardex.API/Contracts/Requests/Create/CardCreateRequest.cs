using Kardex.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Contracts.Requests.Create
{
    public class CardCreateRequest
    {
        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos.")]
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Content { get; set; }
        public string Lables { get; set; }

        private bool? _visible;
        public bool? Visible
        {
            get
            {
                return _visible.HasValue ? _visible.Value : true;
            }
            set
            {
                _visible = value;
            }
        }
        public User User { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public int UserId { get; set; }

        public CardList CardList { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public int CardListId { get; set; }

        private DateTime? _addedDate = null;
        public DateTime DateAdded
        {
            get
            {
                return _addedDate.HasValue ? _addedDate.Value : DateTime.Now;
            }
            set => _addedDate = value;
        }
    }
}
