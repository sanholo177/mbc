using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MYB101.Data;
using MYB101.Logic.Models;
using SafeMapper;

namespace MYB101.Logic.Services
{
    public class LocationService
    {
        public List<Location> GetLocations(string search)
        {
            using (var context = new DataContext())
            {
                var results = context.Locations.GetLocations(search);

                return SafeMap.Convert<List<Data.Pocos.Location>, List<Logic.Models.Location>>(results);
            }
        }

        public Location GetLocation(string search)
        {
            using (var context = new DataContext())
            {
                var results = context.Locations.GetTopLocation(search);

                return SafeMap.Convert<Data.Pocos.Location, Logic.Models.Location>(results);
            }
        }
    }
}
