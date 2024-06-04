using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            //Output Encoding für Unicode Symbole
            Console.OutputEncoding = System.Text.Encoding.UTF8;
        }






        static Card[] generateDeck()
        {
            Card[] deck = new Card[52];
            int counter = 0;

            for (int suit = 1; suit < 5; suit++)           //Loop trough all Suits
            {
                for (int value = 1; value < 14; value++)   //Loop trough all Values
                {
                    deck[counter] = new Card(suit, value);  //Generate new Card 
                    counter++;
                }
            }

            return deck;
        }


        public static Card[] Shuffle(Card[] deck)      //In progress
        {
            Random rng = new Random();
            Card temp;
            int num = 0; 
            for (int i = 0; i < deck.Length ; i ++) 
            {
                num = rng.Next(0, deck.Length);  
                temp = deck[i];
                deck[i] = deck[num];
                deck[num] = temp;

                
            }

            return deck;
        }
        
    }
}
