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
        public double? DistanceToPoi( /*POI point,*/ Geocoordinate coord)
        {
            throw new NotImplementedException();
        }

        public static TimeSpan? TimeToPoi(/*POI point, Geocoordinate coord*/)
        {
            //            double metersToPoint = DistanceToPOI(point, coord);
            //            int timeInSeconds = (int)Math.Floor((metersToPoint / coord.Speed));
            //            Debug.WriteLine(timeInSeconds);
            //
            //            int minutes = timeInSeconds/60;
            //            int hours = minutes/60;
            //            return new TimeSpan(hours,minutes,timeInSeconds);
            throw new NotImplementedException();
        }
    }
}