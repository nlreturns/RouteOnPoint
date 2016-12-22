using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace RouteOnPoint.Route
{
    /// <summary>
    /// Class that's capeble of creating routes.
    /// </summary>
    class RouteHelper
    {
        /// Create Historic Route
        /// <summary>
        /// Creates an instance of the historic route
        /// Adds the points to the route
        /// </summary>
        /// <returns>Instance of the blind wall object</returns>
        public Route createHistoriscRoute()
        {
            //Creates the route
            Route r = new Route("R_HISTORISCHEKILOMETER_NAME");
            //Adds points
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
            r.addPoint("P_BEGINHAVERMARKT_NAME", "P_BEGINHAVERMARKT_INFO", "ms-appx:///Assets/19.jpg", new BasicGeoposition() { Latitude = 51.353617, Longitude = 4.464667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.464993 });
            r.addPoint("P_GROTEKERK_NAME", "P_GROTEKERK_INFO", "ms-appx:///Assets/10.jpg", new BasicGeoposition() { Latitude = 51.353300, Longitude = 4.465167 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.353267, Longitude = 4.4645167 });
            r.addPoint("P_HETPOORTJE_NAME", "P_HETPOORTJE_INFO", null , new BasicGeoposition() { Latitude = 51.352917, Longitude = 4.465083 });
            r.addPoint("P_RIDDERSTRAAT_NAME", "P_RIDDERSTRAAT_INFO", null, new BasicGeoposition() { Latitude = 51.3532250, Longitude = 4.465450 });
            r.addPoint("P_GROTEMARKT_NAME", "P_GROTEMARKT_INFO", null, new BasicGeoposition() { Latitude = 51.352450, Longitude = 4.465933 });
            r.addPoint("P_BEVRIJDINGSMONUMENT_NAME", "P_BEVREIJDINGSMONUMENT_INFO", null, new BasicGeoposition() { Latitude = 51.352817, Longitude = 4.465800 });
            r.addPoint("P_STADHUIS_NAME", "P_STADHUIS_INFO", null, new BasicGeoposition() { Latitude = 51.353250, Longitude = 4.465667 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352783, Longitude = 4.465817 });
            r.addPoint(null, null, null, new BasicGeoposition() { Latitude = 51.352500, Longitude = 4.465933 });
            r.addPoint("P_ANTONIUSVANPADUAKERK_NAME", "P_ANTONIUSVANPADUAKERK_INFO" , null, new BasicGeoposition() { Latitude = 51.352583, Longitude = 4.466350 });
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
            
            return r;
        }
        ///Create a Blind Wall route
        /// <summary>
        /// Creates an instance blind wall route
        /// Then adds the points.
        /// </summary>
        /// <remarks>Still needs to be completed</remarks>
        /// <returns></returns>
        public Route createBlindWalls()
        {
            //TODO Add remaining points
            //Create route
            Route r = new Route("R_BLINDWALLS_NAME");

            //Add Points
            r.addPoint("P_ZENKONE2012_NAME", "P_ZENKONE2012_INFO", "ms-appx:///Assets/POI/BlindWalls/B16.jpg", new BasicGeoposition() { Latitude = 51.589169, Longitude = 4.780327 }, false, false);
            r.addPoint("P_ANTIHELD_NAME", "P_ANTIHELD_INFO", "ms-appx:///Assets/POI/BlindWalls/AntiHeld.jpg", new BasicGeoposition() { Latitude = 51.589221118472096, Longitude = 4.773001266626011 }, false, false);
            r.addPoint("P_TECKELKMA_NAME", null, "ms-appx:///Assets/POI/BlindWalls/teckelKMA.jpg", new BasicGeoposition() { Latitude = 51.59018277245498, Longitude = 4.773666854492149 }, false, false);
            r.addPoint("P_STAYNICESCOUTING_NAME", null, "ms-appx:///Assets/POI/BlindWalls/StayNiceScouting.jpg", new BasicGeoposition() { Latitude = 51.5749025, Longitude = 4.759518500000013 }, false, false);

            //Op volgorde
            r.addPoint("P_HEDOF_NAME", "P_HEDOF_INFO", "ms-appx:///Assets/Hedof.jpg", new BasicGeoposition() { Latitude = 51.58455483678075, Longitude = 4.777700496820103 }, false, false);
            r.addPoint("P_IWANSMIT_NAME", "P_IWANSMIT_INFO", "ms-appx:///Assets/POI/BlindWalls/IwanSmit.jpg", new BasicGeoposition() { Latitude = 51.58983436557588, Longitude = 4.774428201821934 }, false, false);
            //4
            r.addPoint("P_RUTGERTERMOHLEN2_NAME", "P_RUTGERTERMOHLEN2_INFO", "ms-appx:///Assets/POI/BlindWalls/RutgerTermohlen.jpg", new BasicGeoposition() { Latitude = 51.58932052214467, Longitude = 4.772843778046081 }, false, false);
            r.addPoint("P_JORENJOSHUA_NAME", "P_JORENJOSHUA_INFO", "ms-appx:///Assets/POI/BlindWalls/JorenJoshua.jpg", new BasicGeoposition() { Latitude = 51.589221118472096, Longitude = 4.773001266626011 }, false, false);
            //7
            r.addPoint("P_MCITY_NAME", "P_MCITY_INFO", "ms-appx:///Assets/POI/BlindWalls/MCity.jpg", new BasicGeoposition() { Latitude = 51.5881762, Longitude = 4.770835600000055 }, false, false);
            r.addPoint("P_CRANIO_NAME", "P_CRANIO_INFO", "ms-appx:///Assets/POI/BlindWalls/Cranio.jpg", new BasicGeoposition() { Latitude = 51.58913446332252, Longitude = 4.779856992868076 }, false, false);
            r.addPoint("P_ZENKONE_NAME", "P_ZENKONE_INFO", "ms-appx:///Assets/POI/BlindWalls/ZenkOne.jpg", new BasicGeoposition() { Latitude = 51.58923445001889, Longitude = 4.780296875146519 }, false, false);
            r.addPoint("P_AKACORLEONE_NAME", "P_AKACORLEONE_INFO", "ms-appx:///Assets/POI/BlindWalls/AkaCorleone.jpg", new BasicGeoposition() { Latitude = 51.585214811431484, Longitude = 4.776337934640537 }, false, false);
            r.addPoint("P_ARONVELLEKOOPLÉON_NAME", "P_ARONVELLEKOOPLÉON_INFO", "ms-appx:///Assets/POI/BlindWalls/AronVellekoop.jpg", new BasicGeoposition() { Latitude = 51.5843711, Longitude = 4.775432300000034 }, false, false);
            r.addPoint("P_FRM_NAME", "P_FRM_INFO", "ms-appx:///Assets/POI/BlindWalls/FRM.jpg", new BasicGeoposition() { Latitude = 51.58412151487764, Longitude = 4.776166273263584 }, false, false);
            r.addPoint("P_ILSEWEISFELT_NAME", "P_ILSEWEISFELT_INFO", "ms-appx:///Assets/POI/BlindWalls/IlseWeisfelt.jpg", new BasicGeoposition() { Latitude = 51.58378152095278, Longitude = 4.778000904229771 }, false, false);
            r.addPoint("P_THOMAS&JURGEN_NAME", "P_THOMAS&JURGEN_INFO", "ms-appx:///Assets/POI/BlindWalls/ThomasJurgen.jpg", new BasicGeoposition() { Latitude = 51.58398818422993, Longitude = 4.7776039372955665 }, false, false);
            r.addPoint("P_BRUCETMC_NAME", "P_BRUCETMC_INFO", "ms-appx:///Assets/POI/BlindWalls/BruceTMC.jpg", new BasicGeoposition() { Latitude = 51.58404151653597, Longitude = 4.777872158197056 }, false, false);
            r.addPoint("P_JOHANMOORMAN_NAME", "P_JOHANMOORMAN_INFO", "ms-appx:///Assets/POI/BlindWalls/JohanMoorman.jpg", new BasicGeoposition() { Latitude = 51.584287435878025, Longitude = 4.777740675532527 }, false, false);
            r.addPoint("P_HEDOFOASE_NAME", "P_HEDOFOASE_INFO", "ms-appx:///Assets/POI/BlindWalls/B15.jpg", new BasicGeoposition() { Latitude = 51.586900, Longitude = 4.772058 }, false, false);
            r.addPoint("P_STEPHENPOWERS_NAME", "P_STEPHENPOWERS_INFO", "ms-appx:///Assets/POI/BlindWalls/StephenPowers.jpeg", new BasicGeoposition() { Latitude = 51.5847281643849, Longitude = 4.777539564279209 }, false, false);
            r.addPoint("P_MIKEPERRY_NAME", "P_MIKEPERRY_INFO", "ms-appx:///Assets/POI/BlindWalls/MikePerry.jpg", new BasicGeoposition() { Latitude = 51.584731497601574, Longitude = 4.7771318685089454 }, false, false);
            r.addPoint("P_JOBWOUTERS_NAME", "P_JOBWOUTERS_INFO", "ms-appx:///Assets/POI/BlindWalls/B24.jpg", new BasicGeoposition() { Latitude = 51.584781, Longitude = 4.777345 }, false, false);
            r.addPoint("P_RUTGERTERMOHLEN_NAME", "P_RUTGERTERMOHLEN_INFO", "ms-appx:///Assets/POI/BlindWalls/B23.jpg", new BasicGeoposition() { Latitude = 51.589321, Longitude = 4.772844 }, false, false);
            r.addPoint("P_JEFFCANHAM_NAME", "P_JEFFCANHAM_INFO", "ms-appx:///Assets/POI/BlindWalls/B22.jpg", new BasicGeoposition() { Latitude = 51.58503, Longitude = 4.777465 }, false, false);
            r.addPoint("P_FINDAC_NAME", "P_FINDAC_INFO", "ms-appx:///Assets/POI/BlindWalls/B21.jpg", new BasicGeoposition() { Latitude = 51.567259, Longitude = 4.785318 }, false, false);
            r.addPoint("P_LUCAFONT_NAME", "P_LUCAFONT_INFO", "ms-appx:///Assets/POI/BlindWalls/B13.jpg", new BasicGeoposition() { Latitude = 51.584961, Longitude = 4.775777 }, false, false);
            r.addPoint("P_BENEINE_NAME", "P_BENEINE_INFO", "ms-appx:///Assets/POI/BlindWalls/B11.jpg", new BasicGeoposition() { Latitude = 51.595472, Longitude = 4.771402 }, false, false);
            r.addPoint("P_THUNDER&BOLD_NAME", "P_THUNDER&BOLD_INFO", "ms-appx:///Assets/POI/BlindWalls/B10.jpg", new BasicGeoposition() { Latitude = 51.579412, Longitude = 4.764087 }, false, false);
            r.addPoint("P_NOL_NAME", "P_NOL_INFO", "ms-appx:///Assets/POI/BlindWalls/B9.jpg", new BasicGeoposition() { Latitude = 51.587121, Longitude = 4.768484 }, false, false);
            r.addPoint("P_KRATJEBEELD_NAME", "P_KRATJEBEELD_INFO", "ms-appx:///Assets/POI/BlindWalls/B8.jpg", new BasicGeoposition() { Latitude = 51.584043, Longitude = 4.77689 }, false, false);
            r.addPoint("P_HELL'O_NAME", "P_HELL'O_INFO", "ms-appx:///Assets/POI/BlindWalls/B7.jpg", new BasicGeoposition() { Latitude = 51.58523, Longitude = 4.776137 }, false, false);
            r.addPoint("P_SUPERA_NAME", "P_SUPERA_INFO", "ms-appx:///Assets/POI/BlindWalls/B20.jpg", new BasicGeoposition() { Latitude = 51.598942, Longitude = 4.766836 }, false, false);
            r.addPoint("P_ZENKONEVEILINGKADE_NAME", "P_ZENKONEVEILINGKADE_INFO", "ms-appx:///Assets/POI/BlindWalls/B19.jpg", new BasicGeoposition() { Latitude = 51.598891, Longitude = 4.766909 }, false, false);
            r.addPoint("P_STAYNICEBLOOS_NAME", "P_STAYNICEBLOOS_INFO", "ms-appx:///Assets/POI/BlindWalls/B18.jpg", new BasicGeoposition() { Latitude = 51.599398, Longitude = 4.770817 }, false, false);
            r.addPoint("P_STAYNICEKOP_NAME", "P_STAYNICEKOP_INFO", "ms-appx:///Assets/POI/BlindWalls/B17.jpg", new BasicGeoposition() { Latitude = 51.599945, Longitude = 4.769521 }, false, false);
            r.addPoint("P_ZENKONE2012_NAME", "P_ZENKONE2012_INFO", "ms-appx:///Assets/POI/BlindWalls/B16.jpg", new BasicGeoposition() { Latitude = 51.589169, Longitude = 4.780327 }, false, false);
            r.addPoint("P_COMBATSUPERMURAL_NAME", "P_COMBATSUPERMURAL_INFO", "ms-appx:///Assets/POI/BlindWalls/B14.jpg", new BasicGeoposition() { Latitude = 51.596109, Longitude = 4.766329 }, false, false);
            r.addPoint("P_HEDOF2_NAME", "P_HEDOF2_INFO", "ms-appx:///Assets/POI/BlindWalls/Hedof2.jpg", new BasicGeoposition() { Latitude = 51.59216729521042, Longitude = 4.770898414758335 }, false, false);
            r.addPoint("P_TECKELKMA_NAME", null, "ms-appx:///Assets/POI/BlindWalls/teckelKMA.jpg", new BasicGeoposition() { Latitude = 51.59018277245498, Longitude = 4.773666854492149 }, false, false);
            r.addPoint("P_STAYNICE_NAME", "P_STAYNICE_INFO", "ms-appx:///Assets/POI/BlindWalls/StayNice.jpg", new BasicGeoposition() { Latitude = 51.59452899999999, Longitude = 4.778975299999956 }, false, false);
            r.addPoint("P_NOODLEINC_NAME", "P_NOODLEINC_INFO", "ms-appx:///Assets/POI/BlindWalls/B12.jpg", new BasicGeoposition() { Latitude = 51.588103, Longitude = 4.774052 }, false, false);
            r.addPoint("P_DAMIENPOULAINBOSCHSTRAAT_NAME", "P_DAMIENPOULAINBOSCHSTRAAT_INFO", "ms-appx:///Assets/POI/BlindWalls/B7.jpg", new BasicGeoposition() { Latitude = 51.591129, Longitude = 4.783754 }, false, false);
            r.addPoint("P_DAMIENPOULAINVANCOOTHPLEIN_NAME", "P_DAMIENPOULAINVANCOOTHPLEIN_INFO", "ms-appx:///Assets/POI/BlindWalls/B6.jpg", new BasicGeoposition() { Latitude = 51.582854, Longitude = 4.777061 }, false, false);
            r.addPoint("P_DZIA_NAME", "P_DZIA_INFO", "ms-appx:///Assets/POI/BlindWalls/B5.jpg", new BasicGeoposition() { Latitude = 51.596971, Longitude = 4.788051 }, false, false);
            r.addPoint("P_MAIKKIRANTALA_NAME", "P_MAIKKIRANTALA_INFO", "ms-appx:///Assets/POI/BlindWalls/B4.jpg", new BasicGeoposition() { Latitude = 51.585579, Longitude = 4.777428 }, false, false);
            r.addPoint("P_JUKKAHAKANEN_NAME", "P_JUKKAHAKANEN_INFO", "ms-appx:///Assets/POI/BlindWalls/B3.jpg", new BasicGeoposition() { Latitude = 51.588161, Longitude = 4.778344 }, false, false);
            //46
            //47
            //48
            //49
            r.addPoint("P_ZENKONEGODEVAERT_NAME", "P_ZENKONEGODEVAERT_INFO", "ms-appx:///Assets/POI/BlindWalls/B1.jpg", new BasicGeoposition() { Latitude = 51.5819112, Longitude = 4.7757498 }, false, false);
            r.addPoint("P_STAYNICELUNETTUNNEL_NAME", "P_STAYNICELUNETTUNNEL_INFO", "ms-appx:///Assets/POI/BlindWalls/B2.jpg", new BasicGeoposition() { Latitude = 51.592311, Longitude = 4.757159 }, false, false);
            return r;
        }

    }
}
