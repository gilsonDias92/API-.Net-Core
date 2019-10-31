﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Content { get; set; }
        public string Lables { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public CardList CardList { get; set; }
        public int CardListId { get; set; }
    }
}
