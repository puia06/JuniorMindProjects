﻿using System;
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
            this.points = points + pointToAdd;
        }

        public string GetName()
        {
            return name;
        }
        public int GetPoints()
        {
            return points;
        }
        public override bool Equals(object obj)
        {
            if (obj is Team other)
            {
                return name == other.name && points == other.points;
            }

            return false;
        }
    }
}