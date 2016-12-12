using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    
    class POI
    {
        private string _name { get; set; }
        private string _information { get; set; }
        private Geocoordinate _coordinate { get; set; }
        private string _path { get; set; }
        private bool _visited { get; set; }

        public POI(string name, string information, string path, bool visited, Geocoordinate coordinate)
        {
            this._name = name;
            this._information = information;
            this._path = path;
            this._visited = visited;
            this._coordinate = coordinate;
        }
    }
}
