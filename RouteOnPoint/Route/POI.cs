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
        //Key Value of the Name dicionary
        private string _name { get; set; }
        //Key Value of the Info dictionary
        private string _INFO { get; set; }
        //GEO Posistion of the point
        public BasicGeoposition _coordinate { get; set; }
        //Location of the image (should be in assets)
        private string _path { get; set; }
        //Boolean visited if true than the user has already been here.
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
