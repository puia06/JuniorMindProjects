using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Number : IPattern
    {
        private readonly IPattern pattern;

        public Number()
        {
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
