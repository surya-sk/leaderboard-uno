using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace LeaderboardUno.Shared
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
        }
        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            ApplicationData.Current.LocalSettings.Values["themeSetting"] = ((ToggleSwitch)sender).IsOn ? 0 : 1;
        }

        private void ToggleSwitch_Loaded(object sender, RoutedEventArgs e)
        {
            ((ToggleSwitch)sender).IsOn = App.Current.RequestedTheme == ApplicationTheme.Light;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Homepage));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage));
        }
    }
}
