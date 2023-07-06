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
        public string GetText()
        {
            return this.text;
        }

        public bool IsNullOrEmpty()
        {
            return string.IsNullOrEmpty(this.text);
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

        public bool IsUnavailablePosition()
        {
            return position >= text.Length;
        }
        public char CharPeek()
        {
            return text[position];
        }

        public StringView NextPosition()
        {
            return new StringView(text, position++);
        }

        public bool IsEndPosition()
        {
            return text.Length == this.position;
        }
    }
}