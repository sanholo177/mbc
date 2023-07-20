using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Logic.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ContentId { get; set; }
        public int CommentId { get; set; }
        public string Avatar { get; set; }
        public string DateOP { get; set; }
        public string error { get; set; }
        public string Name { get; set; }
        public string RepliedComment { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
