using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Models
{
    public class SavedSearch
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string Query { get; set; }
        public bool Enabled { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
