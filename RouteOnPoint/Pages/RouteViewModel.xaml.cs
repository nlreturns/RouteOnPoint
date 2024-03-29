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
using RouteOnPoint.Route;
using Windows.UI.Xaml.Controls.Maps;
using RouteOnPoint.LanguageUtil;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteViewModel : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public string path ="/Assets/Flags/CombinedFlag.png";

        public RouteViewModel()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;
            GPSReader.rootFrame = rootFrame;


            RouteButtonsEnabler(false);
        }


        //Button to center the screen on the users location
        private async void CenterLocationButton_Click(object sender, RoutedEventArgs e)
        {
            await GPSReader.GoToUserLocationAsync(true);
        }

        //Button to show the help page
        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            rootFrame.Navigate(typeof(AssistViewModel));
        }

        //Button to play or pause the route session
        private void PlayPauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (GPSReader.IsPaused)
            {
                Notification.Notify(MultiLang.GetContent("ROUTEVIEWMODEL_PAUSENOTIFY_UNPAUSE"), "");
                GPSReader.IsPaused = false;
            }
            else
            {
                Notification.Notify(MultiLang.GetContent("ROUTEVIEWMODEL_PAUSENOTIFY_PAUSE"), "");
                GPSReader.IsPaused = true;
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
            AppViewBackButtonVisibility.Collapsed;

            if (GPSReader.created) { GPSReader.UserLocation.Title = MultiLang.GetContent("GPSREADER_LOCATION_TEXT"); }
            
            this.Frame.BackStack.Clear();
            if (!GPSReader.created)
            {           
                GPSReader.created = true;
                GPSReader.AddMap(myMap);
                await GPSReader.SetupGPS();

                //                List<POI> points = new List<POI>();
                //                points.Add(new POI("shizzle", null, null, true, new BasicGeoposition() { Latitude = 51.584555, Longitude = 4.793667 }));
                //                points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.585035, Longitude = 4.794096 }));
                //            points.Add(new POI("shine", null, null, false, new BasicGeoposition() { Latitude = 51.586575, Longitude = 4.791757 }));
                //            points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.588976, Longitude = 4.780673 }));
                //            points.Add(new POI("lolz", null, null, false, new BasicGeoposition() { Latitude = 51.591649, Longitude = 4.785404 }));
                //            points.Add(new POI(null, null, null, false, new BasicGeoposition() { Latitude = 51.595011, Longitude = 4.783865 }));
                GPSReader.SetupRoute();
                RouteButtonsEnabler(true);
            }
            else
            {
                myMap = GPSReader.Map;
            }

        }

        public void RouteButtonsEnabler(bool change)
        {
            PlayPauseButton.IsEnabled = change;
            CenterLocationButton.IsEnabled = change;

            if (change == false)
            {
                PlayPauseButton.Visibility = Visibility.Collapsed;
                CenterLocationButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                PlayPauseButton.Visibility = Visibility.Visible;
                CenterLocationButton.Visibility = Visibility.Visible;
            }

        }

        private void myMap_MapElementClick(Windows.UI.Xaml.Controls.Maps.MapControl sender, Windows.UI.Xaml.Controls.Maps.MapElementClickEventArgs args)
        {
            MapIcon myClickedIcon = args.MapElements.FirstOrDefault(x => x is MapIcon) as MapIcon;

            char[] bar = new char[] { '-' };
            string[] splitted = myClickedIcon.Title.Split(bar);
            POI p = null;
            foreach (var point in GPSReader.route._points)
            {
                if(point._name!=null)
                if (MultiLang.GetContent(point._name).Contains(splitted[0]))
                {
                    p = point;
                }
            }
            if (p != null)
            {
                Frame.Navigate(typeof(POIViewModel), p);
            }
            //            POI p = GPSReader.route._points.Find(x => x._name == myClickedIcon.Title);
        }

        private void ChangeLanguage_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LanguageViewModel), this);
        }
    }
}
