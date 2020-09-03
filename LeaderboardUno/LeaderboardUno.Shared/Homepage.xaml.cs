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
        int MaxScore;
        private ObservableCollection<Game> games;
        private ObservableCollection<GameRound> GameRounds;
        private ObservableCollection<Player> Players;
        public Homepage()
        {
            this.InitializeComponent();
            GameRounds = GameRoundsList.GetGameRounds();
            Players = PlayerList.GetPlayers();
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
            string temp2 = MaxScoreInput.Text;
            MaxScore = Convert.ToInt16(temp2);
            CreatePlayerList();
            InputPlayers();
            //this.Frame.Navigate(typeof(Homepage));
            //this.Frame.Navigate(typeof(Leaderboard));
            //GameDetPanel.Visibility = Visibility.Collapsed;
        }

        private void InputPlayers()
        {
            GameDetPanel.Visibility = Visibility.Collapsed;
            GameNameTextBox.Text += GameName;
            InputPanel.Visibility = Visibility.Visible;
        }

        private void ActualCreateGameButton_Click(object sender, RoutedEventArgs e)
        {
            Game game = new Game() { Id = Guid.NewGuid(), GameName = GameName, GameType = Type, NumPlayers = Num, MaxScore = MaxScore, Players = Players };
            Profile.GetInstance().AddGame(game);
            InputPanel.Visibility = Visibility.Collapsed;
            InputGame.Visibility = Visibility.Visible;
        }
        private void CreateRoundOne()
        {
            GameRounds.Add(new GameRound { RoundName = "Round " + (GameRounds.Count + 1), score = 0 });
        }

        private void CreatePlayerList()
        {
            CreateRoundOne();
            for (int i = 0; i < Num; i++)
            {
                Players.Add(new Player { PlayerName = "", GameRounds = GameRounds });
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

        public void UpdateGames(ObservableCollection<Game> games)
        {
            this.games = games;
        }

        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Settings));
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(HelpPage));
        }
    }
}
