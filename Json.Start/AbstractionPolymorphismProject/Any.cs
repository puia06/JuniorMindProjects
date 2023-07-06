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
            if (text.IsEmpty() || !accepted.Contains(text.CharPeek()))
            {
                return new Match(false, text);
            }
            text.AdvancePosition();

            return new Match(true, text);
        }
    }
}
