using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ContentId { get; set; }
        public string Avatar { get; set; }
        public string error { get; set; }
        public string DateOP { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
