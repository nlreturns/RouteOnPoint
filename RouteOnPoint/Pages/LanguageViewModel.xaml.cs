using RouteOnPoint.GPSHandler;
using RouteOnPoint.LanguageUtil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static RouteOnPoint.LanguageUtil.MultiLang;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LanguageViewModel : Page
    {
        Frame rootFrame = Window.Current.Content as Frame;
        string language;

        public LanguageViewModel()
        {
            this.InitializeComponent();
            TestMultiLang test = new TestMultiLang();

            var isAvailable = Windows.Foundation.Metadata.ApiInformation.IsTypePresent(typeof(StatusBar).FullName);
            if (isAvailable)
                hideBar();

        }

        async void hideBar()
        {
            StatusBar bar = StatusBar.GetForCurrentView();
            await bar.HideAsync();
        }

        private async void Language_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            language = button.Name.ToString();
            await setLanguage((LanguageEnum)Enum.Parse(typeof(LanguageEnum), language));
            rootFrame.Navigate(typeof(RouteSelectionViewModel));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Collapsed;
            this.Frame.BackStack.Clear();
        }
    }
}