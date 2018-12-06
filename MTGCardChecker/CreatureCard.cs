using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCardChecker
{
    public class CreatureCard : Card
    {
        public int power { get; set; }
        public int toughness { get; set; }

        public CreatureCard( int _power, int _toughness, int _amountInDeck)
        {
            power = _power;
            toughness = _toughness;
            amountInDeck = _amountInDeck;
        }
    }
}
