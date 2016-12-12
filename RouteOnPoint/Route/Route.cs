using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    class Route
    {
        private string _name;
        private List<POI> _points;

        /**
         * Constructor containing name and list of POIs.
         * string _name - The name of the route.
         * List<POI> _points - the list with Point of Interests.
         */
        public Route(string _name, List<POI> _points)
        {
            this._name = _name;
            this._points = _points;
        }

        /**
         * Constructor containing name.
         * string _name - The name of the route.
         */
        public Route(string _name)
        {
            this._name = _name;
        }

        /*
         * Method for adding a POI to the POI list.
         * checks if the POI isn't already added before adding.
         * POI p - the POI to add.
         */
        public void addPOI(POI p)
        {
            if (!_points.Contains(p))
                _points.Add(p);
        }

        /*
         * Method for adding a POI to the POI list.
         * Adds it to a certain place in the list.
         * Checks if the POI isn't already added before adding.
         * POI p - the POI to add.
         * int plekInLijst - position in list to add.
         */
        public void addPOI(POI p, int plekInLijst)
        {
            if (!_points.Contains(p))
                _points.Insert(plekInLijst,p);
        }
        public void addPoint(string name, string INFO, string path, BasicGeoposition coordinate, bool visited = false)
        {
            addPOI(new POI(name, INFO, path, visited, coordinate));
        }

        /*
         * Set the POI list.
         * List<POI> points - The list of POI that will be set.
         */
        public void setPOIList(List<POI> points)
        {
            _points = points;
        }
    }
}
