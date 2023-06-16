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
            var ws = new Many(new Any(" \t\r\n"));

            var element = new Sequence(ws, value, ws);
            var member = new Sequence(ws, stringg, ws, new Character(':'), element);
            var members = new List(member, new Character(','));
            var elements = new List(element, new Character(','));
            var objectt = new Sequence(new Character('{'), ws, members, new Character('}'));
            var array = new Sequence(new Character('['), ws, elements, new Character(']'));
            value.Add(objectt);
            value.Add(array);

            pattern = element;
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
