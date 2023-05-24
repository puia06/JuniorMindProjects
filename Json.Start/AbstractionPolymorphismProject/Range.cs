﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    internal class Range : IPattern
    {
        readonly private char start;
        readonly private char end;

        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            if (!string.IsNullOrEmpty(text) && text[0] >= start && text[0] <= end)
            {
                return new Match(true, text[1..]);
            }

            return new Match(false, text);
        }
    }
}
