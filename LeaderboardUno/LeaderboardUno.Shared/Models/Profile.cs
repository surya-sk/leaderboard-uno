using Windows.Foundation;
using Windows.Storage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace LeaderboardUno.Shared.Models
{
    class Profile
    {
        private static Profile instance = new Profile();
        private ObservableCollection<Game> GamesList = null;
        ApplicationDataContainer roamingSettings = ApplicationData.Current.RoamingSettings;
        StorageFolder roamingFolder = ApplicationData.Current.RoamingFolder;
        List<UpdateEvent> events;
        string fileName = "games.txt";

        private Profile()
        {
            events = new List<UpdateEvent>();
        }

        public static Profile GetInstance()
        {
            return instance;
        }

        void InitHandlers()
        {
            ApplicationData.Current.DataChanged += new TypedEventHandler<ApplicationData, object>(DataChangeHandler);
        }

        void DataChangeHandler(ApplicationData appData, object o)
        {
            SaveSettings(GamesList);
        }

        public async void WriteProfile()
        {
            string json = JsonConvert.SerializeObject(GamesList);
            StorageFile storageFile = await roamingFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(storageFile, json);
        }

        public void SaveSettings(ObservableCollection<Game> gamesList)
        {
            GamesList = gamesList;
        }

        public async void ReadProfile()
        {
            try
            {
                StorageFile storageFile = await roamingFolder.GetFileAsync(fileName);
                string json = await FileIO.ReadTextAsync(storageFile);
                GamesList = JsonConvert.DeserializeObject<ObservableCollection<Game>>(json);
                FireEvents();
            }
            catch
            {
                GamesList = new ObservableCollection<Game>();
            }

        }

        public ObservableCollection<Game> GetGamesList()
        {
            return GamesList;
        }

        public void AddEvent(UpdateEvent updateEvent)
        {
            events.Add(updateEvent);
        }

        private void FireEvents()
        {
            for (int i = 0; i < events.Count; i++)
            {
                events[i].OnEventChanged(GamesList);
            }
            Debug.WriteLine("events fired " + events.Count);
        }

        public void ClearEvents()
        {
            events.Clear();
        }

        public void AddGame(Game game)
        {
            GamesList.Add(game);
            WriteProfile();
            FireEvents();
        }
    }
}
