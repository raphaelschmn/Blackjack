using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

        }

        public void CountPoints(Card[] cards)     //Counts Points in Hand
        {
            int pointcounter = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                pointcounter += cards[i].Points;
            }

            this.Points = pointcounter;
            

            CardsInHand = 0;

        }

    }
}
