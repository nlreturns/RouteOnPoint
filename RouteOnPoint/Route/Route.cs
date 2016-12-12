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

        public Route(string _name, List<POI> _points)
        {
            this._name = _name;
            this._points = _points;
        }

        public Route(string _name)
        {
            this._name = _name;
        }

        public void addPOI(POI p)
        {
            if (!_points.Contains(p))
                _points.Add(p);
        }

        public void addPOI(POI p, int plekInLijst)
        {
            if (!_points.Contains(p))
                _points.Insert(plekInLijst,p);
        }
        public void addPoint(string name, string information, string path, Geocoordinate coordinate, bool visited = false)
        {
            addPOI(new POI(name, information, path, visited, coordinate));
        }

        public void setPOIList(List<POI> points)
        {
            _points = points;
        }
    }
}
