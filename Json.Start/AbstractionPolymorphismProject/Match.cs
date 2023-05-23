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
        private string remainingText;

        public Match(bool success, string remainingText)
        {
            this.success = success;
            this.remainingText = remainingText;
        }

        public bool Success()
        { 
            return success;
        }

        public string RemainingText()
        {
            return success ? remainingText[1..] : remainingText;
        }
    }
}
