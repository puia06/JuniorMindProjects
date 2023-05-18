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
        public void UpdatePoints_TeamOneWin_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Barcelona", 3);
            int scoreTeam1 = 2;
            int scoreTeam2 = 1;

            MatchResult match = new MatchResult(team1, team2, scoreTeam1, scoreTeam2);
            match.UpdatePoints();
            Team team1ExpectedPoints = new Team("Real Madrid", 7);
            Team team2ExpectedPoints = new Team("Barcelona", 3);

            Assert.Equal(team1ExpectedPoints, team1);
            Assert.Equal(team2ExpectedPoints, team2);
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
            Team team1ExpectedPoints = new Team("Real Madrid", 4);
            Team team2ExpectedPoints = new Team("Barcelona", 6);

            Assert.Equal(team1ExpectedPoints, team1);
            Assert.Equal(team2ExpectedPoints, team2);
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
            Team team1ExpectedPoints = new Team("Real Madrid", 5);
            Team team2ExpectedPoints = new Team("Barcelona", 4);

            Assert.Equal(team1ExpectedPoints, team1);
            Assert.Equal(team2ExpectedPoints, team2);
        }
    }
}
