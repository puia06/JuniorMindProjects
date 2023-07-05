using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionPolymorphismProject
{
    public class Match : IMatch
    {
        private bool success;
        private StringView remainingText;

        public Match(bool success, StringView remainingText)
        {
            this.success = success;
            this.remainingText = remainingText;
        }

        public bool Success()
        {
            return success;
        }

        public StringView RemainingText()
        {
            return remainingText;
        }
    }
}