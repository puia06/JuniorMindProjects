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
        public void GetSortedTeams_ShouldSortDescending()
        {
            Team[] teams =
            {
                new Team("Barcelona", 3),
                new Team("Real Madrid", 4),
                new Team("Atletico Madrid", 1)
            };

            Team[] expectedTeams =
            {
                 new Team("Real Madrid", 4),
                 new Team("Barcelona", 3),
                 new Team("Atletico Madrid", 1)
            };

            Ranking ranking = new Ranking(teams);
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_WithEqualValues_ShouldSortDescending()
        {
            Team[] teams =
            {
                new Team("Barcelona", 1),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 3)
            };

            Team[] expectedTeams =
            {
                 new Team("Real Madrid", 3),
                 new Team("Atletico Madrid", 3),
                 new Team("Barcelona", 1)
            };

            Ranking ranking = new Ranking(teams);
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_WithNegativeValue_ShouldSortDescending()
        {
            Team[] teams =
            {
                new Team("Barcelona", -1),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 3)
            };

            Team[] expectedTeams =
            {
                 new Team("Real Madrid", 3),
                 new Team("Atletico Madrid", 3),
                 new Team("Barcelona", -1)
            };

            Ranking ranking = new Ranking(teams);
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_TwoTeamsInWrongOrder_ShouldSwapTeams()
        {
            Team[] teams =
           {
        new Team("Barcelona", 3),
        new Team("Real Madrid", 4),
          };

            Team[] expectedTeams =
           {
                 new Team("Real Madrid", 4),
                 new Team("Barcelona", 3)
           };


            Ranking ranking = new Ranking(teams);
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_TwoTeamsInCorrectOrder_ShouldNotSwap()
        {
            Team[] teams =
           {
        new Team("Barcelona", 5),
        new Team("Real Madrid", 4),
          };

            Team[] expectedTeams =
           {
         new Team("Barcelona", 5),
         new Team("Real Madrid", 4),
          };


            Ranking ranking = new Ranking(teams);
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_AddNewTeam_ShouldAddTeamInCorrectOrder()
        {
            Team newTeam = new Team("U Cluj", 2);
            Team[] teams =
    {
                new Team("Barcelona", 5),
                new Team("Real Madrid", 4),
                new Team("Atletico Madrid", 1)
            };
            Team[] expectedTeams =
{
                new Team("Barcelona", 5),
                new Team("Real Madrid", 4),
                new Team("U Cluj", 2),
                new Team("Atletico Madrid", 1),
            };
            Ranking ranking = new Ranking(teams);
            ranking.AddNewTeam(newTeam);
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);

        }

        [Fact]
        public void GetPosition_ShouldReturnCorrectPosition()
        {
            Team[] teams =
            {
                new Team("Barcelona", 4),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 2)
            };
            Team Barcelona = new Team("Barcelona", 4);
            Ranking ranking = new Ranking(teams);

            Assert.Equal(1, ranking.GetPosition(Barcelona));
        }

        [Fact]
        public void GetPosition_AddTeamsInWrongOrder_ShouldReturnCorrectPosition()
        {
            Team[] teams =
            {
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 2),
                new Team("Barcelona", 4)
            };
            Team Barcelona = new Team("Barcelona", 4);
            Ranking ranking = new Ranking(teams);

            Assert.Equal(1, ranking.GetPosition(Barcelona));
        }

        [Fact]
        public void GetTeamByPosition_ShouldReturnCorrectTeam()
        {
            Team[] teams =
            {
                new Team("Barcelona", 4),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 2)
            };

            Ranking ranking = new Ranking(teams);
            Team RealMadrid = new Team("Real Madrid", 3);
            Assert.Equal(RealMadrid, ranking.GetTeamByPosition(2));
        }

        [Fact]
        public void GetTeamByPosition_AddTeamsInWrongOrder_ShouldReturnCorrectTeam()
        {
            Team[] teams =
            {
                new Team("Atletico Madrid", 2),
                new Team("Barcelona", 4),
                new Team("Real Madrid", 3)
            };

            Ranking ranking = new Ranking(teams);
            Team RealMadrid = new Team("Real Madrid", 3);

            Assert.Equal(RealMadrid, ranking.GetTeamByPosition(2));
        }

        [Fact]
        public void GetSortedTeams_MatchResult_WinLost_ShouldUpdateRanking()
        {
            Team[] teams =
            {
                new Team("Barcelona", 5),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 1),
                new Team("U Cluj", 1)
            };

            Team[] expectedTeams =
            {
                new Team("Barcelona", 5),
                new Team("U Cluj", 4),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 1),
            };
            int scoreteamOne = 3;
            int scoreteamTwo = 2;
            Ranking ranking = new Ranking(teams);
            MatchResult firstMatch = new MatchResult(teams[3], teams[2], scoreteamOne, scoreteamTwo);
            firstMatch.UpdatePoints();
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_MatchResult_Draw_ShouldUpdateRanking()
        {
            Team[] teams =
            {
                new Team("Barcelona", 5),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 1),
                new Team("U Cluj", 1)
            };

            Team[] expectedTeams =
            {
                new Team("Barcelona", 5),
                new Team("Real Madrid", 4),
                new Team("U Cluj", 2),
                new Team("Atletico Madrid", 1),
            };

            Ranking ranking = new Ranking(teams);
            int scoreteamOne = 0;
            int scoreteamTwo = 0;
            MatchResult firstMatch = new MatchResult(teams[3], teams[1], scoreteamOne, scoreteamTwo);
            firstMatch.UpdatePoints();
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }

        [Fact]
        public void GetSortedTeams_MatchResult_MultipleMatches_ShouldUpdateRanking()
        {
            Team[] teams =
            {
                new Team("Barcelona", 5),
                new Team("Real Madrid", 3),
                new Team("Atletico Madrid", 1),
                new Team("U Cluj", 1)
            };

            Team[] expectedTeams =
            {
                new Team("Barcelona", 6),
                new Team("Real Madrid", 6),
                new Team("U Cluj", 2),
                new Team("Atletico Madrid", 1),
            };

            Ranking ranking = new Ranking(teams);
            int scoreUCluj = 2;
            int scoreBarcelona = 2;
            int scoreAtletico = 1;
            int scoreRealMadrid = 3;
            MatchResult firstMatch = new MatchResult(teams[3], teams[0], scoreUCluj, scoreBarcelona);
            MatchResult secondMatch = new MatchResult(teams[1], teams[2], scoreRealMadrid, scoreAtletico);
            firstMatch.UpdatePoints();
            secondMatch.UpdatePoints();
            ranking.BubbleSort();
            Ranking expectedRanking = new Ranking(expectedTeams);

            Assert.Equal(expectedRanking, ranking);
        }
    }
}
