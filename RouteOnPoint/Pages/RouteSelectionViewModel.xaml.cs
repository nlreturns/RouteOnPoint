﻿using RouteOnPoint.LanguageUtil;
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

            try
            {
                Kilometer.Text = MultiLang.GetContent("R_HISTORISCHEKILOMETER_NAME");
            }
            catch (Exception e) { Kilometer.Text = "ERROR"; }

            Selecteer.Text = MultiLang.GetContent("ROUTESELECTIONVIEWMODEL_SELECTROUTE_TEXT");
            SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        }
        
        private void Click(object sender, TappedRoutedEventArgs e)
        {
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
