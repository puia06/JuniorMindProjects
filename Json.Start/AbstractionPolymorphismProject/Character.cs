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

        public IMatch Match(StringView text)
        {
            if (!text.IsNullOrEmpty() && !text.IsEndPosition() && text.CharPeek() == pattern)
            {
                text.NextPosition();
                return new Match(true, text);
            }

            return new Match(false, text);
        }
    }
}
