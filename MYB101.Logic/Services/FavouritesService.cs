using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MYB101.Data;
using MYB101.Data.Pocos;
using MYB101.Logic.Models;
using SafeMapper;

namespace MYB101.Logic.Services
{
    public class FavouritesService
    {
        public ActionResponse AddFavourite(Favourite fav)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var favourite = SafeMap.Convert<Favourite, UserFavourite>(fav);

                    var id = context.FavouritesQueries.AddFavourite(favourite);

                    return new ActionResponse()
                    {
                        Success = true,
                        ErrorMessage = id.ToString()
                    };
                }

            }
            catch (Exception ex)
            {
                return new ActionResponse()
                {
                    Success = true,
                    ErrorMessage = ex.Message
                };
            }
        }

        public List<Favourite> GetFavourites()
        {
            using (var context = new DataContext())
            {
                var list = context.FavouritesQueries.GetFavourites();

                return SafeMap.Convert<List<UserFavourite>, List<Favourite>>(list);
            }
        }

        public Favourite GetFavourite(int id)
        {
            using (var context = new DataContext())
            {
                var fav = context.FavouritesQueries.GetFavourite(id);

                return SafeMap.Convert<UserFavourite, Favourite>(fav);
            }
        }
        public List<Favourite> GetFavouritesByContent(int id)
        {
            using (var context = new DataContext())
            {
                var list = context.FavouritesQueries.GetFavouritesByContent(id);

                return SafeMap.Convert<List<UserFavourite>, List<Favourite>>(list);
            }
        }

        public List<Favourite> GetFavouritesByContent(string id)
        {
            using (var context = new DataContext())
            {
                var list = context.FavouritesQueries.GetFavouritesByContent(Convert.ToInt32(id));

                return SafeMap.Convert<List<UserFavourite>, List<Favourite>>(list);
            }
        }

        public List<Favourite> GetFavouritesByMember(int id)
        {
            using (var context = new DataContext())
            {
                var list = context.FavouritesQueries.GetFavouritesByMember(id);

                return SafeMap.Convert<List<UserFavourite>, List<Favourite>>(list);
            }
        }

        public List<Favourite> GetFavouritesByMember(string id)
        {
            using (var context = new DataContext())
            {
                var list = context.FavouritesQueries.GetFavouritesByMember(Convert.ToInt32(id));

                return SafeMap.Convert<List<UserFavourite>, List<Favourite>>(list);
            }
        }

        public int GetNumberOfFavouritesByMember(int id)
        {
            using (var context = new DataContext())
            {
                return context.FavouritesQueries.GetNumberOfFavouritesByMember(id);
            }
        }

        public int GetNumberOfFavouritesByMember(string id)
        {
            using (var context = new DataContext())
            {
                return context.FavouritesQueries.GetNumberOfFavouritesByMember(Convert.ToInt32(id));
            }
        }

        public ActionResponse DeleteFavourite(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.FavouritesQueries.DeleteFavourite(id);
                }
                return new ActionResponse()
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ActionResponse()
                {
                    Success = false,
                    ErrorMessage = ex.Message
                };
            }

        }

        public int DoesMemberHaveFavourite(int memberId, int contentId)
        {
            using (var context = new DataContext())
            {
                return context.FavouritesQueries.MemberHasFavourite(memberId, contentId);
            }
        }
        public int DoesMemberHaveFavourite(string memberId, string contentId)
        {
            using (var context = new DataContext())
            {
                return context.FavouritesQueries.MemberHasFavourite(Convert.ToInt32(memberId), Convert.ToInt32(contentId));
            }
        }
    }
}
