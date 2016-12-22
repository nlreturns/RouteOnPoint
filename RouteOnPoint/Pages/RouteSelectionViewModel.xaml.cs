using RouteOnPoint.GPSHandler;
using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RouteSelectionViewModel : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        Route.Route route;

        private Route.Route loadedRoute = null;

        public RouteSelectionViewModel()
        {
            this.InitializeComponent();

            Kilometer.Text = MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME");
            Selecteer.Text = MultiLang.GetContent("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT");
            Hervat.Text = MultiLang.GetContent("ROUTESELECTIONVIEWMODEL_RESUMEROUTE_TEXT");
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;

        }

        private async void Click(object sender, TappedRoutedEventArgs e)
        {

            Grid g = (Grid)sender;
            Route.Route r = null;
            switch (g.Name)
            {

                case "Blind":
                    r = new RouteHelper().createBlindWalls();
                    break;
                case "Kilo":
                    r = new RouteHelper().createHistoriscRoute();
                    break;
                case "Resume":
                    r = loadedRoute;

                    break;


            }
            GPSReader.route = r;
            rootFrame.Navigate(typeof(RouteViewModel));
        }

        public void App_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                rootFrame.GoBack();
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            RouteHandler load = new RouteHandler();
            try
            {
                loadedRoute = await load.GetRouteFromFile("RouteData.json");
            }
            catch (Exception)
            {
                loadedRoute = null;
            }

            if (loadedRoute == null || loadedRoute._points.Count() < 1)
            {
                ResumeButton.Visibility = Visibility.Collapsed;
                Resume.Visibility = Visibility.Collapsed;


            }
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Visible;
#if DEBUG

            await MultiLang.setLanguage(MultiLang.LanguageEnum.Dutch);
            Debug.WriteLine(MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME"));
            await MultiLang.setLanguage(MultiLang.LanguageEnum.English);
            Debug.WriteLine(MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME"));
#endif
        }
    }
}