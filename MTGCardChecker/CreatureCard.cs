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

        public CreatureCard(string _cardName, string _cost, string _text, int _power, int _toughness, int _amountInDeck)
        {
            cardName = _cardName;
            cost = _cost;
            text = _text;
            power = _power;
            toughness = _toughness;
            amountInDeck = _amountInDeck;
        }
    }
}
