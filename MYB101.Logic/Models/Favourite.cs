using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ContentId { get; set; }
        public bool Enabled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
