using System;
using System.Collections.Generic;
using System.Text;

namespace FootballTeamGenerator
{
    public static class ExceptionMessages
    {
        public const string STAT_EXCEPTION_MESSAGE = "{0} should be between 0 and 100.";
        public const string EMPTY_NAME_EXCEPTION_MESSAGE = "A name should not be empty.";
        public const string WRONG_NAME_EXCEPTION_MESSAGE = "Team {0} does not exist.";
        public const string WRONG_PLAYER_NAME_EXCEPTION_MESSAGE = "Player {0} is not in {1} team.";
    }
}
