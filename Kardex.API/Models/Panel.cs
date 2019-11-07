using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    // Painel de determinado projeto que o usuário cria dentro do board
    [Table("Panel")]
    public class Panel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Board Board { get; set; }
        public int BoardId { get; set; }
        public ICollection<Member> Members { get; set; }
        public ICollection<Produce> Produces { get; set; }
    }
}
