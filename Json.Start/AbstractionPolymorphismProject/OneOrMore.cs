﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class OneOrMore : IPattern
    {
        private readonly IPattern pattern;
        public OneOrMore(IPattern pattern)
        {
            // aici folosește-te de clasele implementate deja
            // pentru a construi un pattern care să îl folosești în Match
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    } 
}
