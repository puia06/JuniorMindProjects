using System.Xml.Linq;

namespace AbstractionPolymorphismProject
{
    public class Text : IPattern
    {
        private readonly string prefix;
        public Text(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(StringView text)
        {
            if (text.IsEmpty() || prefix == null || !text.StartsWith(prefix))
            {
                return new Match(false, text);
            }
            for (int i = 0; i < prefix.Length; i++)
            {
                text.AdvancePosition();
            }

            return new Match(true, text);
        }
    }
}
