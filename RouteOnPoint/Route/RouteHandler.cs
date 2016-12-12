using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Author: Jan-Willem Dooms <janwillem.dooms@gmail.com>
 * RouteHandler has help methods for the Route class, including
 * Saving, retreiving and checking if you are still on Route
 * or near a Point of Interest.
 * 
 * Version 0.1 - Added attributes and methods. (From class diagram)
 */
namespace RouteOnPoint.Route
{
    class RouteHandler
    {
        private Boolean _paused;
        private Route _route;
        private gpsreader _gpsreader;

        /*
         * Save a route with all info included.
         */
        private void SaveRouteWithState(Route route, List<POI> POI, String path)
        {
            throw new NotImplementedException();
        }

        /*
         * Get a Route from excisting file.
         * Returns Route with excisting data.
         */
        private Route GetRouteFromFile(String path)
        {
            throw new NotImplementedException();
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
