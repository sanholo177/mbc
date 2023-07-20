using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Geocoding.Google;
using MYB101.Logic.Models;

namespace MYB101.Logic
{
    public static class Geography
    {
        public static double Distance(double lat1, double lng1, double lat2, double lng2)
        {
            double earth = 6371; // Kilometers
            double dLat = ToRadian(lat2 - lat1);
            double dLon = ToRadian(lng2 - lng1);

            double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) + Math.Cos(ToRadian(lat1))
                * Math.Cos(ToRadian(lat2)) * Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            double c = 2 * Math.Asin(Math.Min(1, Math.Sqrt(a)));
            double d = earth * c;

            return d;
        }

        private static double ToRadian(double val)
        {
            return (Math.PI / 180) * val;
        }

        public static LatLongPair GetLocation(string address)
        {
            //get address
            GoogleGeocoder geocoder = new GoogleGeocoder();
            IEnumerable<GoogleAddress> addresses = geocoder.Geocode(address);
            var newAddress = addresses.FirstOrDefault(a => a[GoogleAddressType.Country].LongName == "Australia");

            if (newAddress != null)
            {
                return new LatLongPair()
                {
                    Lat = newAddress.Coordinates.Latitude.ToString(),
                    Long = newAddress.Coordinates.Longitude.ToString()
                };
            }
            return null;
        }
    }
}
