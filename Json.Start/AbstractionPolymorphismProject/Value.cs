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
            var value = new Choice(
        new String(),
        new Number(),
        new Text("false"),
        new Text("true"),
        new Text("null")
        );

            var stringg = new String();
            var wss = new Choice(new Character('\u0020'), new Character('\u000A'), new Character('\u000D'), new Character('\u0009'), new Text(""));
            var ws = new Choice(
             new Sequence(new Character('\u0020'), wss),
             new Sequence(new Character('\u000A'), wss),
             new Sequence(new Character('\u000D'), wss),
             new Sequence(new Character('\u0009'), wss),
             new Text("")
         );
            var element = new Sequence(ws, value, ws);
            var member = new Sequence(ws, stringg, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var elements = new List(element, new Character(','));
            var choice = new Choice();
            choice.Add(ws);
            choice.Add(elements);
            var objectt = new Sequence(new Character('{'), new Choice(ws, members), new Character('}'));
            var array = new Sequence(new Character('['), new Choice(ws, elements), new Character(']'));
            value.Add(objectt);
            value.Add(array);
            pattern = new Choice(
      array,
      new String(),
      new Number(),
      new Text("false"),
      new Text("true"),
      new Text("null")
  ) ;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
