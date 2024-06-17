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

        public void CountPoints()
        {
            int pointcounter = 0;
            for (int i = 0; i < CardsInHand; i++)
            {
                pointcounter += this.Hand[i].Points;
            }
            this.Points = pointcounter;
        }
        public void CountCards()
        {
            this.CardsInHand = 0;
            for (int i = 0; i < this.Hand.Length; i++)
            {
                if (this.Hand[i] != null)
                {
                    this.CardsInHand++;
                }
            }
        }

        public void UpdateValues ()
        {
            CountCards();
            CountPoints();
        }

        

    }
}
