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
            var digits = new Range('0', '9');
            var nonZeroDigits = new Range('1', '9');
            var integerPart = new Choice(new Character('0'), new Sequence(nonZeroDigits, new Many(digits)));
            var decimalPart = new Optional(new Sequence(new Character('.'), new OneOrMore(digits)));
            var exponent = new Optional(new Sequence(new Any("eE"), new Optional(new Any("+-")), new OneOrMore(digits)));

            pattern = new Sequence(new Optional(new Character('-')), integerPart, decimalPart, exponent);

        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
