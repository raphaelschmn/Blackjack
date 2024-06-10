using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; //Output Encoding für Unicode Symbol

            GameHandler gameHandler = new GameHandler();
            gameHandler.StartGame();
        }

        internal class GameHandler
        {
            public void StartGame() 
            {
                string continuePlaying = "";
                GUI gui = new GUI();
                Player player = new Player();
                //player.Money = 1000;
                Player dealer = new Player();
                do
                {
                    Card c = new Card(4, 4);

                    Reset(player, dealer);

                    gui.DisplayStartingScreen(player);

                    Console.Write("\n\nDo you want to play again? (Y)es, (N)o?");
                } while (continuePlaying == "Y" || continuePlaying == "y") ;
            }
        }

        public static void Reset(Player p, Player d)
        {
            p.CardsInHand = 0;
            d.CardsInHand= 0;
            p.Points = 0;
            d.Points = 0;
                Array.Clear(p.Hand, 0, 9);
                Array.Clear(d.Hand, 0, 9);
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


        public static Card[] Shuffle(Card[] deck)      //Shuffle Deck
        {
            Random rng = new Random();
            Card temp;
            int num = 0; 
            for (int i = 0; i < 10 ; i ++) 
            {
                for (int j = 0; j < deck.Length; j++)
                {
                    num = rng.Next(0, deck.Length);
                    temp = deck[j];
                    deck[j] = deck[num];
                    deck[num] = temp;
                }
            }
            return deck;
        }

        public static bool CheckBust(Player player)
        {
            if (player.Points > 21)
            {
                Console.WriteLine("Bust! Keep gambling, next time you'll be luckier!");
                return true;
            }
            else return false;
        }

        public static void CheckAce(ref Player player)
        {
            bool alreadyChanged = false;
            if(player.Points > 21)
            {
                for (int i = 0; i < player.Hand.Length; i++)
                {
                    if ((player.Hand[i].Points == 1) && (alreadyChanged != true))
                    {
                        player.Hand[i].Points = 1;
                        player.Points--;
                        alreadyChanged = true;
                    }
                }
            }
        }

        public static void CalculateWinner(Player player, Player dealer)
        {
            if (player.Points == dealer.Points)
            {
                Console.WriteLine("It's a Draw!");
            }else if (player.Points > dealer.Points)
            {
                Console.WriteLine($"You win {player.Name}!");
            }else if (dealer.Points > player.Points)
            {
                Console.WriteLine("The dealer wins! Maybe next time you'll be luckier, keep gambling!");
            }

        }
    }
}
