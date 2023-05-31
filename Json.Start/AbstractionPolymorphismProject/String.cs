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
            var hexaNumber = new Any("0123456789abcdefABCDEF");
            var validHexaSequence = new Sequence(new Character('u'), hexaNumber, hexaNumber, hexaNumber, hexaNumber);
            var controlCharacter = new Sequence(new Character('\\'), new Choice(new Any("bfnrt/\"\\"), validHexaSequence));
            pattern = new Sequence(new Character('\"'), new OneOrMore(new Choice(letter, controlCharacter, new Character(' '))), new Character('\"'));
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
