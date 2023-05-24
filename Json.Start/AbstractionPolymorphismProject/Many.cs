using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Many
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

            string result = "";
            int lengh = text.Length;

            for (int i = 0; i < lengh; i++)
            {
                IMatch match = pattern.Match(text);

                if (match.Success() && result == "")
                {
                    text = match.RemainingText();
                }
                else
                {
                    result += text[0];
                    text = text[1..];
                }
            }

            return new Match(true, result);
        }
    }
}
