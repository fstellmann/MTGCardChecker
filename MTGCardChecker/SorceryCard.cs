﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTGCardChecker
{
    class SorceryCard: Card
    {
        public SorceryCard(string _cardName, string _cost, string _text, int _amountInDeck)
        {
            cardName = _cardName;
            cost = _cost;
            text = _text;
            amountInDeck = _amountInDeck;
        }
    }
}