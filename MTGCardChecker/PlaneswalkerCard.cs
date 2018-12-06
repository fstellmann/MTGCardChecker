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

        public PlaneswalkerCard(int _loyalty, int _amountInDeck)
        {
            loyalty = _loyalty;
            amountInDeck = _amountInDeck;
        }
    }
}
