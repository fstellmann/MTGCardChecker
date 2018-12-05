using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCardChecker
{
    class PlaneswalkerCard : Card
    {
        public int loyalty { get; set; }

        public PlaneswalkerCard(string _name, string _cost, string _text, int _loyalty, int _amountInDeck)
        {
            cardName = _name;
            cost = _cost;
            text = _text;
            loyalty = _loyalty;
            amountInDeck = _amountInDeck;
        }
    }
}
