using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Blackjack
{
    internal class Player
    {
        public Card[] Hand;
        public int CardsInHand;
        public int Points;
        public string Name;
        public double Money;
        public double Bet;

        public Player()
        {
            Hand = new Card[9];
            Points = 0;
            Money = 5000;
        }

        public void CountPoints(Card[] cards)     //Counts Points in Hand
        {
            int pointcounter = 0;
            for (int i = 0; i < cards.Length; i++)
            {
                pointcounter += cards[i].Points;
            }

            this.Points = pointcounter;

        }

        public void CountCards(Card[] cards)
        {
            this.CardsInHand = cards.Count();
        }

        public void UpdateValues ()
        {
            CountCards(this.Hand);
            CountPoints(this.Hand);
        }

        

    }
}
