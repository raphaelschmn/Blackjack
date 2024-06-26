﻿using System;
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

            StartGame();
        }

            public static void StartGame() 
            {
                string continuePlaying = "";
                GUI gui = new GUI();
                Player player = new Player();
                Player dealer = new Player();
                int tick = 0;
                gui.DisplayStartingScreen(player);
                do
                {
                    Card c = new Card(4, 4);
                    Reset(player, dealer, ref tick);

                    Card[] deck = generateDeck();
                    Shuffle(deck);

                    TakeBet(ref player);

                    DrawCard(deck,ref player,ref tick);
                    DrawCard(deck, ref player, ref tick);
                    DrawCard(deck, ref dealer, ref tick);
                    DrawCard(deck, ref dealer, ref tick);
                    player.UpdateValues();
                    dealer.UpdateValues();

                    CheckAce(ref dealer);
                    CheckAce(ref player);
                    gui.GameScreen(player, dealer, false);

                if (!CheckBlackjack(dealer) && !((player.Points == 21) && (player.CardsInHand == 2)))
                {
                    bool alive = true;

                    string choice = "";
                    while (alive == true && choice != "S")
                    {
                        if (player.CardsInHand == 2)
                        {
                            Console.WriteLine("\n(H)it, (S)tick or (D)ouble?");
                            Console.Write(">");
                            choice = Console.ReadLine().ToUpper();
                            if (choice == "D")
                            {
                                player.Bet = player.Bet * 2;
                                DrawCard(deck, ref player, ref tick);
                                player.UpdateValues();
                                CheckAce(ref player);
                                gui.GameScreen(player, dealer, false);
                                alive = CheckBust(player);
                                choice = "S";
                            }
                            else if (choice == "H")
                            {
                                DrawCard(deck, ref player, ref tick);
                                player.UpdateValues();
                                CheckAce(ref player);
                                gui.GameScreen(player, dealer, false);
                                alive = CheckBust(player);
                            }
                        }
                        else
                        {
                            Console.WriteLine("\n(H)it or (S)tick?");
                            Console.Write(">");
                            choice = Console.ReadLine().ToUpper();
                            if (choice == "H")
                            {
                                DrawCard(deck, ref player, ref tick);
                                player.UpdateValues();
                                CheckAce(ref player);
                                gui.GameScreen(player, dealer, false);
                                alive = CheckBust(player);
                            }
                        }
                    }

                    if (alive == true)
                    {
                        bool dealerAlive = true;

                        Console.WriteLine("***Dealer's turn***");

                        while (dealerAlive == true && dealer.Points < 17)
                        {
                            Console.WriteLine("Press Enter to continue!");
                            Console.ReadLine();
                            DrawCard(deck, ref dealer, ref tick);
                            dealer.UpdateValues();
                            CheckAce(ref dealer);
                            gui.GameScreen(player, dealer, true);
                            dealerAlive = CheckBust(dealer);
                        }

                    }
                }
                    gui.GameScreen(player, dealer, true);
                    CalculateWinner(player, dealer);

                    Console.WriteLine("\n\nDo you want to play again? (Y)es, (N)o? {0, 25}", $"Current money: {player.Money}");
                    continuePlaying = Console.ReadLine().ToUpper();
                    Console.Clear();
                } while (continuePlaying != "N");
                Console.Clear();
                Console.WriteLine($"You have {player.Money}$, so you earned {player.Money-5000}$!");
                Console.ReadKey();
            }

        public static void Reset(Player p, Player d, ref int tick)
        {
            p.CardsInHand = 0;
            d.CardsInHand= 0;
            p.Bet = 0;
            p.Points = 0;
            d.Points = 0;
            tick = 0;
                Array.Clear(p.Hand, 0, 9);
                Array.Clear(d.Hand, 0, 9);
        }
        static Card[] generateDeck()
        {
            Card[] deck = new Card[52];
            int counter = 0;

            for (int suit = 1; suit < 5; suit++)
            {
                for (int value = 1; value < 14; value++)
                {
                    deck[counter] = new Card(suit, value); 
                    counter++;
                }
            }
            return deck;
        }

        public static void DrawCard(Card[] deck, ref Player p, ref int tick)
        {
            p.Hand[p.CardsInHand] = deck[tick];
            p.CardsInHand++;
            tick++;
        }

        public static Card[] Shuffle(Card[] deck)
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
                return false;
            }
            else return true;
        }

        public static void CheckAce(ref Player player)
        {
            bool alreadyChanged = false;
            if(player.Points > 21)
            {
                for (int i = 0; i < player.CardsInHand; i++)
                {
                    if ((player.Hand[i].Points == 11) && (!alreadyChanged))
                    {
                        player.Hand[i].Points = 1;
                        player.Points -=10;
                        alreadyChanged = true;
                    }
                }
            }
        }

        public static void CalculateWinner(Player player, Player dealer)
        {
            if (!CheckBust(player))
            {
                Console.WriteLine("You loose, keep searching for your luck!");
                player.Money -= player.Bet;
            } else if (!CheckBust(dealer))
            {
                Console.WriteLine("You win! Continue your winning!");
                player.Money += player.Bet;
            } else if (player.Points == dealer.Points)
            {
                Console.WriteLine("It's a Draw!");
            } else if ((player.Points) == 21 && (player.CardsInHand == 2))
            {
                Console.WriteLine("Winner Winner Chicken Dinner! Keep going for another one!");
                player.Money += (1.5 * player.Bet);

            } else if (player.Points > dealer.Points)
            {
                Console.WriteLine($"You win {player.Name}!");
                player.Money += player.Bet;
            } else if (dealer.Points == 21 && dealer.CardsInHand == 2)
            {
                Console.WriteLine("The house always wins!");    //Fallout New Vegas Easter Egg
                Console.WriteLine("The dealer has a blackjack. Continue gambling for the big win!");                
            }else if ((dealer.Points > player.Points) && (dealer.Points <= 21))
            {
                Console.WriteLine("The dealer wins! Maybe next time you'll be luckier, keep gambling!");
                player.Money -= player.Bet;
            }
            
        }
        public static bool CheckBlackjack(Player dealer)
        {
            if ((dealer.Points) == 21 && (dealer.CardsInHand == 2))
            {
                return true;
            }
            else
            {
                return false; 
            }

        }

        public static void TakeBet(ref Player player)
        {
            double bet = 0;
            bool error = false;
            Console.Write("Your bet please: {0, 20}$", "Current money: " + player.Money);
            Console.WriteLine("");
            
            do
            {
                try { bet = int.Parse(Console.ReadLine()); error = false; } catch { Console.WriteLine("Please enter a valid bet!"); error = true; }
                if (bet <= 0)
                {
                    Console.WriteLine("Please enter a valid bet!"); error = true;
                }
                if(player.Money < 0 && bet > 50)
                {
                    Console.WriteLine("Your in minus, your max bet can only be 50$"); error = true;
                }
            } while (error);

            if (bet > player.Money)
            {
                int random;
            Random rnd = new Random();
            random = rnd.Next(0, 11);
                if (random == 0)
                {
                    Console.WriteLine("You sold your house, because you failed at gambling but you want to continue.");
                }else if (random == 1)
                {
                    Console.WriteLine("You stole from the church, because you hadn't had enough money to keep gambling.");
                }else if(random == 2)
                {
                    Console.WriteLine("Your bank is furious because you took another loan to keep on gambling.");
                }else if(random == 3)
                {
                    Console.WriteLine("You went to another casino to get more money to continue gambling.");
                }else if(random == 4)
                {
                    Console.WriteLine("You sold your boss' pc to continue gambling.");
                }else if (random == 5)
                {
                    Console.WriteLine("You sold your soul to the devil in order to continue gambling.");
                }else if (random == 6)
                {
                    Console.WriteLine("You borrow Monopoly-money to keep on gambling.");
                }else if(random == 7)
                {
                    Console.WriteLine("You sold your next meal at grandma's to continue gambling.");
                }else if (random == 8)
                {
                    Console.WriteLine("You sold your left kidney to continue gambling");
                }else if (random == 9)
                {
                    Console.WriteLine("You sacrificed you firstborn to montanablack to keep gambling");
                }else if (random == 10)
                {
                    Console.WriteLine("You pawned off your rare pokemon cards to keep gambling");
                }

            }
            else if (bet < player.Money)
            {
                Console.WriteLine($"You bet {bet}$");
            }
            else if (bet == player.Money)
            {
                Console.WriteLine("All in!");
            }
            player.Bet = bet;
            Console.ReadKey();
        }
    }
}
