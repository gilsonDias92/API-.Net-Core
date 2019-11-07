using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kardex.API.Models
{
    public class Board
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public int MyProperty { get; set; }
    }
}
