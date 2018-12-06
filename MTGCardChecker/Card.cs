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
        public void build(string _name, string _cost, string _text)
        {
            cardName = _name;
            cost = _cost;
            text = _text;
        }
    }
}
