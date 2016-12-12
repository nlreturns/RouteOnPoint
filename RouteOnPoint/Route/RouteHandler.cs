using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/**
 * Author: Jan-Willem Dooms <janwillem.dooms@gmail.com>
 * RouteHandler has help methods for the Route class, including
 * Saving, retreiving and checking if you are still on Route
 * or near a Point of Interest.
 * 
 * Version 0.1 - Added attributes and methods. (From class diagram)
 * Version 0.2 - Adusted SaveRouteWithState, added functionality to
 *               SaveRouteWithState and GetRouteFromFile.
 */
namespace RouteOnPoint.Route
{
    class RouteHandler
    {
        private Boolean _paused;
        private Route _route;
        //private GPSreader _gpsreader;

        /*
         * Save a route with all info included.
         * 
         * Version 0.2 - removed List<POI> POI - this is saved inside Route
         */
        public void SaveRouteWithState(Route route, String path)
        {   
            FileStream outFile = File.Create(path);
            XmlSerializer formatter = new XmlSerializer(typeof(Route));
            formatter.Serialize(outFile, route);
        }

        /*
         * Get a Route from excisting file.
         * Returns Route with excisting data.
         */
        private Route GetRouteFromFile(String path)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(Route));
            FileStream aFile = new FileStream(path, FileMode.Open);
            byte[] buffer = new byte[aFile.Length];
            aFile.Read(buffer, 0, (int)aFile.Length);
            MemoryStream stream = new MemoryStream(buffer);
            return (Route)formatter.Deserialize(stream);
        }

        /*
         * Check if the user is near a POI
         * returns POI - the Point of interest which u are
         * close at.
         */
        private POI CheckPOIArrived(List<POI> POI)
        {
            throw new NotImplementedException();
        }

        /**
         * Checks if the user has left the route
         * returns Boolean true - User left route
         * returns Boolean false - User is still on route
         */
        private Boolean RouteEscaped(Route route)
        {
            throw new NotImplementedException();
        }

    }
}
