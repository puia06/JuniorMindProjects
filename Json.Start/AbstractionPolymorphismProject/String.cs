using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class String : IPattern
    {
        private readonly IPattern pattern;

        public String()
        {
            var letter = new Range('a', 'z');
            var validLargeUnicode = new Range('\u0120', '\uFFFF');
            var emptySpace = new Character('\u0020');
            var hexDigit = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var validHexaSequence = new Sequence(new Character('u'), hexDigit, hexDigit, hexDigit, hexDigit);
            var controlCharacter = new Sequence(new Character('\\'), new Choice(new Any("bfnrt/\"\\"), validHexaSequence));
            pattern = new Sequence(new Character('\"'), new OneOrMore(new Choice(letter, controlCharacter, emptySpace, validLargeUnicode)), new Character('\"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
