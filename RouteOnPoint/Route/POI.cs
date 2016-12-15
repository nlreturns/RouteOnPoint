using RouteOnPoint.LanguageUtil;
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
        public string _name { get; set; }
        public string _INFO { get; set; }
        public BasicGeoposition _coordinate { get; set; }
        public string _path { get; set; }
        private bool _visited { get; set; }

        public POI(string name, string INFO, string path, bool visited, BasicGeoposition coordinate)
        {
            this._name = name;
            this._INFO = INFO;
            this._path = path;
            this._visited = visited;
            this._coordinate = coordinate;
        }
        public override string ToString()
        {
            return MultiLang.GetContent(_name) + " " + MultiLang.GetContent(_INFO);
        }
    }
}
