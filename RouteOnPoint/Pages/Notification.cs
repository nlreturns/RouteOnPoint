using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Phone.Devices.Notification;
using Windows.Storage;
using Windows.System.Profile;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RouteOnPoint
{
    class Notification
    {
        public static bool IsPaused = false;
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
                    //MaxWidth = page.ActualWidth,
                    PrimaryButtonText = "Ok",
                    SecondaryButtonText = "Pauzeer route"
                };
                dialog.SecondaryButtonClick += Pauzeer;

                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

                PlayMusic.Play();

               

                await dialog.ShowAsync();
            }
        }

        public static void Pauzeer(ContentDialog content, object sender)
        {
            IsPaused = true;
        }

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
                            dialog.ShowAsync();
                        }));
            }
            
        }

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
                    //MaxWidth = page.ActualWidth,
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
                    //MaxWidth = page.ActualWidth,
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
    }
}
