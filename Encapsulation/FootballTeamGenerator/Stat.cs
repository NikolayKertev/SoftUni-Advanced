using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public class Stat
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public Stat(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public int Endurance
        {
            get => endurance;
            private set 
            {
                StatValidation(value, nameof(this.Endurance));

                endurance = value;
            }
        }
        public int Sprint
        {
            get => sprint;
            private set
            {
                StatValidation(value, nameof(this.Sprint));

                sprint = value;
            }
        }
        public int Dribble
        {
            get => dribble;
            private set
            {
                StatValidation(value, nameof(this.Dribble));

                dribble = value;
            }
        }
        public int Passing
        {
            get => passing;
            private set
            {
                StatValidation(value, nameof(this.Passing));

                passing = value;
            }
        }
        public int Shooting
        {
            get => shooting;
            private set
            {
                StatValidation(value, nameof(this.Shooting));

                shooting = value;
            }
        }

        private void StatValidation(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.STAT_EXCEPTION_MESSAGE, stat));
            }
        }
    }
}
