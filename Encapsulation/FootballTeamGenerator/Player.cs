using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Player
    {
        private string name;
        private Stat stats;

        public Player(string name, Stat stat)
        {
            Name = name;
            this.stats = stat;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.EMPTY_NAME_EXCEPTION_MESSAGE);
                }

                name = value;
            }
        }

        public int PlayerRating()
        {
            double tempCalc = (stats.Endurance + stats.Sprint + stats.Dribble + stats.Passing + stats.Shooting) / 5.0;
            return (int)Math.Round(tempCalc);
        }
    }
}
