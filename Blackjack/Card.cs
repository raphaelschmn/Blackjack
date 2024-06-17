using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal class Card
    {
        public string Suit;
        public int Points;
        public int Value;
        public string ValueShown;

        public Card(int s, int v)
        {
            Value = v;
            switch (s)
            {
                case 1:
                    Suit = "♣";
                    break;
                case 2:
                    Suit = "♦";
                    break;
                case 3:
                    Suit = "♥";
                    break;
                case 4:
                    Suit = "♠";
                    break;
            }
            if (Value > 10)
            {
                Points = 10; 
                switch (v)
                {
                    case 11:
                        this.ValueShown = "J";
                        break;
                    case 12:
                        this.ValueShown = "Q";
                        break;
                    case 13:
                        this.ValueShown = "K";
                        break;
                }
            }
            else if (Value == 1)
            {
                Points = 11;
                this.ValueShown = "A";
            }
            else
            {
                Points = Value;
                this.ValueShown = Value.ToString();
            }
        
        }
    }
}
