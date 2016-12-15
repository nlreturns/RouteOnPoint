using RouteOnPoint.LanguageUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;

namespace RouteOnPoint.Route
{
    class POI
    {
        //Key Value of the Info dictionary
        [JsonProperty]
        public string _INFO { get; set; }

        //GEO Posistion of the point
        [JsonProperty]
        private BasicGeoposition _coordinate { get; set; }

        //Location of the image (should be in assets)
        [JsonProperty]
        public string _path { get; set; }


        //Key Value of the Name dicionary
        [JsonProperty]
        public string _name { get; set; }

        //Boolean visited if true than the user has already been here.
        [JsonProperty]
        private bool _visited { get; set; }

        /// <summary>
        /// Creates a complete point of interest.
        /// </summary>
        /// <param name="name">Key for the Name</param>
        /// <param name="INFO">Key for the Info</param>
        /// <param name="path">Path to Assets </param>
        /// <param name="visited">Has  this point been visited or not?</param>
        /// <param name="coordinate">Location of the fence <remark>this is not the same as a GEOFENCE</remark></param>
        public POI(string name, string INFO, string path, bool visited, BasicGeoposition coordinate)
        {
            this._name = name;
            this._INFO = INFO;
            this._path = path;
            this._visited = visited;
            this._coordinate = coordinate;
        }
        /// <summary>
        /// Converts this object into a string
        /// </summary>
        /// <returns> the name and information of the string</returns>
        public override string ToString()
        {
            return MultiLang.GetContent(_name) + " " + MultiLang.GetContent(_INFO);
        }
    }
}