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
            var hexaNumber  = new Any("0123456789abcdefABCDEF");
            var validHexaSequencer = new Sequence(hexaNumber,hexaNumber, hexaNumber, hexaNumber);
            var controlCharacter = new Optional(new Sequence(new Character('\\'), new Any("bfnrt/\"\\")));
            var hexaCharacter = new Optional(new Sequence(new Character('\\'), new Character('u')));
            pattern = new Sequence(new Character('\"'), new Sequence());
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
