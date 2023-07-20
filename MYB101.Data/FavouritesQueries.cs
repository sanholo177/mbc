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
    public class FavouritesQueries
    {
        private UmbracoDatabase db = null;
        public FavouritesQueries()
        {
            db = ApplicationContext.Current.DatabaseContext.Database;
        }
        public UserFavourite GetFavourite(int id)
        {
            return db.SingleOrDefault<UserFavourite>("SELECT * FROM UserFavourites WHERE Id = @0", id);
        }
        public List<UserFavourite> GetFavourites()
        {
            var results = db.Query<UserFavourite>("SELECT * FROM UserFavourites WHERE Enabled = 1").ToList();

            return results;
        }
        public List<UserFavourite> GetFavouritesByContent(int id)
        {
            var results = db.Query<UserFavourite>("SELECT * FROM UserFavourites WHERE ContentId = @0 AND Enabled = 1", id).ToList();

            return results;
        }
        public List<UserFavourite> GetFavouritesByMember(int id)
        {
            var results = db.Query<UserFavourite>("SELECT * FROM UserFavourites WHERE MemberId = @0 AND Enabled = 1", id).ToList();

            return results;
        }
        public int GetNumberOfFavouritesByMember(int id)
        {
            var results = db.SingleOrDefault<int>("SELECT COUNT(*) FROM UserFavourites WHERE MemberId = @0 AND Enabled = 1", id);
            return results;
        }
        public int AddFavourite(UserFavourite fav)
        {
            db.Insert(fav);
            return fav.Id;
        }
        public void DeleteFavourite(int id)
        {
            var result = db.SingleOrDefault<UserFavourite>("SELECT * FROM UserFavourites WHERE Id = @0", id);

            result.Enabled = false;

            db.Update("UserFavourites", "Id", result);
        }

        public int MemberHasFavourite(int memberId, int contentId)
        {
            var results = db.SingleOrDefault<UserFavourite>("SELECT * FROM UserFavourites WHERE MemberId = @0 AND ContentId=@1 AND Enabled = 1", memberId, contentId);

            if (results != null)
            {
                return results.Id;
            }
            return 0;
        }
    }
}
