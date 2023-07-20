using MYB101.Data.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace MYB101.Data
{
    public class DetailQueries
    {
        private UmbracoDatabase db = null;
        public DetailQueries()
        {
            db = ApplicationContext.Current.DatabaseContext.Database;
        }

        public void UpdateDetails(string Avatar, int memberId, string name)
        {
            var details = new Data.Pocos.UserDetails()
            {
                MemberId = memberId,
                Name = name,
                Avatar = Avatar
            };
            var sql = db.Query<UserDetails>("SELECT * FROM UserDetails WHERE MemberId = @0", memberId).Take(1);
            if (sql.ToArray().Length == 0)
            {
                db.Insert(details);
            }
            else
            {
                db.Update<UserDetails>("SET Avatar = @1 WHERE MemberId = @0 ", memberId, Avatar);
            }
        }
    }
}