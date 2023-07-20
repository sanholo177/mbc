using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYB101.Data;
using MYB101.Data.Pocos;
using MYB101.Logic.Models;
using SafeMapper;

namespace MYB101.Logic.Services
{
    public class SavedSearchService
    {
        public int GetNumberOfSearchesByMember(int id)
        {
            using (var context = new DataContext())
            {
                return context.SaveSearchQueries.GetNumberOfSearchesByMember(id);
            }
        }

        public int GetNumberOfSearchesByMember(string id)
        {
            using (var context = new DataContext())
            {
                return context.SaveSearchQueries.GetNumberOfSearchesByMember(Convert.ToInt32(id));
            }
        }

        public List<SavedSearch> GetSearches()
        {
            using (var context = new DataContext())
            {
                var results = context.SaveSearchQueries.GetSearches();
                return SafeMap.Convert<List<UserSavedSearch>, List<SavedSearch>>(results);
            }
        }
        public List<SavedSearch> GetSearchesByContent(int id)
        {
            using (var context = new DataContext())
            {
                var results = context.SaveSearchQueries.GetSearchesByContent(id);
                return SafeMap.Convert<List<UserSavedSearch>, List<SavedSearch>>(results);
            }
        }
        public List<SavedSearch> GetSearchesByContent(string id)
        {
            using (var context = new DataContext())
            {
                var results = context.SaveSearchQueries.GetSearchesByContent(Convert.ToInt32(id));
                return SafeMap.Convert<List<UserSavedSearch>, List<SavedSearch>>(results);
            }
        }
        public List<SavedSearch> GetSearchesByMember(int id)
        {
            using (var context = new DataContext())
            {
                var results = context.SaveSearchQueries.GetSearchesByMember(id);
                return SafeMap.Convert<List<UserSavedSearch>, List<SavedSearch>>(results);
            }
        }
        public List<SavedSearch> GetSearchesByMember(string id)
        {
            using (var context = new DataContext())
            {
                var results = context.SaveSearchQueries.GetSearchesByMember(Convert.ToInt32(id));
                return SafeMap.Convert<List<UserSavedSearch>, List<SavedSearch>>(results);
            }
        }
        public ActionResponse AddSearch(SavedSearch search)
        {
            try
            {
                using (var context = new DataContext())
                {
                    var newSearch = SafeMap.Convert<SavedSearch, UserSavedSearch>(search);

                    context.SaveSearchQueries.AddSearch(newSearch);

                    return new ActionResponse()
                    {
                        Success = true
                    };
                }

            }
            catch (Exception ex)
            {
                return new ActionResponse()
                {
                    ErrorMessage = ex.Message,
                    Success = false
                };
            }
        }
        public ActionResponse DeleteSearch(int id)
        {
            try
            {
                using (var context = new DataContext())
                {
                    context.SaveSearchQueries.DeleteSearch(id);
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

    }
}
