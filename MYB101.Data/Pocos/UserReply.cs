using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace MYB101.Data.Pocos
{
    [TableName("UserReplys")]
    [PrimaryKey("Id", autoIncrement = true)]
    [ExplicitColumns]
    public class UserReply
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("MemberId")]
        public int MemberId { get; set; }

        [Column("ContentId")]
        public int ContentId { get; set; }

        [Column("CommentId")]
        public int CommentId { get; set; }

        [Column("Avatar")]
        public string Avatar { get; set; }

        [Column("DateOP")]
        public string DateOP { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("RepliedComment")]
        public string RepliedComment { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("DateModified")]
        public DateTime DateModified { get; set; }
    }
}
