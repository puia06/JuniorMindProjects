using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Value
    {
        private readonly IPattern pattern;

        public Value()
        {
            var stringg = new String();
            var wss = new Choice(new Text(""), new Character('\u0020'), new Character('\u000A'), new Character('\u000D'), new Character('\u0009'));
            var ws = new Choice(
             new Text(""),
             new Sequence(new Character('\u0020'), wss),
             new Sequence(new Character('\u000A'), wss),
             new Sequence(new Character('\u000D'), wss),
             new Sequence(new Character('\u0009'), wss)
         );
            var element = new Sequence(ws, pattern, ws);
            var member = new Sequence(ws, stringg, ws, new Character(':'), element);
            var members = new Choice(member, new Sequence(member, new Character(','), new List(member, new Character(','))));
            var elements = new Choice(new Sequence(element, new Character(','), new List(element, new Character(','))), element);

            var objectt = new Sequence(new Character('{'), new Choice(ws, members), new Character('}'));
            var array = new Sequence(new Character('['), new Choice(ws, elements), new Character(']'));

            pattern = new Choice(
      objectt,
      array,
      new String(),
      new Number(),
      new Text("true"),
      new Text("false"),
      new Text("null")
  );
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
