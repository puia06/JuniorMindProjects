using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballRankingSystem
{
    public class MatchResult
    {
        readonly Team teamOne;
        readonly Team teamTwo;
        readonly int scoreTeamOne;
        readonly int scoreTeamTwo;

        public MatchResult(Team teamOne, Team teamTwo, int scoreTeamOne, int scoreTeamTwo)
        {
            this.teamOne = teamOne;
            this.teamTwo = teamTwo;
            this.scoreTeamOne = scoreTeamOne;
            this.scoreTeamTwo = scoreTeamTwo;
        }

        public void UpdatePoints()
        {
            if (scoreTeamOne > scoreTeamTwo)
            {
                teamOne.AddPoints(3);
            }
            if (scoreTeamOne < scoreTeamTwo)
            {
                teamTwo.AddPoints(3);
            }
            if(scoreTeamOne == scoreTeamTwo)
            {
                teamOne.AddPoints(1);
                teamTwo.AddPoints(1);
            }
        }
    }
}
