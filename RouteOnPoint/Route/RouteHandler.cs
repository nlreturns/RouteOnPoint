using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Devices.Geolocation;
using Windows.Devices.Geolocation.Geofencing;
using Windows.Storage;
using Newtonsoft.Json;
using RouteOnPoint.GPSHandler;

/**
 * Author: Jan-Willem Dooms <janwillem.dooms@gmail.com>
 * RouteHandler has help methods for the Route class, including
 * Saving, retreiving and checking if you are still on Route
 * or near a Point of Interest.
 * 
 * Version 0.1 - Added attributes and methods. (From class diagram)
 * Version 0.2 - Adusted SaveRouteWithState, added functionality to
 *               SaveRouteWithState and GetRouteFromFile.
 */

namespace RouteOnPoint.Route
{
    class RouteHandler
    {
        private bool _paused;
        private Route _route;

        /*
         * Save a route with all info included.
         * 
         * Version 0.2 - removed List<POI> POI - this is saved inside Route
         */

        public async void SaveRouteWithState(Route route, string path)
        {
            // create json string
            string jsonString = JsonConvert.SerializeObject(route);
            // select the current folder and file, create if necessary.
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            StorageFile file = await folder.CreateFileAsync(path, CreationCollisionOption.ReplaceExisting);

            // write file
            var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(jsonString);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();

        }

        /*
         * Get a Route from excisting file.
         * Returns Route with excisting data.
         */

        public async Task<Route> GetRouteFromFile(String path)
        {
            // select folder and file
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile file = await folder.GetFileAsync(path);

                // open stream and get size
                var stream = await file.OpenAsync(FileAccessMode.ReadWrite);
                ulong size = stream.Size;

                // read stream
                using (var inputStream = stream.GetInputStreamAt(0))
                {
                    using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                    {
                        uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                        string text = dataReader.ReadString(numBytesLoaded);
                        // convert to Route object and return
                        Route obj = JsonConvert.DeserializeObject<Route>(text);
                        return obj;
                    }
                }
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }

        
    }
}