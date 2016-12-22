using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Devices.PointOfService;
using Windows.Foundation;
using Windows.Services.Maps;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls.Maps;
using RouteOnPoint.Route;
using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Pages;
using Windows.UI.Xaml.Controls;
using Windows.ApplicationModel.Background;

namespace RouteOnPoint.GPSHandler
{
    public static class GPSReader
    {
        public static Geolocator Geolocator;
        private static Geopoint _lastGeopoint;
        private static List<BasicGeoposition> _walkedroute = new List<BasicGeoposition>();
        public static MapIcon UserLocation;
        public static MapControl Map;
        public static bool IsPaused = false;
        public static Route.Route route;
        internal static bool created = false;
        public static Frame rootFrame;



        public static  async void AddMap(MapControl map)
        {
            Map = map;
        }


        public static async Task<bool> SetupGPS()
        {
            //Gets the AccessStatus, if we have acces to the GPS
            var accessStatus = await Geolocator.RequestAccessAsync();
         
            //Switch case for the AccessStatus
            switch (accessStatus)
            {
                //Allowed acces
                case GeolocationAccessStatus.Allowed:
                    //Initaliases the GPS with custom parameters
                    Geolocator = new Geolocator { DesiredAccuracyInMeters = 20, MovementThreshold = 5};
                    
                    //Activates GPS and gets first location
                    Geoposition pos = await Geolocator.GetGeopositionAsync();

                    //set usericon
                    var myImageUri = new Uri("ms-appx:///Assets/Icons/Blackdot.png");
                    UserLocation = new MapIcon()
                    {
                        Location = new Geopoint(new BasicGeoposition()
                        {
                            Latitude = pos.Coordinate.Latitude,
                            Longitude = pos.Coordinate.Longitude

                        }),
                        NormalizedAnchorPoint = new Point(0.5, 1.0),
                        Title = MultiLang.GetContent("GPSREADER_LOCATION_TEXT"),
                        ZIndex = 0,
                        Image = RandomAccessStreamReference.CreateFromUri(myImageUri)
                    };

                    Map.MapElements.Add(UserLocation);

                    //Adds the event when the position changes
                    Geolocator.PositionChanged += OnPositionChangedAsync;
                    Geolocator.StatusChanged += OnStatusChanged;
                    GoToUserLocationAsync(true);
                    break;
                //Denied Access
                case GeolocationAccessStatus.Denied:
                    break;
                //Unspecified
                case GeolocationAccessStatus.Unspecified:
                    break;
                }

            return true;
        }

