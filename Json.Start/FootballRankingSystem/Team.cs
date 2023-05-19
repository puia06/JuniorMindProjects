using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballRankingSystem
{
    public class Team
    {
        readonly private string name;
        private int points;

        public Team(string name, int points)
        {
            this.name = name;
            this.points = points;
        }

        public void AddPoints(int pointToAdd)
        {
            this.points += pointToAdd;
        }

        public bool HasLessPointsThan(Team team)
        {
            return points < team.points;
        }

        public override bool Equals(object? obj)
        {
            return obj is Team team &&
                   name == team.name &&
                   points == team.points;
        }
    }
}