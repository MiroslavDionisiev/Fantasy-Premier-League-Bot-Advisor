﻿namespace ProjectA.States
{
    public class StateConstants
    {
        public class Suggestions
        {
            public const string PlayersSuggestions = "/PlayersSuggestion";
            public const string PointsPerGameCriteria = "Points Per Game";
            public const string CurrentFormCriteria = "Current Form";
            //ITC stans for Influence, Threat, Creativity
            public const string ITCRankCriteria = "ITC Rank";
            public const string PointsPerPriceCriteria = "Points Per Price";
            public const string OverallStatsCriteria = "Overall Stats";
            public const string BackToPreviousMenu = "Back";
        }

        public class Statistics
        {
            public const string PlayersStatistics = "/PlayersStatistics";
            public const string TeamStatistics = "/TeamsStatistics";
            public const string PlayersData = "Player's data";
            public const string TopScorersLeague = "Top scorers of the championship";
            public const string TopScorersTeam = "Top scorers in a team";
            public const string PlayersInTeamFromPosition = "Player in a team of position";
            public const string PlayerInDreamtem = "Times player has been in dream team";
            public const string PlayersFromTeamInDreamteam = "Team's players in dream teams";
        }  
        

        public class StateMessages
        {
            public const string ChooseOptionMainState = "Please choose on of the options:";
            public const string ChooseCategory = "Pick a category you want to get data for.";
            public const string InsertPlayersSuggestionsPreferences = "Please insert your preferences:";
            public const string PlayersSuggestionPreferencesFormat = "(position/min Price/max Price)";

            public const string WrongInputFormat = "Wrong preferences format";

            public const string GetPlayersSuggestionMessage = "To get 5 suggested players, please choose a criteria:";
        }
    }
}
