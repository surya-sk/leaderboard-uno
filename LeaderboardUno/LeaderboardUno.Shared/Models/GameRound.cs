using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaderboardUno.Shared.Models
{
    public class GameRound
    {
        public string RoundName { get; set; }
        public int score { get; set; }
    }

    public class GameRoundsList
    {
        public static ObservableCollection<GameRound> GetGameRounds()
        {
            var GameRounds = new ObservableCollection<GameRound>();
            return GameRounds;
        }
    }
}
