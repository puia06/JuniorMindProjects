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
        public string GetText()
        {
            return this.text;
        }

        public int GetPosition()
        {
            return this.position;
        }

        public void SetPosition(int position)
        {
            this.position = position;
        }

        public char CharPeek()
        {
            if (position < text.Length)
            {
                return text[position];
            }

            return text[position - 1];
        }

        public int NextPosition()
        {
            return this.position++;
        }

        public bool EndPosition()
        {
            return text.Length == this.position;
        }
    }
}