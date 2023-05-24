using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Many : IPattern
    {
        private readonly IPattern pattern;
        public Many(IPattern pattern)
        {
           this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            if (text == null)
            {
                return new Match(true, null);
            }

            int lenght = text.Length;
            for (int i = 0; i < lenght; i++)
            {
                IMatch match = pattern.Match(text);

                if (match.Success())
                {
                    text = match.RemainingText();
                }
                else
                {
                    break;
                }
            }

            return new Match(true, text);
        }
    }
}
