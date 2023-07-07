using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class StringView
    {
        private readonly string text;
        private int position;

        public StringView(string text)
        {
            this.text = text;
            this.position = 0;
        }

        public StringView(string text, int position)
        {
            this.text = text;
            this.position = position;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.text) || text.Length == this.position;
        }

        public bool StartsWith(string prefix)
        {
            if (text.Length - position < prefix.Length)
            {
                return false;
            }

            for (int i = 0; i < prefix.Length; i++)
            {
                if (text[position + i] != prefix[i])
                {
                    return false;
                }
            }

            return true;
        }

        public char CharPeek()
        {
            return text[position];
        }

        public StringView Advance(int step = 1)
        {
            int newPosition = position + step;
            return new StringView(text, newPosition);
        }

        public bool CompareTo(StringView x)
        {
            return this.text == x.text && this.position == x.position;
        }
    }
}