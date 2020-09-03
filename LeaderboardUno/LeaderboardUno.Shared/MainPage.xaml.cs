using LeaderboardUno.Shared;
using LeaderboardUno.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Controls;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace LeaderboardUno
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, IGamesUpdateable
    {
        private ObservableCollection<Game> games;

        public MainPage()
        {
            games = new ObservableCollection<Game>();
            UpdateEvent UpdateEvent = new UpdateEvent(this);
            Profile.GetInstance().ClearEvents();
            Profile.GetInstance().AddEvent(UpdateEvent);
            Profile.GetInstance().ReadProfile();
            //games = profile.GetGamesList();
            this.InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RefreshPage();
        }

        public void RefreshPage()
        {
            Frame.Navigate(typeof(MainPage));
        }

        //private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        //{
        //    TextBlock ItemContent = args.InvokedItem as TextBlock;
        //    if(ItemContent==null)
        //    {
        //        RefreshButton.Content += "Hello";
        //    }
        //    else
        //    {
        //        ContentFrame.Navigate(typeof(Leaderboard), new Guid(ItemContent.Tag.ToString()));
        //    }
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //games = profile.GetGamesList();
            //Debug.WriteLine("On load" + games.Count);
            ContentFrame.Navigate(typeof(Homepage));
            // UpdateEvent.OnEventChanged(games);
        }

        public void UpdateGames(ObservableCollection<Game> games)
        {
            this.games = games;
            //Debug.WriteLine("Mainpage" + games.Count);
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ContentFrame.Navigate(typeof(Leaderboard), new Guid(button.Tag.ToString()));
        }
    }
}
