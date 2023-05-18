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

        public Ranking(Team[] teams)
        {
            this.teams = teams;
        }

        public int GetPosition(Team team)
        {
           BubbleSort();
           for (int i = 0; i < teams.Length; i++)
            {
                if (teams[i].Equals(team))
                {
                    return (i + 1);
                }
            }

            return -1;
        }

        public Team? GetTeamByPosition(int position)
        {
            BubbleSort();
            return position <= teams.Length ? teams[position - 1] : null;
        }


        public void AddNewTeam(Team team)
        {
            int length = teams.Length;
            Team[] newArray = new Team[length + 1];
            Array.Copy(teams, newArray, length);
            newArray[length] = team;
            this.teams = newArray;
            BubbleSort();
        }

        public void BubbleSort()
        {
            bool repeat;

            do
            {
                repeat = false;
                for (int i = 0; i < teams.Length - 1; i++)
                {
                    if (teams[i].GetPoints() < teams[i + 1].GetPoints())
                    {
                        Swap(teams, i, i + 1);
                        repeat = true;
                    }
                }
            }
            while (repeat);
        }


        private static void Swap(Team[] teams, int firstIndex, int secondIndex)
        {
            Team temp = teams[firstIndex];
            teams[firstIndex] = teams[secondIndex];
            teams[secondIndex] = temp;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Ranking otherRanking = (Ranking)obj;

            if (teams.Length != otherRanking.teams.Length)
                return false;

            for (int i = 0; i < teams.Length; i++)
            {
                if (!teams[i].Equals(otherRanking.teams[i]))
                    return false;
            }

            return true;
        }
    }
}

