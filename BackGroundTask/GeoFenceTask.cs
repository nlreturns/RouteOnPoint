using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Geolocation.Geofencing;
using Windows.UI.Notifications;

namespace BackGroundTask
{
    public sealed class GeoFenceTask : IBackgroundTask
    {
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            string  s = taskInstance.InstanceId.ToString();
            var monitor = GeofenceMonitor.Current;
            if (monitor.Geofences.Any())
            {
                var reports = monitor.ReadReports();
                foreach (var report in reports)
                {


                    switch (report.NewState)
                    {
                        case GeofenceState.Entered:
                            {

                                ShowToast(s + " reached", "Check the app for more information");
                                break;
                            }


                    }
                }
            }


            //deferral.Complete();
        }

        private static void ShowToast(string firstLine, string secondLine)
        {
            var toastXmlContent =
              ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var txtNodes = toastXmlContent.GetElementsByTagName("text");
            txtNodes[0].AppendChild(toastXmlContent.CreateTextNode(firstLine));
            txtNodes[1].AppendChild(toastXmlContent.CreateTextNode(secondLine));

            var toast = new ToastNotification(toastXmlContent);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();
            toastNotifier.Show(toast);

            Debug.WriteLine("Toast: {0} {1}", firstLine, secondLine);
        }
    }
}
