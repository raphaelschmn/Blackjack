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

            GUI gui = new GUI();
            Player player = new Player();
            gui.DisplayStartingScreen(player);

            Card[] deck = generateDeck();
            Shuffle(deck);

            Console.ReadKey();

          
            /*
            do //Gameloop
            {

            } while (true);
            */
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
            }else if ((player.Points) == 21 && (player.CardsInHand == 2))
            {
                Console.WriteLine("Winner Winner Chicken Dinner! Keep going for another one!");
                player.Money += (1.5 * player.Bet);

            }else if (player.Points > dealer.Points)
            {
                Console.WriteLine($"You win {player.Name}!");
                player.Money += player.Bet;
            }else if (dealer.Points > player.Points)
            {
                Console.WriteLine("The dealer wins! Maybe next time you'll be luckier, keep gambling!");
                player.Money -= player.Bet;
            }
            
        }

        public static bool DealerBlackjack(Player dealer)
        {
            if ((dealer.Points) == 21 && (dealer.CardsInHand == 2))
            {
                Console.WriteLine("The house always wins!");    //Fallout New Vegas Easter Egg
                return true;
            }
            else
            { 
                return false; 
            }

        }

        public static void TakeBet(ref Player player)
        {
            Console.WriteLine("How much do you want to bet?");
            double bet = int.Parse(Console.ReadLine());
            bool betfalse = false;
            do
            {
                bet = int.Parse(Console.ReadLine());

                if (bet > player.Money)
                {
                    Console.WriteLine("You dont have enough money!");
                    betfalse = true;
                }
                else if (bet < player.Money)
                {
                    Console.WriteLine($"You bet {bet}$");
                    betfalse = false;
                }
                else if (bet == player.Money)
                {
                    Console.WriteLine("All in!");
                    betfalse = false;
                }

            } while (betfalse);

            player.Bet = bet;
        }

                

       



        
    }
}
