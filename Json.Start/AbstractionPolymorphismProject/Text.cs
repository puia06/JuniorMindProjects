using System.Xml.Linq;

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
            /*
            foreach(char c in prefix)
            {
                if (!text.StartsWith(c))
                {
                    return new Match(false, text);
                }

                text = text[1..];
            }
            */
            string textPrefix = "";
            if (text.Length >= prefix.Length)
            {
                 textPrefix = text.Substring(0, prefix.Length);
            }
            if (textPrefix.Equals(prefix))
            {
                return new Match(true, text[prefix.Length..]);
            }

            return new Match(false, text);
        }
    }
}
