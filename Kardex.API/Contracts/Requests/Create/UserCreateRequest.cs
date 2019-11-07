using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Contracts.Requests.Create
{
    public class UserCreateRequest
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [MinLength(6, ErrorMessage = "Sua senha deve ter, no mínimo, {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Máximo de {1} caracteres permitidos.")]
        public string Password { get; set; }
    }
}