        public static async void SetupRoute()
        {
            List<POI> points = route._points;
            List<Geopoint> waypoints = new List<Geopoint>();
            waypoints.Add(UserLocation.Location);
            foreach (var point in points)
            {
                waypoints.Add(new Geopoint(point._coordinate));
            }

            SetupGeoFence(points);
            MapRouteRestrictions restrictions = new MapRouteRestrictions();
            restrictions = MapRouteRestrictions.None;
            MapRouteOptimization optimize = MapRouteOptimization.Distance;
            MapRouteFinderResult result;
            if (route._name.Equals("R_BLINDWALLS_NAME"))
            {
                result = await MapRouteFinder.GetDrivingRouteFromWaypointsAsync(waypoints, optimize, restrictions);
            }
            else
            {
                result = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(waypoints);
            }
            if (result.Status == MapRouteFinderStatus.Success)
            {
                MapRouteView viewOfRoute = new MapRouteView(result.Route);
                viewOfRoute.RouteColor = Colors.Orange;
                try
                {
                    Map.Routes.Clear();
                    // Add the new MapRouteView to the Routes collection
                    // of the MapControl.
                    Map.Routes.Add(viewOfRoute);

                    // Fit the MapControl to the route.
                    await Map.TrySetViewBoundsAsync(
                          result.Route.BoundingBox,
                          null,
                          Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
                    DrawIcons();
                }
                catch (Exception e)
                {

                }
            }
            else
            {
#if DEBUG
                Debug.WriteLine("error with route");
#endif
            }

        }

        public static void DrawIcons()
        {
            foreach (var poi in route._points)
            {
                if (poi._name != null)
                {
                    var pushpin = new MapIcon();

                    // assign pushpin geoposition
                    pushpin.Location = new Geopoint(poi._coordinate);

                    // assign pushpin title
                    pushpin.Title = MultiLang.GetContent(poi._name);

                    //  make sure pushpin always appears
                    pushpin.CollisionBehaviorDesired = MapElementCollisionBehavior.RemainVisible;

                    // set pushpin bottom center over geoposition
                    pushpin.NormalizedAnchorPoint = new Point(0.5, 1.0);

                    

                    // set custom image to pushpin
                    if (poi._visited)
                    {
                        var myImageUri = new Uri("ms-appx:///Assets/Icons/GreenIcon.png");
                        pushpin.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                    }
                    else
                    {
                        var myImageUri = new Uri("ms-appx:///Assets/Icons/BlueIcon.png");
                        pushpin.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                    }

                    // put pushpin on the map
                    
                    Map.MapElements.Add(pushpin);
                }
            }

        }

        public static async void SetupGeoFence(List<POI> points)
        {
            

            GeofenceMonitor.Current.Geofences.Clear();
            foreach (var poi in points)
            {
                //Debug.WriteLine();
                if (poi._name != null)
                {
                    Geopoint point = new Geopoint(poi._coordinate);
                    // Set the fence ID.
                    string fenceId = poi._name;

                    string s = MultiLang.GetContent(fenceId);

                    await RegisterBackgroundTasks(s);

                    if (IsTaskRegistered(s))
                    {
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
            }

            GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        }

        //Registers the background task with a LocationTrigger
        static async Task RegisterBackgroundTasks(string fenceId)
        {
            var access = await BackgroundExecutionManager.RequestAccessAsync();


            if (access == BackgroundAccessStatus.Denied)
            {

            }
            else
            {
                
                var taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = fenceId;
                
                taskBuilder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));
                taskBuilder.SetTrigger(new LocationTrigger(LocationTriggerType.Geofence));

                taskBuilder.TaskEntryPoint = typeof(BackGroundTask.GeoFenceTask).FullName;

                var registration = taskBuilder.Register();

                registration.Completed += (sender, e) =>
                {
                    try
                    {
                        e.CheckResult();
                    }
                    catch (Exception error)
                    {
                        Debug.WriteLine(error);
                    }
                };



            }

        }

        static bool IsTaskRegistered(string fenceId)
        {
            var Registered = false;
            var entry = BackgroundTaskRegistration.AllTasks.FirstOrDefault(keyval => keyval.Value.Name == fenceId);
            if (entry.Value != null)
                Registered = true;
            return Registered;
        }

        private static async void OnPositionChangedAsync(Geolocator sender, PositionChangedEventArgs e)
        {
            //Set the currentlocation to the new position when the positions changes
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
               CoreDispatcherPriority.High,  () =>
               {
                   _lastGeopoint = UserLocation.Location;
                   UserLocation.Location = new Geopoint(new BasicGeoposition()
                   {
                       Latitude = e.Position.Coordinate.Latitude,
                       Longitude = e.Position.Coordinate.Longitude

                   });
    
                   
                   if (!Notification.IsPaused)
                   {
                       foreach (POI nextPoint in route._points)
                       {
                           GetDi(nextPoint);
                       }

                       // instantiate mappolyline
                       var polyline = new MapPolyline();

                       // add geopsitions to path
                       BasicGeoposition basicGeoposition = new BasicGeoposition() { Latitude = _lastGeopoint.Position.Latitude, Longitude = _lastGeopoint.Position.Longitude };
                       BasicGeoposition basicGeoposition2 = new BasicGeoposition() { Latitude = UserLocation.Location.Position.Latitude, Longitude = UserLocation.Location.Position.Longitude };
                       _walkedroute.Add(basicGeoposition2);
                       polyline.Path = new Geopath(new List<BasicGeoposition>() { basicGeoposition, basicGeoposition2 });

                       //set appearance of connector line
                       polyline.StrokeColor = Colors.Gray;
                       polyline.StrokeThickness = 7;
                       polyline.ZIndex = 16;
                       Map.MapElements.Add(polyline);
                   }
                   GoToUserLocationAsync(false);
               });
        }


        private static void DrawVisitedRoute()
        {
            
        }

        //check if gps signal is avaibale
        async private static void OnStatusChanged(Geolocator sender, StatusChangedEventArgs e)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Show the location setting message only if status is disabled.

