using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.GPSHandler
{
    class GPSHelper
    {
        public GPSReader Gpsreader;

        public GPSHelper()
        {

        }

        //returns distance via the map in meters
        public double? DistanceToPOI( /*POI point,*/ Geocoordinate coord)
        {
            return null;
        }

        public static TimeSpan? TimeToPOI(/*POI point, Geocoordinate coord*/)
        {
           // double metersToPoint = DistanceToPOI(point, coord);
            int timeInSeconds = (int)Math.Floor((20.0 / 1.39));
            Debug.WriteLine(timeInSeconds);
            



            // s/v = t
            //5 km per uur
            return new TimeSpan();

        }
    }
}
