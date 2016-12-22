using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.Devices.Notification;
using Windows.Storage;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Foundation;

namespace RouteOnPoint
{
    class Notification
    {
        public static bool IsPaused = false;

        //The notification that triggers when the user walks away from the route
        public static async void OffRouteMessage()
        {
            if (!IsPaused)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Assets");
                StorageFile sf = await Folder.GetFileAsync("jingle-bells-sms.mp3");
                MediaElement PlayMusic = new MediaElement();
                PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);



                ContentDialog dialog = new ContentDialog()
                {
                    FontSize = 26,
                    Title = "U wijkt van de route af",
                    PrimaryButtonText = "Ok",
                    SecondaryButtonText = "Pauzeer route"
                };
                dialog.SecondaryButtonClick += Pause;

                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

                PlayMusic.Play();

               

                await dialog.ShowAsync();
            }
        }

        public static void Pause(ContentDialog content, object sender)
        {
            IsPaused = true;
        }

        //The notification that triggers when nearing the next destination
        public static async void POIVisit(POI poi)
        {
            if (!IsPaused)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Assets");
                StorageFile sf = await Folder.GetFileAsync("jingle-bells-sms.mp3");
                MediaElement PlayMusic = null;
                var file = await sf.OpenAsync(FileAccessMode.Read);
                ContentDialog dialog = null;
                await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                        CoreDispatcherPriority.High, (() =>
                        {
                            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                            {
                                VibrationDevice Vibration = VibrationDevice.GetDefault();
                                Vibration.Vibrate(TimeSpan.FromSeconds(2));
                            }

                            PlayMusic = new MediaElement();
                            PlayMusic.SetSource(file, sf.ContentType);
                            dialog = new ContentDialog()
                            {
                                FontSize = 26,
                                Title = "U nadert " + MultiLang.GetContent(poi._name),
                                PrimaryButtonText = "Ok"
                            };
                            try
                            {
                                dialog.ShowAsync();
                            }
                            catch (System.Runtime.InteropServices.COMException e)
                            {
                                ShowToast(MultiLang.GetContent("NOTIFICATION_ENTERED"), MultiLang.GetContent("NOTIFICATION_ENTERED2") + MultiLang.GetContent(poi._name), poi);
                            }
                            
                        }));
            }
            
        }

        //The notification that triggers when an error occurs in the code
        public static async void ErrorMsg(string msg)
        {
            if (!IsPaused)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Assets");
                StorageFile sf = await Folder.GetFileAsync("jingle-bells-sms.mp3");
                MediaElement PlayMusic = new MediaElement();
                PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);


                ContentDialog dialog = new ContentDialog()
                {
                    FontSize = 26,
                    Title = "Error",
                    Content = msg,
                    PrimaryButtonText = "Ok",
                };
                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

                PlayMusic.Play();
                await dialog.ShowAsync();
            }
        }

        //The notification that triggers when something needs to be notified that is none of the above
        public static async void Notify(string title, string msg)
        {
            if (!IsPaused)
            {
                StorageFolder Folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
                Folder = await Folder.GetFolderAsync("Assets");
                StorageFile sf = await Folder.GetFileAsync("jingle-bells-sms.mp3");
                MediaElement PlayMusic = new MediaElement();
                PlayMusic.SetSource(await sf.OpenAsync(FileAccessMode.Read), sf.ContentType);


                ContentDialog dialog = new ContentDialog()
                {
                    FontSize = 26,
                    Title = title,
                    Content = msg,
                    PrimaryButtonText = "Ok",

                };
                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

                PlayMusic.Play();
                await dialog.ShowAsync();
            }
        }

        private static void ShowToast(string firstLine, string secondLine, POI p)
        {
            var toastXmlContent =
              ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);

            var txtNodes = toastXmlContent.GetElementsByTagName("text");
            txtNodes[0].AppendChild(toastXmlContent.CreateTextNode(firstLine));
            txtNodes[1].AppendChild(toastXmlContent.CreateTextNode(secondLine));
            var launchAttribute = toastXmlContent.CreateAttribute("launch");
            launchAttribute.Value = p._name;


            var toast = new ToastNotification(toastXmlContent);
            var toastNotifier = ToastNotificationManager.CreateToastNotifier();

            

            toastNotifier.Show(toast);

            
            
            Debug.WriteLine("Toast: {0} {1}", firstLine, secondLine);
        }
    }
}
