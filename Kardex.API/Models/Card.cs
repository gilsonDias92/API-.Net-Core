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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "Máximo de {1} caracteres permitidos.")]
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        public string Title { get; set; }

        [MaxLength(200, ErrorMessage = "Máximo de {1} caracteres permitidos")]
        public string Content { get; set; }
        public string Lables { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public CardList CardList { get; set; }
        public int CardListId { get; set; }

        private DateTime? _addedDate = null;

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateAdded
        {
            get
            {
                if (_addedDate.HasValue)
                    return _addedDate.Value;
                else
                    return DateTime.Now;
            }
            set
            {
                _addedDate = value;
            }
        }
    }
}
