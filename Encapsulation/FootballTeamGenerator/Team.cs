using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> players;
        private string name;
        private int rating;

        public Team()
        {
            players = new List<Player>();
        }
        public Team(string name) : this()
        {
            Name = name;
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
        public int Rating
        {
            get 
            {
                if (players.Count == 0)
                {
                    return 0;
                }

                double count = players.Count;
                return (int)(Math.Round(rating / count));
            }
        }

        public void Add(string playerName, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Player player = new Player(playerName, new Stat(endurance, sprint, dribble, passing, shooting));

            if ((players.FirstOrDefault(p => p.Name == playerName)) == null)
            {
                players.Add(player);
                rating += player.PlayerRating();
            }
        }
        public bool Remove(string playerName)
        {
            if (players.FirstOrDefault(n => n.Name == playerName) == null)
            {
                return false;
            }

            Player player = players.First(n => n.Name == playerName);

            players.Remove(player);
            rating -= player.PlayerRating();

            return true;
        }
        public int TeamRating()
        {
            if (players.Count == 0)
            {
                return 0;
            }

            double teamRating = 0;

            foreach (var player in players)
            {
                teamRating += player.PlayerRating();
            }

            teamRating /= players.Count;
            return (int)Math.Round(teamRating);
        }
    }
}
