using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class List : IPattern
    {
        private readonly IPattern pattern;

        public List(IPattern element, IPattern separator)
        {
            var seq = new Sequence(separator, element);
            this.pattern = new Optional(new Sequence(element, new Many(seq)));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
