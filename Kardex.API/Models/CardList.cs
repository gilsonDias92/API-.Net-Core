using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    [Table("CardList")]
    public class CardList
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Title { get; set; }
        public List<Card> Cards { get; set; }
    }
}
