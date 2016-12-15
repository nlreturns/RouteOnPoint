using RouteOnPoint.LanguageUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            MultiLang.setLanguage(MultiLang.LanguageEnum.Dutch);
            Route r = new RouteHelper().createHistoriscRoute();
            foreach (POI p in r._points)
            {
                Debug.WriteLine(p.ToString());
            }
        }

    }
}
