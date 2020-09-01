using LeaderboardUno.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Markup;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class Homepage : Page
    {
        string GameName, Type;
        double Num;
        private ObservableCollection<PlayerStat> PlayerStats;
        private ObservableCollection<Game> games;
        public Homepage()
        {
            this.InitializeComponent();
            PlayerStats = PlayerStatList.GetPlayerStats();
        }

        private void InputGame_Click(object sender, RoutedEventArgs e)
        {
            InputGame.Visibility = Visibility.Collapsed;
            GameDetPanel.Visibility = Visibility.Visible;
        }

        private void GameType_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Type = rb.Name;
        }

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameName = NameInput.Text;
            string temp = NumInput.Text;
            Num = Convert.ToDouble(temp);
            CreatePlayerStats();
            InputPlayers();
            //this.Frame.Navigate(typeof(Homepage));
            //this.Frame.Navigate(typeof(Leaderboard));
            //GameDetPanel.Visibility = Visibility.Collapsed;
        }

        private async void InputPlayers()
        {
            GameDetPanel.Visibility = Visibility.Collapsed;
            InputPanel.Visibility = Visibility.Visible;
        }


        private void CreatePlayerStats()
        {
            for (int i = 0; i < Num; i++)
            {
                PlayerStats.Add(new PlayerStat { PlayerName = "", PlayerScore = 0 });
            }
        }


        private void NumInput_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            foreach (char c in args.NewText)
            {
                if (!char.IsDigit(c))
                {
                    args.Cancel = true;
                }
            }
        }

    }
}
