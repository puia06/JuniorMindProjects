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

            if (text.StartsWith(prefix))
            {
                return new Match(true, text[prefix.Length..]);
            }

            return new Match(false, text);
        }
    }
}
