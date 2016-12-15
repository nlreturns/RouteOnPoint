using RouteOnPoint.LanguageUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    public class POI
    {
        public string Name { get; set; }
        private string _INFO { get; set; }
        public BasicGeoposition Coordinate { get; set; }
        private string _path { get; set; }
        public bool Visited { get; set; }

        public POI(string name, string INFO, string path, bool visited, BasicGeoposition coordinate)
        {
            this.Name = name;
            this._INFO = INFO;
            this._path = path;
            this.Visited = visited;
            this.Coordinate = coordinate;
        }
        public override string ToString()
        {
            return MultiLang.GetContent(Name) + " " + MultiLang.GetContent(_INFO);
        }
    }
}
