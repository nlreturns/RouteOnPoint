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
using Windows.UI.Xaml;
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
    }
}
