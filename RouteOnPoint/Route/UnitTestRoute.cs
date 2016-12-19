﻿using RouteOnPoint.LanguageUtil;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Newtonsoft.Json;
using RouteOnPoint.GPSHandler;

namespace RouteOnPoint.Route
{
    class UnitTestRoute
    {
        private RouteHandler _handler;
        private Route _route;

        public UnitTestRoute()
        {
            MultiLang.setLanguage(MultiLang.LanguageEnum.Dutch);
            _handler = new RouteHandler();

            /*
             * er kan maar 1 tegelijk uitgevoerd worden omdat beide methodes hetzelfde
             * file gebruiken. Commentarieër 1 methode om de andere te testen.
             */
            Task.Run(() => this.SaveRoute("test.json")).Wait();
            Task.Run(() => this.GetRoute("test.json")).Wait();

            /* eventuele breakpoint line om te kijken of alle data in de juiste
             * variabelen zit.
             */
            //string breakpoint = "Ik wil hier een breakpoint";

            /*
             * testen van RouteEscaped
             * dit moet via een emulator of fysieke telefoon getest worden.
             * Het liefst bovenstaande unittest uitcommentariëren en deze in een loop laten runnen
             *
            Geopath route = new Geopath();
            if (_handler.RouteEscaped(route))
            {
                // route is escaped
                Debug.WriteLine("Escaped!");
            }
            else
            {
                Debug.WriteLine("OnRoute!");
            }//*/
       
        }

        private void SaveRoute(string path)
        {
            _route = new RouteHelper().createHistoriscRoute();
            Task.Run(() => _handler.SaveRouteWithState(_route, path)).Wait();
        }

        private void GetRoute(string path)
        {
            Task<Route> r2 = null;
            Task.Run(() => r2 = _handler.GetRouteFromFile(path)).Wait();
            _route = r2.Result;
        }

    }
}