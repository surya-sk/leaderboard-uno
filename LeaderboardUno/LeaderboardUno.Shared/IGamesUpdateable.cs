using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LeaderboardUno.Shared.Models;

namespace LeaderboardUno.Shared
{
    interface IGamesUpdateable
    {
        void UpdateGames(ObservableCollection<Game> games);
    }
}
