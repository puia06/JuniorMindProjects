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
            return string.IsNullOrEmpty(text) || prefix == null || !text.StartsWith(prefix)
                  ? new Match(false, text)
                  : new Match(true, text[prefix.Length..]);
        }
    }
}
