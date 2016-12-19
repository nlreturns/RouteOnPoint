using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RouteOnPoint
{
    class Notification
    {
        public static async void OffRouteMessage(Page page)
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
                MaxWidth = page.ActualWidth,
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Pauzeer route"
            };
            dialog.SecondaryButtonClick += Pauzeer;
            PlayMusic.Play();
            await dialog.ShowAsync();
        }

        public static void Pauzeer(ContentDialog content, object sender)
        {

        }

        public static async void POIVisit(POI poi)
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
                        PlayMusic = new MediaElement();
                        PlayMusic.SetSource(file, sf.ContentType);
                        dialog = new ContentDialog()
                        {
                            FontSize = 26,
                            Title = "U nadert " + poi._name,
                            PrimaryButtonText = "Ok"
                        };
                        dialog.ShowAsync();
                    }));
            
        }
    }
}
