using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    // Gera as colunas dentro dos paineis
    [Table("Produce")]
    public class Produce
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public ICollection<CardList> Cardlists { get; set; }
    }
}
