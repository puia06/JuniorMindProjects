using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Text
    {
        private readonly string prefix;
        public Text(string prefix)
        {
          this.prefix = prefix;
         }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || prefix == null)
            {
                return new Match(false, text);
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (!(prefix[i] == text[i]))
                {
                    return new Match(false, text);
                }
            }

            return new Match(true, text[prefix.Length..]);
        }
    }
}
