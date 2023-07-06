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

        private StringView(string text, int position)
        {
            this.text = text;
            this.position = position;
        }
        public string GetText()
        {
            return this.text;
        }

        public bool IsEmpty()
        {
            return string.IsNullOrEmpty(this.text) || text.Length == this.position;
        }

        public bool StartsWith(string prefix)
        {
            return this.text.StartsWith(prefix);
        }

        public StringView SaveLastPosition()
        {
            return new StringView(text, position);
        } 

        public int GetPosition()
        {
            return this.position;
        }

        public char CharPeek()
        {
            return text[position];
        }

        public StringView Advance(int step = 1)
        {
            return new StringView(this.text, this.position += step);
        }
    }
}