                switch (e.Status)
                {
                    case PositionStatus.Ready:
                        // Location platform is providing valid data.
                        break;

                    case PositionStatus.Initializing:
                        // Location platform is attempting to acquire a fix. ;
                        break;

                    case PositionStatus.NoData:
                        Notification.Notify(MultiLang.GetContent("GPSREADER_GPSAVAILABLE_TITLE"), MultiLang.GetContent("GPSREADER_GPSAVAILABLE_TEXT"));
                        // Location platform could not obtain location data.
                        break;

                    case PositionStatus.Disabled:
                        // The permission to access location data is denied by the user or other policies.
                        break;

                    case PositionStatus.NotInitialized:
                        // The location platform is not initialized. This indicates that the application 
                        // has not made a request for location data.
                        break;

                    case PositionStatus.NotAvailable:
                        // The location platform is not available on this version of the OS.
                        break;

                    default:
                        break;
                }
            });
        }

        public static async void OnGeofenceStateChanged(GeofenceMonitor sender, object e)
        {
            //Gets all state reports
            var reports = sender.ReadReports();
            foreach (GeofenceStateChangeReport report in reports)
            {
                //Get the state of the geofence
                GeofenceState state = report.NewState;

                //Get the Geofence which state is 


                Geofence geofence = report.Geofence;

                //Switch case to know which state it is
                switch (state)
                {
                    //Entered the geofence
                    case GeofenceState.Entered:
                        Debug.WriteLine("Entered geofence");
                        if (!geofence.Id.Equals("Route"))
                        {
                            GeofenceMonitor.Current.Geofences.Remove(geofence);
                            handleGeoFenceEntered(geofence);
                        }
                        break;
                    //Removed the geofence
                    case GeofenceState.Removed:
                        Debug.WriteLine("Removing geofence");
                        break;
                    //Exited the geofence
                    case GeofenceState.Exited:
                        if(geofence.Id.Equals("Route"))
                        Notification.OffRouteMessage();
                        Debug.WriteLine("Left geofence");
                        break;
                    //No state
                    case GeofenceState.None:
                        break;
                }
            }
        }

        private static async void handleGeoFenceEntered(Geofence geo)
        {
            foreach(POI poi in route._points)
            {
                if (poi._name != null)
                {
                    if (poi._name.Equals(geo.Id))
                    {
                        poi._visited = true;
                        Notification.POIVisit(poi);
                        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                        CoreDispatcherPriority.High, (() =>
                        {
                            rootFrame.Navigate(typeof(POIViewModel), poi);
                        }));
                    }
                }
            }
        }

        public static async Task GoToUserLocationAsync(bool force)
        {
            if (force || UserLocation != null)
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                    CoreDispatcherPriority.High, (() =>
                    {
                        Map.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(UserLocation.Location, 1000));
                    }));
            else
            {
                MessageDialog dialog = new MessageDialog("No GPS, Please wait", "No GPS");
                dialog.ShowAsync();
            }
        }

        public static Geopoint GetCurrentLocation()
        {
            //returns the last know location (updates every 2 seconds)
            return UserLocation.Location;
        }

        /*
         * Calculates the Distance in meters and the time in minutes the user has to walk 
         * until it arrives at the next destination.
         */

        public async static void GetDi(POI nextPoint)
        {
            List<Geopoint> waypoints = new List<Geopoint>();

            waypoints.Add(UserLocation.Location);

            List<POI> range = new List<POI>();
            for (int j = 0; j <= route._points.IndexOf(nextPoint); j++)
            {
                range.Add(route._points[j]);
            }
            foreach (POI p in range)
            {
                waypoints.Add(new Geopoint(p._coordinate));

            }
            MapRouteRestrictions restrictions = new MapRouteRestrictions();
            restrictions = MapRouteRestrictions.None;
            MapRouteOptimization optimize = MapRouteOptimization.Distance;
            MapRouteFinderResult result;
            if (waypoints.Count() > 1)
            {
                if (route._name.Equals("R_BLINDWALLS_NAME"))
                {

                    result = await MapRouteFinder.GetDrivingRouteFromWaypointsAsync(waypoints, optimize, restrictions);
                }
                else
                {
                    result = await MapRouteFinder.GetWalkingRouteFromWaypointsAsync(waypoints);
                }
                if (result.Status == MapRouteFinderStatus.Success)
                {
                    MapRouteView viewOfRoute = new MapRouteView(result.Route);
                    MapElement[] tempList = new MapElement[Map.MapElements.Count];
                    Map.MapElements.CopyTo(tempList, 0);
                    try
                    {
                        foreach (var element in Map.MapElements)
                        {
                            if (element is MapIcon)
                            {
                                MapIcon icon = (MapIcon)element;
                                char[] bar = new char[] { '-' };
                                string[] splitted = icon.Title.Split(bar);
                                if (splitted[0].Equals(MultiLang.GetContent(nextPoint._name)))
                                {
                                    await
                                        Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher
                                            .RunAsync(
                                                CoreDispatcherPriority.High, (() =>
                                                {

                                                    icon.Title = MultiLang.GetContent(nextPoint._name) + "-" +
                                                                 viewOfRoute.Route.LengthInMeters + "M " +
                                                                 viewOfRoute.Route.EstimatedDuration.Hours + ":" +
                                                                 viewOfRoute.Route.EstimatedDuration.Minutes + ":" +
                                                                 viewOfRoute.Route.EstimatedDuration.Seconds;

                                                    if (nextPoint._visited)
                                                    {
                                                        var myImageUri = new Uri("ms-appx:///Assets/Icons/GreenIcon.png");
                                                        icon.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                                                    }
                                                }));
                                }
                            }
                        }
                    }
                    catch (Exception) { }
                    
                }
            }
            else
            {
               
                    foreach (var element in Map.MapElements)
                    {
                        if (element is MapIcon)
                        {
                            MapIcon icon = (MapIcon) element;
                            char[] bar = new char[] {'-'};
                            string[] splitted = icon.Title.Split(bar);
                            if (splitted[0].Equals(MultiLang.GetContent(nextPoint._name)))
                            {
                                await
                                    Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher
                                        .RunAsync(
                                            CoreDispatcherPriority.High, (() =>
                                            {
                                                icon.Title = MultiLang.GetContent(nextPoint._name);

                                                if (nextPoint._visited)
                                                {
                                                    var myImageUri = new Uri("ms-appx:///Assets/Icons/GreenIcon.png");
                                                    icon.Image = RandomAccessStreamReference.CreateFromUri(myImageUri);
                                                }
                                            }));
                            }
                        }
                    }
                
            }
        }
    }
}
