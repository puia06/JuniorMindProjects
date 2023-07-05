using System;
using System.Collections.Generic;
using System.Linq;
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
            var hex = new Choice(new Range('0', '9'), new Range('a', 'f'), new Range('A', 'F'));
            var escape = new Sequence(new Character('\\'), new Choice(new Any("bfnrt/\"\\"), new Sequence(new Character('u'), hex, hex, hex, hex)));
            var character = new Choice(new Range('\u0020', '\u0021'), new Range('\u0023', '\u005B'), new Range('\u005D', '\uFFFF'), escape);
            var characters = new Many(character);
            pattern = new Sequence(new Character('\"'), characters, new Character('\"'));
        }

        public IMatch Match(StringView text)
        {
            return pattern.Match(text);
        }
    }
}
