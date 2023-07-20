using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MYB101.Data
{
    public class DataContext : IDisposable
    {
        public FavouritesQueries FavouritesQueries = null;
        public SaveSearchQueries SaveSearchQueries = null;
        public LocationQueries Locations = null;
        public CommentQueries CommentQueries = null;
        public DetailQueries DetailQueries = null;

        public DataContext()
        {
            FavouritesQueries = new FavouritesQueries();
            SaveSearchQueries = new SaveSearchQueries();
            Locations = new LocationQueries();
            CommentQueries = new CommentQueries();
            DetailQueries = new DetailQueries();
        }

        public void Dispose()
        {
            FavouritesQueries = null;
            SaveSearchQueries = null;
            Locations = null;
            CommentQueries = null;
            DetailQueries = null;
        }
    }
}