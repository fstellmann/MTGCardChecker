using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCardChecker
{
    public abstract class Card
    {
        public string cardName { get; set; }
        public string cost { get; set; }
        public string text { get; set; }
        public int amountInDeck { get; set; } = 0;
    }
}
