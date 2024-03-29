﻿using RouteOnPoint.LanguageUtil;
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
using RouteOnPoint.GPSHandler;

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
                            Title = "U bent buiten Breda",
                            PrimaryButtonText = "Ok",
                            SecondaryButtonText = "Pauzeer route"
                        };
                        dialog.SecondaryButtonClick += Pause;
                        dialog.ShowAsync();
                    }));


                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

            }
        }

        public static void Pause(ContentDialog content, object sender)
        {
            IsPaused = true;
            GPSReader.IsPaused = true;
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
                        try
                        {
                            if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                            {
                                VibrationDevice Vibration = VibrationDevice.GetDefault();
                                Vibration.Vibrate(TimeSpan.FromSeconds(2));
                            }

                            PlayMusic = new MediaElement();
                            PlayMusic.SetSource(file, sf.ContentType);
                            PlayMusic.Play();
                            dialog = new ContentDialog()
                            {
                                FontSize = 26,
                                Title = "INFO: U nadert " + MultiLang.GetContent(poi._name),
                                PrimaryButtonText = "Ok"
                            };
                            try
                            {
                                dialog.ShowAsync();
                            }
                            catch (Exception) { }
                        }
                        catch (Exception e)
                        {
                            Debug.WriteLine(e.StackTrace);
                            throw;
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
                    Title = "WARNING",
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
                    Title = "INFO: "+title,
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
        public static async void Critical(string msg)
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
                    Title = "CRITICAL",
                    Content = msg,
                    PrimaryButtonText = "Ok",

                };
                if (AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
                {
                    VibrationDevice Vibration = VibrationDevice.GetDefault();
                    Vibration.Vibrate(TimeSpan.FromSeconds(2));
                }

                PlayMusic.Play();
                try
                {
                    await dialog.ShowAsync();
                }
                catch { }
            }
        }

        
    }
}
