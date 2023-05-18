using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballRankingSystem
{
    public class TeanFacts
    {
        [Fact]
        public void TeamConstructor_ShouldCreateATeamObj()
        {
            Team team1 = new Team("Real Madrid", 4);

            Assert.Equal("Real Madrid", team1.GetName());
            Assert.Equal(4, team1.GetPoints());
        }

        [Fact]
        public void AddPoints_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            team1.AddPoints(3);
            Assert.Equal(7, team1.GetPoints());
        }

        [Fact]
        public void AddPoints_AddZeroPoints_ShouldUpdatePoints()
        {
            Team team1 = new Team("Real Madrid", 4);
            team1.AddPoints(0);
            Assert.Equal(4, team1.GetPoints());
        }

        [Fact]
        public void Equals_CompareTwoEqualsTeams_ShouldReturnTrue()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Real Madrid", 4);
            Assert.True(team1.Equals(team2));
        }


        [Fact]
        public void Equals_CompareTwoDifferentTeams_ShouldReturnFalse()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Atletico Madrid", 2);
            Assert.False(team1.Equals(team2));
        }

        [Fact]
        public void Equals_CompareTeamsWithSameNameDifferentPoints_ShouldReturnFalse()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Real Madrid", 2);
            Assert.False(team1.Equals(team2));
        }


        [Fact]
        public void Equals_CompareTeamsWithDifferentNameSamePoints_ShouldReturnFalse()
        {
            Team team1 = new Team("Real Madrid", 4);
            Team team2 = new Team("Atletico Madrid", 4);
            Assert.False(team1.Equals(team2));
        }
    }
}
