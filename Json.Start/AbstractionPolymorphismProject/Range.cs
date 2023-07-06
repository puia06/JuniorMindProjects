using System;
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

        public IMatch Match(StringView text)
        {
            if (!text.IsEmpty() && text.CharPeek() >= start && text.CharPeek() <= end)
            {
                text.AdvancePosition();
                return new Match(true, text);
            }

            return new Match(false, text);
        }
    }
}