using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
            var comma = new Character(',');
            var colon = new Character(':');
            var x = new Character('{');
            var y = new Character('}');
            var a = new Character('[');
            var b = new Character(']');
            var ws = new Many(new Any(" \t\r\n"));

            var value = new Choice(
        stringg,
        new Number(),
        new Text("false"),
        new Text("true"),
        new Text("null")
        );

            var element = new Sequence(ws, value, ws);
            var member = new Sequence(ws, stringg, ws, colon, element);
            var members = new List(member, comma);
            var elements = new List(element, comma);
            var objectt = new Sequence(x, ws, members, y);
            var array = new Sequence(a, ws, elements, b);
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
