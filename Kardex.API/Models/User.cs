using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
