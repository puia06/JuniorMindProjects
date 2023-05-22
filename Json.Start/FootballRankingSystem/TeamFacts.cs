using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballRankingSystem
{
    public class TeamFacts
    {
        [Fact]
        public void HasLessPointsThan_SecondTeamHasMore_ShouldReturnTrue()
        {
            Team team1 = new Team("Real Madrid", 5);
            Team team2 = new Team("Barcelona", 6);
            Assert.True(team1.HasLessPointsThan(team2));
        }

        [Fact]
        public void HasLessPointsThan_FirstTeamHasMore_ShouldReturnFalse()
        {
            Team team1 = new Team("Real Madrid", 7);
            Team team2 = new Team("Barcelona", 6);
            Assert.False(team1.HasLessPointsThan(team2));
        }

        [Fact]
        public void HasLessPointsThan_HaveEqualsPoints_ShouldReturnFalse()
        {
            Team team1 = new Team("Real Madrid", 8);
            Team team2 = new Team("Barcelona", 8);
            Assert.False(team1.HasLessPointsThan(team2));
        }
    }
}
