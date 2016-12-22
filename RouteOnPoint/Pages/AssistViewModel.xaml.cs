using RouteOnPoint.LanguageUtil;
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace RouteOnPoint.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AssistViewModel : Page
    {
        public AssistViewModel()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                AppViewBackButtonVisibility.Visible;

            LoadContent();
        }

        void LoadContent()
        {
            Header.Text = MultiLang.GetContent("ASSISTVIEWMODEL_HEADER_TEXT");
            LocationButtonInfo.Text = MultiLang.GetContent("ASSISTVIEWMODEL_LOCATIONBUTTONINFO_TEXT");
            PauseButtonInfo.Text = MultiLang.GetContent("ASSISTVIEWMODEL_PAUSEBUTTONINFO_TEXT");
            HelpButtonInfo.Text = MultiLang.GetContent("ASSISTVIEWMODEL_HELPBUTTONINFO_TEXT");
            MyLocationImage.Source = new BitmapImage(new Uri(MultiLang.GetContent("ASSISTVIEWMODEL_MYLOACTIONINFO_IMAGE")));
            MyLocationInfo.Text = MultiLang.GetContent("ASSISTVIEWMODEL_MYLOCATIONINFO_TEXT");
            GreenPOI.Text = MultiLang.GetContent("ASSISTVIEWMODEL_GREENPOI_TEXT");
            BluePOI.Text = MultiLang.GetContent("ASSISTVIEWMODEL_BLUEPOI_TEXT");
            OrangeLine.Text = MultiLang.GetContent("ASSISTVIEWMODEL_ORANGELINE_TEXT");
            GrayLine.Text = MultiLang.GetContent("ASSISTVIEWMODEL_GRAYLINE_TEXT");

            Debug.WriteLine(MultiLang.GetContent("ASSISTVIEWMODEL_HEADER_TEXT"));
                    
        }
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
