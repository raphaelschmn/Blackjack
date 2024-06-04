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
        public string Side;
        public string ValueShown;

        public Card(int s, int v)
        {
            Value = v; // Sets the Value of the card to the value of v (The second argument)
            switch (s) // Case statement based on the value of s
            {
                case 1: // If s == 1, then set the Suit to Clubs
                    Suit = "♣";
                    break;
                case 2: // If s == 2, then set the Suit to Diamonds
                    Suit = "♦";
                    break;
                case 3: // If s == 3, then set the Suit to Hearts
                    Suit = "♥";
                    break;
                case 4: // If s == 4, then set the Suit to Spades
                    Suit = "♠";
                    break;
            }
            if (Value > 10) //For Jack, Queen and King
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
            else if (Value == 1) //For Ace
            {
                Points = 11;
                this.ValueShown = "A";
            }
            else //For Normal Cards
            {
                Points = Value;
                this.ValueShown = Value.ToString();
            }
        
        }
    }
}
