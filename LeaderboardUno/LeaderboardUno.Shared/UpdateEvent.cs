using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using LeaderboardUno.Shared.Models;

namespace LeaderboardUno.Shared
{
    class UpdateEvent
    {
        IGamesUpdateable MainPage;
        public UpdateEvent(IGamesUpdateable mainPage)
        {
            this.MainPage = mainPage;
        }

        public void OnEventChanged(ObservableCollection<Game> games)
        {
            this.MainPage.UpdateGames(games);
        }
    }
}
