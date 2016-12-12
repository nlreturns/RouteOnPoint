using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Core;

namespace RouteOnPoint.GPSHandler
{
    class GPSReader
    {
        public Geolocator Geolocator;
        public Geopoint CurrentLocation;

        public GPSReader()
        {
            SetupGPS();
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
                    Geolocator = new Geolocator { DesiredAccuracyInMeters = 5, ReportInterval = 2000 };
                    
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

        public void SetupGeoFence(Geopoint point, string name, double radius)
        {
            // Set the fence ID.
            string fenceId = name;

            // Define the fence location and radius.
            BasicGeoposition position;
            position.Latitude = point.Position.Latitude;
            position.Longitude = point.Position.Longitude;
            position.Altitude = point.Position.Altitude;

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
            Geofence geofence = new Geofence(fenceId, geocircle, monitoredStates, singleUse, dwellTime, startTime, duration);
            GeofenceMonitor.Current.Geofences.Add(geofence);
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

        public Geopoint GetCurrentLocation()
        {
            //returns the last know location (updates every 2 seconds)
            return CurrentLocation;
        }
    }
}
