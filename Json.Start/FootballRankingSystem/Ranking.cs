using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FootballRankingSystem
{
    class Ranking
    {
        private Team[] teams;

        public Ranking()
        {
            teams = new Team[0];
        }

        public int GetPosition(Team team)
        {
           for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i] == team)
                {
                    return (i + 1);
                }
            }

            return -1;
        }

        public void MatchResult(Team homeTeam, Team awayTeam,int scoreHomeTeam, int scoreAwayTeam )
        {
            if (scoreHomeTeam > scoreAwayTeam)
            {
                homeTeam.AddWin();
            }
            if (scoreHomeTeam == scoreAwayTeam)
            {
                homeTeam.AddDraw();
                awayTeam.AddDraw();
            }
            BubbleSort();
        }

        public Team? GetTeamByPosition(int position)
        {
            return position <= teams.Length ? teams[position - 1] : null;
        }

        public void AddNewTeam(Team team)
        {
            Array.Resize(ref teams, teams.Length + 1);
            teams[teams.Length - 1] = team;
            BubbleSort();
        }

        private void BubbleSort()
        {
            bool repeat;

            do
            {
                repeat = false;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].HasLessPointsThan(teams[i + 1]))
                    {
                        Swap( i, i + 1);
                        repeat = true;
                    }
                }
            }
            while (repeat);
        }

        private void Swap(int firstIndex, int secondIndex)
        {
            Team temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }
    }
}

