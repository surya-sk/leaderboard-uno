using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaderboardUno.Shared.Models
{
    public class Game
    {
        public Guid Id { get; set; }
        public string GameName { get; set; }
        public string GameType { get; set; }
        public double NumPlayers { get; set; }
        public int MaxScore { get; set; }
        public ObservableCollection<Player> Players { get; set; }

        override
        public string ToString()
        {
            return Id + " " + GameName + " " + GameType + " " + NumPlayers + " ";
        }
    }
}
