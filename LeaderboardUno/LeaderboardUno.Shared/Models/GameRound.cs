using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace LeaderboardUno.Shared.Models
{
    public class GameRound : INotifyPropertyChanged
    {
        private string roundName;
        private int score;
        private bool isReadOnly;
        public int Score
        {
            get => score;
            set
            {
                score = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Score)));
            }
        }
        public bool IsReadOnly
        {
            get => isReadOnly;
            set
            {
                isReadOnly = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsReadOnly)));
            }
        }

        public string RoundName
        {
            get => roundName;
            set
            {
                roundName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RoundName)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
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
