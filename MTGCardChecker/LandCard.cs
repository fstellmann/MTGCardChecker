using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCardChecker
{
    class LandCard :Card
    {
        public LandCard(string _name, string _text, int _amountInDeck)
        {
            cardName = _name;
            cost = "-";
            text = _text;
            amountInDeck = _amountInDeck;
        }
    }
}
