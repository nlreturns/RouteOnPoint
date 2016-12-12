using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    class UnitTest
    {
        private RouteHandler handler;

        public UnitTest()
        {
            RouteHandler test = new RouteHandler();
            RouteHelper helper = new RouteHelper();
            Route r = helper.createHistoriscRoute();           
            handler.SaveRouteWithState(r, "C:/Mooi/");
        }

    }
}
