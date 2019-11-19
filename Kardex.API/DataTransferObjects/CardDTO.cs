using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.DataTransferObjects
{
    public class CardDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Lables { get; set; }
        public bool? Visible { get; set; }
        public UserDTO User { get; set; }
        public int UserId { get; set; }
        public CardListDTO CardList { get; set; }
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
