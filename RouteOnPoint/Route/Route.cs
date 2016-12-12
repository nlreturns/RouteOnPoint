﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouteOnPoint.Route
{
    class Route
    {
        private string _name;
        private List<POI> _points;
        public Route(string name, List<POI> _points)
        {
            this._name = name;
            this._points = _points;
        }
        public Route(string name)
        {
            this._name = name;
         }

        public void addPOI(POI p)
        {
            if (!_points.Contains(p)) {
                _points.Add(p);
            }
        }
        public void addPOI(POI p, int plekInLijst)
        {
            if (!_points.Contains(p))
            {
                _points.Insert(plekInLijst,p);
            }
        }
        public void setPOIList(List<POI> points)
        {
            _points = points;
        }
    }
}
