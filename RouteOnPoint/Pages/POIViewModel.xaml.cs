using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RouteOnPoint.GPSHandler;
using Windows.UI.Core;
using RouteOnPoint.Route;
using Windows.UI.Xaml.Media.Imaging;
using RouteOnPoint.LanguageUtil;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class POIViewModel : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        POI POI;

        public POIViewModel()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs args)
        {
            //var POIGot = (POI)args.Parameter;
            //POI = POIGot;

            FillContent();
        }

        private void FillContent()
        {
            POIInfo.Text = POI._INFO;
            POIName.Text = POI._name;
            Image.Source = new BitmapImage(new Uri(POI._path));
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            rootFrame.GoBack();
        }
    }
}
