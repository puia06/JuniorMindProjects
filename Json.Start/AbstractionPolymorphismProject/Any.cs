﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Any : IPattern
    {
        private readonly string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new Match(false, text);
            }

            foreach (char c in accepted)
            {
                if (text.StartsWith(c))
                {
                    return new Match(true, text[1..]);
                }
            }

            return new Match(false, text);
        }
    }
}
