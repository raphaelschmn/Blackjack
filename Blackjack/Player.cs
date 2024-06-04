using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Player
    {
        public Card[] hand;
        public int cardsInHand;
        public int points;
        public string name;

        public Player()
        {
            hand = new Card[5];
            points = 0;
            cardsInHand = 0;
        }

    }
}
