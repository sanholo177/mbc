﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Persistence.DatabaseAnnotations;

namespace MYB101.Data.Pocos
{
    [TableName("UserDetails")]
    [PrimaryKey("Id", autoIncrement = true)]
    [ExplicitColumns]
    public class UserDetails
    {
        [Column("Id")]
        [PrimaryKeyColumn(AutoIncrement = true)]
        public int Id { get; set; }

        [Column("MemberId")]
        public int MemberId { get; set; }

        [Column("Avatar")]
        public string Avatar { get; set; }

        [Column("Name")]
        public string Name { get; set; }
    }
}
