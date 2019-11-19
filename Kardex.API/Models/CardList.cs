using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    // Colunas que se encontram dentro dos paineis e contém os cards
    [Table("CardList")]
    public class CardList
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Title { get; set; }
        public Panel Produce { get; set; }
        [ForeignKey("Produce")]
        public int ProduceId { get; set; }
        public ICollection<Card> Cards { get; set; }
        public bool Creatable { get; set; }
    }
}
