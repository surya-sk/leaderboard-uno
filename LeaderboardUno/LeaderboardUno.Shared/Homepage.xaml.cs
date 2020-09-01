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
    public sealed partial class Homepage : Page, IGamesUpdateable
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

        private void CreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            GameName = NameInput.Text;
            string temp = NumInput.Text;
            Num = Convert.ToDouble(temp);
            CreatePlayerStats();
            InputPlayers();
            //this.Frame.Navigate(typeof(Homepage));
            //this.Frame.Navigate(typeof(Leaderboard));
        }

        private void CreatePlayerStats()
        {
            for (int i = 0; i < Num; i++)
            {
                PlayerStats.Add(new PlayerStat { PlayerName = "", PlayerScore = 0 });
            }
        }

        private async void InputPlayers()
        {
            ContentDialogResult result = await NamesDialog.ShowAsync();
        }

        private void NamesDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Game game = new Game() { id = Guid.NewGuid(), GameName = GameName, GameType = Type, NumPlayers = Num, PlayerStatList = PlayerStats };
            Profile.GetInstance().AddGame(game);
            InputGame.Visibility = Visibility.Visible;
            GameDetPanel.Visibility = Visibility.Collapsed;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
           // this.Frame.Navigate(typeof(Settings));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(HelpPage));
        }
        private void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            Type = rb.Name;
        }

        public void UpdateGames(ObservableCollection<Game> games)
        {
            this.games = games;
            Console.WriteLine("Homepage" + games.Count);
        }

        private void NumInput_Validate(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            //args.Cancel = args.NewText.Any(char => !char.IsDigit(c));
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
