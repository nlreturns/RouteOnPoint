using RouteOnPoint.GPSHandler;
using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Pages;
using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;

namespace RouteOnPoint.Test
{
    public static class Tests
    {
        public static async void LanguageTest1()
        {
            await MultiLang.setLanguage(MultiLang.LanguageEnum.Dutch);
            Debug.WriteLine("NEDERLANDS: " + MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME"));
            await MultiLang.setLanguage(MultiLang.LanguageEnum.English);
            Debug.WriteLine("ENGELS: " + MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME"));
        }

        public static async void RouteTest()
        {
            await MultiLang.setLanguage(MultiLang.LanguageEnum.Dutch);
            BasicGeoposition b = new BasicGeoposition();
            b.Latitude = 51.58389660297626;
            b.Longitude = 4.795510768890381;
            POI punt1 = new POI("P_ZENKONEGODEVAERT_NAME", "P_ZENKONEGODEVAERT_INFO", null, false, b);
            b.Latitude = 51.58834964389717;
            b.Longitude = 4.786133766174316;
            POI punt2 = new POI("P_ZENKONEGODEVAERT_NAME", "P_ZENKONEGODEVAERT_INFO", null, false, b);
            Route.Route r = new Route.Route("R_BLINDWALLS_NAME");
            r.addPOI(punt1);
            r.addPOI(punt2);
            var myImageUri = new Uri("ms-appx:///Assets/Icons/Blackdot.png");
            GPSReader.UserLocation = new MapIcon()
            {
                Location = new Geopoint(new BasicGeoposition()
                {
                    Latitude = 51.58490990812901,
                    Longitude = 4.7939229011535645
                }),
            };
            GPSReader.route = r;
            GPSReader.SetupRoute();

        }
    }
}
