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
        public Team[] GetTeams()
        {
            return teams;
        }

        public Team[] GetSortedTeams()
        {
            return BubbleSort(teams);
        }

        public int GetPosition(string name)
        {
           Team[] sortedTeams = GetSortedTeams();
           for (int i = 0; i < sortedTeams.Length; i++)
            {
                if (sortedTeams[i].GetName() == name)
                {
                    return i + 1;
                }
            }

            return -1;
        }

        public string GetTeamByPosition(int position)
        {
            Team[] sortedTeams = GetSortedTeams();
            return position <= sortedTeams.Length ? sortedTeams[position - 1].GetName() : "";
        }


        public void AddNewTeam(Team team)
        {
            int length = teams.Length;
            Team[] newArray = new Team[length + 1];
            Array.Copy(teams, newArray, length);
            newArray[length] = team;
            this.teams = newArray;
        }

        private static Team[] BubbleSort(Team[] teams)
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

            return teams;
        }

        private static void Swap(Team[] teams, int firstIndex, int secondIndex)
        {
            (int minIndex, int maxIndex) = GetMinMaxIndex(firstIndex, secondIndex);
            Team temp = teams[minIndex];
            teams[minIndex] = teams[maxIndex];
            teams[maxIndex] = temp;
        }

        private static (int minIndex, int maxIndex) GetMinMaxIndex(int firstIndex, int secondIndex)
        {
            if (firstIndex > secondIndex)
            {
                return (secondIndex, firstIndex);
            }

            return (firstIndex, secondIndex);
        } 
    }
}

