﻿using System.Xml.Linq;

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
            if (string.IsNullOrEmpty(text.GetText()) || prefix == null || !text.GetText().StartsWith(prefix))
            {
                return new Match(false, text);
            }
            for (int i = 0; i < prefix.Length; i++)
            {
                text.NextPosition();
            }

            return new Match(true, text);
        }
    }
}
