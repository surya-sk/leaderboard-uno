using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LeaderboardUno.Shared.Models
{
    public class Game
    {
        public Guid id { get; set; }
        public string GameName { get; set; }
        public string GameType { get; set; }
        public double NumPlayers { get; set; }
        public ObservableCollection<PlayerStat> PlayerStatList { get; set; }

        override
        public string ToString()
        {
            return GameName + " " + GameType + " " + NumPlayers + " " + PlayerStatList;
        }
    }
}
