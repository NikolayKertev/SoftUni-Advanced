using System;
using System.Collections.Generic;
using System.Linq;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(";");
                string command = tokens[0];
                string teamName = tokens[1];

                try
                {
                    switch (command)
                    {
                        case "Team":
                            Team team = new Team(teamName);
                            teams.Add(team);                            
                            break;
                        case "Add":
                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int sprint = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            var tempTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            TeamValidation(tempTeam, teamName);

                            tempTeam.Add(playerName, endurance, sprint, dribble, passing, shooting);
                            break;
                        case "Remove":
                            playerName = tokens[2];

                            tempTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            //TeamValidation(tempTeam, teamName);

                            if (!tempTeam.Remove(playerName))
                            {
                                throw new ArgumentException(string.Format(ExceptionMessages.WRONG_PLAYER_NAME_EXCEPTION_MESSAGE, playerName, teamName));
                            }
                            break;
                        case "Rating":
                            tempTeam = teams.FirstOrDefault(t => t.Name == teamName);

                            TeamValidation(tempTeam, teamName);

                            Console.WriteLine($"{teamName} - {tempTeam.Rating}");
                            break;
                    }

                }
                catch (ArgumentException ae)
                {

                    Console.WriteLine(ae.Message);
                }
            }
        }

        private static void TeamValidation(Team tempTeam, string teamName)
        {
            if (tempTeam == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.WRONG_NAME_EXCEPTION_MESSAGE, teamName));
            }
        }
    }
}
