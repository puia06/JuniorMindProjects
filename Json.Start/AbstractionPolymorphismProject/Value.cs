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
           // var wss = new Choice(new Character('\u0020'), new Character('\u000A'), new Character('\u000D'), new Character('\u0009'));
            var ws = new Choice();
            ws.Add(new Sequence(new Character('\u0020'), ws));
            ws.Add(new Sequence(new Character('\u000A'), ws));
            ws.Add(new Sequence(new Character('\u000D'), ws));
            ws.Add(new Sequence(new Character('\u0009'), ws));
            ws.Add(new Sequence(new Text("")));

            var element = new Sequence(ws, value, ws);
            var member = new Sequence(ws, stringg, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var elements = new List(element, new Character(','));
            var objectt = new Sequence(new Character('{'), ws, new Optional(members), new Character('}'));
            var array = new Sequence(new Character('['), ws, new Optional(elements), new Character(']'));
            value.Add(objectt);
            value.Add(array);
            pattern = new Choice(
      objectt,
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
