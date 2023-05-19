using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballRankingSystem
{
    public class RankingFacts
    {
        [Fact]
        public void GetSortedTeams_TwoTeamsInWrongOrder_ShouldSwapTeams()
        {
        var barcelona = new Team("FC Barcelona", 0);
        var real = new Team("Real Madrid", 2);
        var ranking = new Ranking();

        ranking.AddNewTeam(barcelona);
        ranking.AddNewTeam(real);

        Assert.Equal(real, ranking.GetTeamByPosition(1));
        Assert.Equal(barcelona, ranking.GetTeamByPosition(2));
    }

        [Fact]
        public void GetSortedTeams_TwoTeamsInCorrectOrder_ShouldNotSwap()
        {
        var barcelona = new Team("FC Barcelona", 3);
        var real = new Team("Real Madrid", 2);
        var ranking = new Ranking();

        ranking.AddNewTeam(barcelona);
        ranking.AddNewTeam(real);

        Assert.Equal(barcelona, ranking.GetTeamByPosition(1));
        Assert.Equal(real, ranking.GetTeamByPosition(2));
    }

        [Fact]
        public void GetPosition_ShouldReturnCorrectPosition()
        {
        var atletico = new Team("Atletico Madrid", 1);
        var barcelona = new Team("FC Barcelona", 3);
        var real = new Team("Real Madrid", 2);
        var ranking = new Ranking();

        ranking.AddNewTeam(barcelona);
        ranking.AddNewTeam(real);
        ranking.AddNewTeam(atletico);

        Assert.Equal(atletico, ranking.GetTeamByPosition(3));
    }

        [Fact]
        public void GetPosition_MatchResult_WinLost_ShouldUpdateRanking()
        {
        var atletico = new Team("Atletico Madrid", 1);
        var barcelona = new Team("FC Barcelona", 3);
        var real = new Team("Real Madrid", 2);
        var ranking = new Ranking();

        ranking.AddNewTeam(barcelona);
        ranking.AddNewTeam(real);
        ranking.AddNewTeam(atletico);
        ranking.MatchResult(atletico, barcelona, 2, 1);

        Assert.Equal(atletico, ranking.GetTeamByPosition(1));

        }

        [Fact]
        public void GetPosition_MatchResult_Draw_ShouldUpdateRanking()
        {
            var atletico = new Team("Atletico Madrid", 2);
            var barcelona = new Team("FC Barcelona", 3);
            var real = new Team("Real Madrid", 3);
            var ranking = new Ranking();

            ranking.AddNewTeam(barcelona);
            ranking.AddNewTeam(real);
            ranking.AddNewTeam(atletico);
            ranking.MatchResult(atletico,real, 1, 1);

            Assert.Equal(real, ranking.GetTeamByPosition(1));
            Assert.Equal(atletico, ranking.GetTeamByPosition(3));

        }

        [Fact]
        public void GetSortedTeams_MatchResult_MultipleMatches_ShouldUpdateRanking()
        {
            var atletico = new Team("Atletico Madrid", 2);
            var barcelona = new Team("FC Barcelona", 3);
            var real = new Team("Real Madrid", 3);
            var ranking = new Ranking();

            ranking.AddNewTeam(barcelona);
            ranking.AddNewTeam(real);
            ranking.AddNewTeam(atletico);
            ranking.MatchResult(atletico, real, 1, 1);
            ranking.MatchResult(barcelona, real, 2, 1);

            Assert.Equal(barcelona, ranking.GetTeamByPosition(1));
            Assert.Equal(real, ranking.GetTeamByPosition(2));
            Assert.Equal(atletico, ranking.GetTeamByPosition(3));
        }
    }
}
