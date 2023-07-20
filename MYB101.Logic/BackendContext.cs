using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYB101.Logic.Services;

namespace MYB101.Logic
{
    public class BackendContext
    {
        public FavouritesService Favourites = null;
        public SavedSearchService SavedSearches = null;
        public LocationService Locations = null;
        public CommentsService Comments = null;
        public DetailsService Details = null;
        public BackendContext()
        {
            Favourites = new FavouritesService();
            SavedSearches = new SavedSearchService();
            Locations = new LocationService();
            Comments = new CommentsService();
            Details = new DetailsService();
        }
    }
}