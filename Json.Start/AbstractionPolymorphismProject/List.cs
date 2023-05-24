using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class List
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            // aici folosește-te de clasele implementate deja
            // pentru a construi un pattern pe care să îl folosești în Match
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
