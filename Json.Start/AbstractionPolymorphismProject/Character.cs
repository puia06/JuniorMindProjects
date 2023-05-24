using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Character : IPattern
    {
        readonly char pattern;

        public Character(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && text[0] == pattern)
            {
                return new Match(true, text[1..]);
            }

            return new Match(false, text); 
        }
    }
}
