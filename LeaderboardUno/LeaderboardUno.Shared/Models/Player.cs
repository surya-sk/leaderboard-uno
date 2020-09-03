using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaderboardUno.Shared.Models
{
    public class Player
    {
        public string PlayerName { get; set; }
        public ObservableCollection<GameRound> GameRounds { get; set; }
        public int TotalScore { get; set; }
    }

    public class PlayerList
    {
        public static ObservableCollection<Player> GetPlayers()
        {
            var PlayerList = new ObservableCollection<Player>();
            return PlayerList;
        }
    }
}
