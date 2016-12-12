using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    class RouteHelper
    {
        public Route createHistoriscRoute()
        {
            Route r = new Route("R_HISTORISCHEKILOMETER_NAME");
            r.addPoint("P_VVV_NAME", "P_VVV_INFO", "ms-appx:///Assets/2.jpg", new BasicGeoposition() { Latitude = 51.356467, Longitude = 4.467650 });
            r.addPoint("P_LIEFDESZUSTER_NAME", "P_LIEFDESZUSTER_INFO", "ms-appx:///Assets/3.jpg", new BasicGeoposition() { Latitude = 51.356967, Longitude = 4.467333 });
            r.addPoint("P_NASSAUBARONIEMONUMENT_NAME", "P_NASSAUBARONIEMONUMENT_INFO", "ms-appx:///Assets/4.jpg", new BasicGeoposition() { Latitude = 51.355500, Longitude = 4.467817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.355500, Longitude = 4.467633 });
            r.addPoint("P_THELIGHTHOUSE_NAME", "P_THELIGHTHOUSE_INFO", "ms-appx:///Assets/5.jpg", new BasicGeoposition() { Latitude = 51.355700, Longitude = 4.467083 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.355600, Longitude = 4.466750 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.354367, Longitude = 4.466200 });
            r.addPoint("P_KASTEELVANBREDA_NAME", "P_KASTEELVANBREDA_INFO", "ms-appx:///Assets/9.jpg", new BasicGeoposition() { Latitude = 51.354367, Longitude = 4.465700 });
            r.addPoint("P_STADHOUDERSPOORT_NAME", "P_STADHOUDERSPOORT_INFO", "ms-appx:///Assets/11.jpg", new BasicGeoposition() { Latitude = 51.353817, Longitude = 4.465683 });
            r.addPoint(null, null, "ms - appx:///Assets/12.jpg", new BasicGeoposition() { Latitude = 51.354200, Longitude = 4.465600 });
            r.addPoint(null, null, "ms - appx:///Assets/8.jpg", new BasicGeoposition() { Latitude = 51.354233, Longitude = 4.465000 });
            r.addPoint("P_HUISVANBRECHT_NAME", "P_HUISVANBRECHT_INFO", "ms-appx:///Assets/7.jpg", new BasicGeoposition() { Latitude = 51.354017, Longitude = 4.464617 });
            r.addPoint("P_SPANJAARDSGAT_NAME", "P_SPANJAARDSGAT_INFO", "ms-appx:///Assets/22.jpg", new BasicGeoposition() { Latitude = 51.354117, Longitude = 4.464067 });
            r.addPoint("P_BEGINVISMARKT_NAME", "P_BEGINVISMARKT_INFO", "ms-appx:///Assets/20.jpg", new BasicGeoposition() { Latitude = 51.353900, Longitude = 4.464000 });
            r.addPoint("P_BEGINHAVERMARKT_NAME", "P_BEGINHAVERMARKT_INFO", "ms - appx:///Assets/19.jpg", new BasicGeoposition() { Latitude = 51.353617, Longitude = 4.464667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.464993 });
            r.addPoint("P_GROTEKERK_NAME", "P_GROTEKERK_INFO", "ms-appx:///Assets/10.jpg", new BasicGeoposition() { Latitude = 51.353300, Longitude = 4.465167 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.4645167 });
            r.addPoint("P_HETPOORTJE_NAME", "P_HETPOORTJE_INFO", "" , new BasicGeoposition() { Latitude = 51.352917, Longitude = 4.465083 });
            r.addPoint("P_RIDDERSTRAAT_NAME", "P_RIDDERSTRAAT_INFO", "", new BasicGeoposition() { Latitude = 51.3532250, Longitude = 4.465450 });
            r.addPoint("P_GROTEMARKT_NAME", "P_GROTEMARKT_INFO", null, new BasicGeoposition() { Latitude = 51.352450, Longitude = 4.465933 });
            r.addPoint("P_BEVRIJDINGSMONUMENT_NAME", "P_BEVREIJDINGSMONUMENT_INFO", "", new BasicGeoposition() { Latitude = 51.352817, Longitude = 4.465800 });
            r.addPoint("P_STADHUIS_NAME", "P_STADHUIS_INFO", "", new BasicGeoposition() { Latitude = 51.353250, Longitude = 4.465667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352783, Longitude = 4.465817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352500, Longitude = 4.465933 });
            r.addPoint("P_ANTONIUSVANPADAUKERK_NAME", "P_ANTONIUSVANPADUAKER_INFO" , null, new BasicGeoposition() { Latitude = 51.352583, Longitude = 4.466350 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352967, Longitude = 4.467100 });
            r.addPoint("P_BIBLIOTHEEK_NAME", "P_BIBLIOTHEEK_INFO", null, new BasicGeoposition() { Latitude = 51.352800, Longitude = 4.467367 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352417, Longitude = 4.468133 });
            r.addPoint("P_KLOOSTERKAZERNE_NAME", "P_KLOOSTERKAZERNE_INFO",null , new BasicGeoposition() { Latitude = 51.352417, Longitude = 4.468167 });
            r.addPoint("P_CHASSETHEATER_NAME", "P_CHASSETHEATER_INFO", null, new BasicGeoposition() { Latitude = 51.352650, Longitude = 4.46819200 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352650, Longitude = 4.468750 });
            r.addPoint("P_BINDINGVANISAAC_NAME", "P_BINDINGVANISAAC_INFO", null, new BasicGeoposition() { Latitude = 51.353167, Longitude = 4.46818533 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353700, Longitude = 4.468267 });
            r.addPoint("P_BEYERD_NAME", "P_BEYERD_INFO", null, new BasicGeoposition() { Latitude = 51.353800, Longitude = 4.46818600 });
            r.addPoint(null,null, null, new BasicGeoposition() { Latitude = 51.353700, Longitude = 4.46818267});
            r.addPoint("P_GASTHUISPOORT_NAME", "P_GASTHUISPOOR_INFO" , null, new BasicGeoposition() { Latitude = 51.353733, Longitude = 4.468000 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353650, Longitude = 4.467917 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353417, Longitude = 4.467817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353133, Longitude = 4.467000 });
            r.addPoint("P_WILLEMMERKXTUIN_NAME", "P_WILLEMMERKXTUIN_INFO", null, new BasicGeoposition() { Latitude = 51.353467, Longitude = 4.466767 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353467, Longitude = 4.466767 });
            r.addPoint("P_BEGIJNENHOF_NAME", "P_BEGIJNENHOF_INFO", null, new BasicGeoposition() { Latitude = 51.353817, Longitude = 4.467017 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353800, Longitude = 4.466683 });
            r.addPoint("P_VVV_NAME", "P_VVV_INFO", "ms-appx:///Assets/2.jpg", new BasicGeoposition() { Latitude = 51.356467, Longitude = 4.467650 });
            return r;
        }

    }
}
