﻿using System;
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

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
         
      
            var POIGot = (POI)e.Parameter;
            POI = POIGot;
            
            FillContent();
            base.OnNavigatedTo(e);
        }

        private void FillContent()
        {
            if (POI != null)
            {
                if (POI._INFO == null || MultiLang.GetContent(POI._INFO) == null)
                    POIInfo.Text = MultiLang.GetContent("NOINFOERROR");
                else { POIInfo.Text = MultiLang.GetContent(POI._INFO); }
                if (POI._name == null || MultiLang.GetContent(POI._name) == null)
                {
                    POIName.Text = MultiLang.GetContent("NOTITLEERROR");
                }
                else { POIName.Text = MultiLang.GetContent(POI._name); }

                if (POI._path != null)
                    Image.Source = new BitmapImage(new Uri(POI._path));
            }
            else
            {
                POIInfo.Text = MultiLang.GetContent("NOINFOERROR");
                POIName.Text = MultiLang.GetContent("NOTITLEERROR");
            }
            

        }

        private void Close(object sender, RoutedEventArgs e)
        {
            rootFrame.GoBack();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
