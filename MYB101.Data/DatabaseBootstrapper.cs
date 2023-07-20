using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYB101.Data.Pocos;
using umbraco.BusinessLogic;
using Umbraco.Core;
using Umbraco.Core.Persistence;

namespace MYB101.Data
{
    public class DatabaseBootstrapper
    {
        public static void CreateCustomTables()
        {
            //Get the Umbraco Database context
            var db = ApplicationContext.Current.DatabaseContext.Database;

            //Check if the DB table does NOT exist
            if (!db.TableExist("UserFavourites"))
            {
                //Create DB table - and set overwrite to false
                db.CreateTable<UserFavourite>(false);
            }

            if (!db.TableExist("UserSavedSearches"))
            {
                db.CreateTable<UserSavedSearch>(false);
            }

            if (!db.TableExist("UserComments"))
            {
                db.CreateTable<UserComment>(false);
            }

            if (!db.TableExist("UserReplys"))
            {
                db.CreateTable<UserReply>(false);
            }

            if (!db.TableExist("Locations"))
            {
                db.CreateTable<Location>(false);
            }

            if (!db.TableExist("UserDetails"))
            {
                db.CreateTable<UserDetails>(false);
            }
        }
    }
}
