﻿using RouteOnPoint.GPSHandler;
using RouteOnPoint.LanguageUtil;
using RouteOnPoint.Route;
using System;
using System.Collections.Generic;
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

        public RouteSelectionViewModel()
        {
            this.InitializeComponent();

            Kilometer.Text = MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME");
            Selecteer.Text = MultiLang.GetContent("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT");
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        }
        
        private void Click(object sender, TappedRoutedEventArgs e)
        {
            Grid g = (Grid)sender;
            Route.Route r;
            switch (g.Name) {
                case "BlindWalls":
                     r = new RouteHelper().createBlindWalls();
                    break;
                default:
                     r = new RouteHelper().createHistoriscRoute();
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Visible;
        }
    }
}
