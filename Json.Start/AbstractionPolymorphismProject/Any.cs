using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Any : IPattern
    {
        private readonly string accepted;
        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(StringView text)
        {
            if (string.IsNullOrEmpty(text.GetText()) || !accepted.Contains(text.CharPeek()))
            {
                return new Match(false, text);
            }
            text.NextPosition();

            return new Match(true, text);
        }
    }
}
