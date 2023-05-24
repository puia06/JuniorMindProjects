using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Sequence : IPattern
    {
        private readonly IPattern[] patterns;
        public Sequence(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            var match = new Match(true, text);
            foreach (var pattern in patterns)
            {
                match = (Match)pattern.Match(match.RemainingText());
                if (!(match.Success()))
                {
                    return new Match(false, text);
                } 
            }

            return match;
        }
    }
}
