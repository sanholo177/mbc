using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace MYB101.Data.Pocos
{
    [TableName("Locations")]
    [PrimaryKey("Id", autoIncrement = true)]
    [ExplicitColumns]
    public class Location
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Latitude")]
        public float Latitude { get; set; }

        [Column("Longitude")]
        public float Longitude  { get; set; }

        [Column("PostCode")]
        public string Postcode { get; set; }
    }
}
