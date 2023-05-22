using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    internal class Range
    {
        private char start;
        private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public bool Match(string text)
        {
        }
    }
}
