using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    class RouteHelper
    {
        public Route createHistoriscRoute()
        {
            Route r = new Route("R_HISTORISCHEKILOMETER_NAAM");
            r.addPoint("P_VVV_NAAM", "P_VVV_INFORMATION", "", new BasicGeoposition() { Latitude = 51.356467, Longitude = 4.467650 });
            return r;
        }

    }
}
