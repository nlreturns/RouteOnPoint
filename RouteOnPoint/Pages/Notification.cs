﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace RouteOnPoint
{
    class Notification
    {
        public static async void OffRouteMessage(Page page)
        {
            ContentDialog dialog = new ContentDialog()
            {
                FontSize = 26,
                Title = "U wijkt van de route af",
                MaxWidth = page.ActualWidth,
                PrimaryButtonText = "Ok",
                SecondaryButtonText = "Pauzeer route"
            };
            dialog.SecondaryButtonClick += Pauzeer;
            await dialog.ShowAsync();
        }

        public static void Pauzeer(ContentDialog content, object sender)
        {

        }
    }
}