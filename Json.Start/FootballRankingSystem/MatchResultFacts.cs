using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballRankingSystem
{
    public class MatchResultFacts
    {
        [Fact]
        public void MatchResultConstructor_ShouldCreateAMatchResulObj()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Barcelona", 3);
            int scoreTeam1 = 2;
            int scoreTeam2 = 1;

            MatchResult match = new MatchResult(team1, team2, scoreTeam1, scoreTeam2);

            Assert.Equal(team1, match.GetTeamOne());
            Assert.Equal(team2, match.GetTeamTwo());
            Assert.Equal(2, match.GetScoreTeamOne());
            Assert.Equal(1, match.GetScoreTeamTwo());
        }

        [Fact]
        public void UpdatePoints_TeamOneWin_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Barcelona", 3);
            int scoreTeam1 = 2;
            int scoreTeam2 = 1;

            MatchResult match = new MatchResult(team1, team2, scoreTeam1, scoreTeam2);
            match.UpdatePoints();

            Assert.Equal(7, match.GetTeamOne().GetPoints());
            Assert.Equal(3, match.GetTeamTwo().GetPoints());
        }

        [Fact]
        public void UpdatePoints_TeamTwoWin_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Barcelona", 3);
            int scoreTeam1 = 1;
            int scoreTeam2 = 2;

            MatchResult match = new MatchResult(team1, team2, scoreTeam1, scoreTeam2);
            match.UpdatePoints();

            Assert.Equal(4, match.GetTeamOne().GetPoints());
            Assert.Equal(6, match.GetTeamTwo().GetPoints());
        }

        [Fact]
        public void UpdatePoints_Equal_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Barcelona", 3);
            int scoreTeam1 = 2;
            int scoreTeam2 = 2;

            MatchResult match = new MatchResult(team1, team2, scoreTeam1, scoreTeam2);
            match.UpdatePoints();

            Assert.Equal(5, match.GetTeamOne().GetPoints());
            Assert.Equal(4, match.GetTeamTwo().GetPoints());
        }
    }
}
