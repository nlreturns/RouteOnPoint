using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOnPoint.Route
{
    class UnitTest
    {
        private RouteHandler handler;

        public UnitTest()
        {
            RouteHandler = new RouteHandler();

            Route r = new Route("Unit testje");
            r.addPOI(new POI()
            {
                _name = "POI 1",
                _information = "Mooi POI de allereerste",
                _coordinate = new Geocoordinate(),
                _path = "Wat?",
                _visited = false
            });
            r.addPOI(new POI()
            {
                _name = "POI 2",
                _information = "Landhuisje",
                _coordinate = new Geocoordinate(),
                _path = "Wat?",
                _visited = true
            });
            r.addPOI(new POI()
            {
                _name = "POI 3",
                _information = "Ratatatata",
                _coordinate = new Geocoordinate(),
                _path = "Huh?",
                _visited = false
            });

            handler.SaveRouteWithState(r, "C:/Mooi/");

        }

    }
}
