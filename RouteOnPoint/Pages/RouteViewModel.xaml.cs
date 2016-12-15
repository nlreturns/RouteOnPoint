﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RouteOnPoint.GPSHandler;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteViewModel : Page
    {

        public GPSReader Gps;

        public RouteViewModel()
        {
            this.InitializeComponent();
            Gps = new GPSReader(myMap);
//            List<POI> points = new List<POI>();
//            points.Add(new POI("shizzle", null, null, false, new BasicGeoposition() { Latitude = 51.584555, Longitude = 4.793667 }));
//            points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.585035, Longitude = 4.794096 }));
//            points.Add(new POI("shine", null, null, false, new BasicGeoposition() { Latitude = 51.586575, Longitude = 4.791757 }));
//            points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.588976, Longitude = 4.780673 }));
//            points.Add(new POI("lolz", null, null, false, new BasicGeoposition() { Latitude = 51.591649, Longitude = 4.785404 }));
//            points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.595011, Longitude = 4.783865 }));
//            Gps.SetupRoute(points);
        }

        private void CenterLocationButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (Gps.IsPaused)
            {
                Gps.IsPaused = false;
            }
            else
            {
                Gps.IsPaused = true;
            }
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;
            this.Frame.BackStack.Clear();
        }
    }
}
