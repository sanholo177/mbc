using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace MYB101.Data.Pocos
{
    [TableName("UserFavourites")]
    [PrimaryKey("Id", autoIncrement = true)]
    [ExplicitColumns]
    public class UserFavourite
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("MemberId")]
        public int MemberId { get; set; }

        [Column("ContentId")]
        public int ContentId { get; set; }

        [Column("Enabled")]
        public bool Enabled { get; set; }

        [Column("DateCreated")]
        public DateTime DateCreated { get; set; }

        [Column("DateModified")]
        public DateTime DateModified { get; set; }
    }
}
