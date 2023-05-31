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
            var digits = new OneOrMore(new Range('0', '9'));
            var integerPart = new Sequence(new Optional(new Character ('-')), new Choice(new Character('0'), digits));
            var decimalPart = new Optional(new Sequence(new Character('.'), digits));
            var exponent = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), digits));

            pattern = new Sequence(integerPart, decimalPart, exponent);

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
