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
    public class SaveSearchQueries
    {
        private UmbracoDatabase db = null;
        public SaveSearchQueries()
        {
            db = ApplicationContext.Current.DatabaseContext.Database;
        }

        public UserSavedSearch GetSearch(int id)
        {
            return db.SingleOrDefault<UserSavedSearch>("SELECT * FROM UserSavedSearches WHERE id = @0", id);
        }
        public List<UserSavedSearch> GetSearches()
        {

            var results = db.Query<UserSavedSearch>("SELECT * FROM UserSavedSearches").ToList();

            return results;
        }
        public List<UserSavedSearch> GetSearchesByContent(int id)
        {

            var results = db.Query<UserSavedSearch>("SELECT * FROM UserSavedSearches WHERE ContentId = @0 AND Enabled = 1", id).ToList();

            return results;
        }
        public List<UserSavedSearch> GetSearchesByMember(int id)
        {

            var results = db.Query<UserSavedSearch>("SELECT * FROM UserSavedSearches WHERE MemberId = @0 AND Enabled = 1", id).ToList();

            return results;
        }
        public int GetNumberOfSearchesByMember(int id)
        {
            return db.SingleOrDefault<int>("SELECT COUNT(*) FROM UserSavedSearches WHERE MemberId = @0 AND Enabled = 1", id);
        }
        public void AddSearch(UserSavedSearch search)
        {
            db.Insert(search);
        }
        public void DeleteSearch(int id)
        {
            var result = db.SingleOrDefault<UserSavedSearch>("SELECT * FROM UserSavedSearches WHERE Id = @0", id);

            result.Enabled = false;

            db.Update("UserSavedSearches", "Id", result);
        }
    }
}
