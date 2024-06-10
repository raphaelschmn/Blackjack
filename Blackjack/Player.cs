using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        public Card[] Hand;
        public int CardsInHand;
        public int Points;
        public string Name;

        public Player()
        {
            Hand = new Card[9];
            Points = 0;
            CardsInHand = 0;
        }

    }
}
