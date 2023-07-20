using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using MYB101.Data.Pocos;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace MYB101.Data
{
    public class LocationQueries
    {
        private UmbracoDatabase db = null;
        public LocationQueries()
        {
            db = ApplicationContext.Current.DatabaseContext.Database;
        }

        public List<Location> GetLocations(string searchTerm)
        {
            var results = db.Query<Location>(@"SELECT TOP 5 * FROM [Locations] WHERE [Name] LIKE @0 OR [PostCode] = @1", new string[] { string.Format($"%{searchTerm}%"), searchTerm }).ToList();

            return results;
        }

        public Location GetTopLocation(string searchTerm)
        {
            return db.SingleOrDefault<Location>("SELECT TOP 1 * FROM [Locations] WHERE [Name] LIKE @0 OR [PostCode] = @1", new string[] { string.Format($"%{searchTerm}%"), searchTerm });
        }

        public List<Location> GetAllLocations()
        {
            return db.Fetch<Location>("SELECT * FROM [Locations]");
        }

        public Location GetLocationById(int id)
        {
            return db.FirstOrDefault<Location>("SELECT * FROM [Locations] WHERE Id = @0", id);
        }
    }
}
