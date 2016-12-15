﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Maps;
using RouteOnPoint.Route;

namespace RouteOnPoint.GPSHandler
{
    public class GPSReader
    {
        public Geolocator Geolocator;
        public static Geopoint CurrentLocation;
        public MapControl Map;
        public bool IsPaused = false;

        public GPSReader(MapControl map)
        {
            SetupGPS();
            Map = map;
        }

        private async void SetupGPS()
        {
            //Gets the AccessStatus, if we have acces to the GPS
            var accessStatus = await Geolocator.RequestAccessAsync();

            //Switch case for the AccessStatus
            switch (accessStatus)
            {
                //Allowed acces
                case GeolocationAccessStatus.Allowed:
                    //Initaliases the GPS with custom parameters
                    Geolocator = new Geolocator { DesiredAccuracyInMeters = 20, ReportInterval = 2000 };
                    
                    //Activates GPS and gets first location
                    Geoposition pos = await Geolocator.GetGeopositionAsync();

                    //Sets CurrentLocation as the location
                    CurrentLocation = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = pos.Coordinate.Latitude,
                        Longitude = pos.Coordinate.Longitude

                    });

                    //Adds the event when the position changes
                    Geolocator.PositionChanged += OnPositionChangedAsync;

                    break;
                //Denied Access
                case GeolocationAccessStatus.Denied:
                    break;
                //Unspecified
                case GeolocationAccessStatus.Unspecified:
                    break;
            }
        }

        public async void SetupRoute(List<POI> points)
        {
            List<Geopoint> waypoints = new List<Geopoint>(points.Count);
            waypoints.Add(CurrentLocation);
            foreach (var point in points)
            {
                waypoints.Add(new Geopoint(point.Coordinate));
            }

            SetupGeoFence(points);

            var result = await MapRouteFinder.GetDrivingRouteFromWaypointsAsync(waypoints);
            if (result.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView viewOfRoute = new MapRouteView(result.Route);
                viewOfRoute.RouteColor = Colors.Orange;

                Map.Routes.Clear();
                // Add the new MapRouteView to the Routes collection
                // of the MapControl.
                Map.Routes.Add(viewOfRoute);

                // Fit the MapControl to the route.
                await Map.TrySetViewBoundsAsync(
                      result.Route.BoundingBox,
                      null,
                      Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
            }
            else
            {
                Debug.WriteLine("error with route");
            }

        }

        public void SetupGeoFence(List<POI> points)
        {
            GeofenceMonitor.Current.Geofences.Clear();
            foreach (var poi in points)
            {
                if (poi.Name != null)
                {
                    Geopoint point = new Geopoint(poi.Coordinate);
                    // Set the fence ID.
                    string fenceId = poi.Name;

                    // Define the fence location and radius.
                    BasicGeoposition position;
                    position.Latitude = point.Position.Latitude;
                    position.Longitude = point.Position.Longitude;
                    position.Altitude = point.Position.Altitude;
                    int radius = 20;

                    // Set the circular region for geofence.
                    Geocircle geocircle = new Geocircle(position, radius);

                    // Remove the geofence after the first trigger.
                    bool singleUse = true;

                    // Set the monitored states.
                    MonitoredGeofenceStates monitoredStates =
                        MonitoredGeofenceStates.Entered |
                        MonitoredGeofenceStates.Exited |
                        MonitoredGeofenceStates.Removed;

                    // Set how long you need to be in geofence for the enter event to fire.
                    TimeSpan dwellTime = TimeSpan.FromSeconds(5);

                    // Set how long the geofence should be active.
                    TimeSpan duration = TimeSpan.FromDays(1);

                    // Set up the start time of the geofence.
                    DateTimeOffset startTime = DateTime.Now;

                    // Create the geofence.
                    Geofence geofence = new Geofence(fenceId, geocircle, monitoredStates, singleUse, dwellTime,
                        startTime,
                        duration);
                    Debug.WriteLine("made a geofence at lat: " + point.Position.Latitude + " long: " +
                                    point.Position.Longitude);
                    GeofenceMonitor.Current.Geofences.Add(geofence);
                }
            }

        GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        }

        private async void OnPositionChangedAsync(Geolocator sender, PositionChangedEventArgs e)
        {
            //Set the currentlocation to the new position when the positions changes
                CurrentLocation = new Geopoint(new BasicGeoposition()
                {
                    Latitude = e.Position.Coordinate.Latitude,
                    Longitude = e.Position.Coordinate.Longitude
                });
        }

        public async void OnGeofenceStateChanged(GeofenceMonitor sender, object e)
        {
            //Gets all state reports
            var reports = sender.ReadReports();
            foreach (GeofenceStateChangeReport report in reports)
            {
                //Get the state of the geofence
                GeofenceState state = report.NewState;

                //Get the Geofence which state is changed
                Geofence geofence = report.Geofence;

                //Switch case to know which state it is
                switch (state)
                {
                    //Entered the geofence
                    case GeofenceState.Entered:
                        Debug.WriteLine("Entered geofence");
                        GeofenceMonitor.Current.Geofences.Remove(geofence);
                        //trigger the notification TODO
                        break;
                    //Removed the geofence
                    case GeofenceState.Removed:
                        Debug.WriteLine("Removing geofence");
                        break;
                    //Exited the geofence
                    case GeofenceState.Exited:
                        Debug.WriteLine("Left geofence");
                        break;
                    //No state
                    case GeofenceState.None:
                        break;
                }
            }
        }

        public async Task GoToUserLocationAsync(bool force)
        {
            if (force || CurrentLocation != null)
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.High, (() =>
                    {
                        Map.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(CurrentLocation, 1000));
                    }));
            else
            {
                MessageDialog dialog = new MessageDialog("No GPS, Please wait", "No GPS");
                dialog.ShowAsync();
            }
        }

        public Geopoint GetCurrentLocation()
        {
            //returns the last know location (updates every 2 seconds)
            return CurrentLocation;
        }
    }
}
