using LeaderboardUno.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public sealed partial class Leaderboard : Page
    {
        private ObservableCollection<Player> players;
        private ObservableCollection<Game> games;
        private Game game;
        Guid guid;
        public static string resultId;
        public ObservableCollection<Player> Players { get => players; set => players = value; }

        public Leaderboard()
        {
            games = Profile.GetInstance().GetGamesList();
            this.InitializeComponent();
            DataContext = Players;
        }



        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Homepage));
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            game.Players = Players;
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Id == guid)
                {
                    games[i] = game;
                }
            }
            Profile.GetInstance().SaveSettings(games);
            Profile.GetInstance().WriteProfile();
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog deleteDialog = new ContentDialog()
            {
                Title = "Delete game permanently?",
                Content = "If you delete this game, you cannot recover it. Are you sure?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };
            ContentDialogResult contentDialogResult = await deleteDialog.ShowAsync();
            if (contentDialogResult == ContentDialogResult.Primary)
            {
                DeleteGame();
                this.Frame.Navigate(typeof(Homepage), "deleted");
            }
        }

        private void DeleteGame()
        {
            games.Remove(game);
            Profile.GetInstance().SaveSettings(games);
            Profile.GetInstance().WriteProfile();
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage));
        }

        private void AddRound_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < players.Count; i++)
            {
                GameRound gameRound = new GameRound() { RoundName = "Round " + (players[i].GameRounds.Count + 1), Score = 0, IsReadOnly = false };
                players[i].GameRounds.Add(gameRound);
                for (int j = 0; j < players[i].GameRounds.Count - 1; j++)
                {
                    players[i].GameRounds[j].IsReadOnly = true;
                }
            }
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Page Loaded" + resultId);
            guid = new Guid(resultId);
            for (int i = 0; i < games.Count; i++)
            {
                if (games[i].Id == guid)
                {
                    game = games[i];
                    Players = game.Players;
                    GameName.Text = game.GameName;
                }
            }
        }

        private void ScoreTextBox_BeforeTextChanging(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
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
